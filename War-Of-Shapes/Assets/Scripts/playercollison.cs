using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playercollison : MonoBehaviour
{
    public GameObject joystick;
    public GameObject pauseButton;
    public GameObject deadzonescreen;

    //health
    public float maxHealth = 1000f;
    public  float currentHealth;

    public healthBar healthbar;

    public float damage = 20f;
    public float dd = 10f;
    public bool indeadzone = false;

    //sheild 
    public static bool sheildActive = false;
    public GameObject sheild;
    public float sheildTime;
    public float maxSheildTime = 15f;
    public float sheildHp = 500;



    //audio part
    AudioManager audioManager;

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    private void Start()
    {
        currentHealth = maxHealth;
        healthbar.setHealth(maxHealth);
        sheildTime = maxSheildTime;
    }
    private void Update()
    {
        healthbar.setHealth(currentHealth);

        if(currentHealth <= maxHealth / 4)
        {
            playerSheild();
        }
        else
        {
            sheild.SetActive(false);
        }
    }

    public void takeDamage()
    {

        currentHealth -= damage;
        healthbar.setHealth(currentHealth);
    }
    public void dangerZoneDamage()
    {
        currentHealth -= dd;
        healthbar.setHealth(currentHealth);
    }

    public void playerSheild()
    {
        if(sheildTime > 0) { 
            sheild.SetActive(true);
            sheildTime -= Time.deltaTime;
        }
        else
        {
            sheild.SetActive(false);
        }
    }

    private void FixedUpdate()
    {
        if(deadzonescreen != null && indeadzone == true)
        {
            currentHealth -= dd * Time.fixedDeltaTime;
            healthbar.setHealth(currentHealth);
            if (currentHealth <= 0)
            {
                GameOver();
            }
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.transform.tag == "Enemy" || collision.transform.tag == "BossEnemy")
        {

            takeDamage();
            if (currentHealth <= 0)
            {

                GameOver();
            }
            
        }
        if (collision.gameObject.CompareTag("Enemybullet"))
        {

            takeDamage();
            Destroy(collision.gameObject);
            if (currentHealth <= 0)
            {
                GameOver();
            }


        }

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.CompareTag("SafeZone"))
        {
            indeadzone = false;
            if (deadzonescreen != null)
            {
                deadzonescreen.SetActive(false);
            }
        }


     }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("SafeZone"))
        {
            indeadzone = true;
            dangerZoneDamage();
            if(deadzonescreen != null)
            {
                deadzonescreen.SetActive(true);
            }
           
        }
    }
    public void GameOver()
    {
        //Adio play
        audioManager.PlaySFX(audioManager.death);
        //distroy the player
        Destroy(gameObject);

        //remove pause button
        pauseButton.SetActive(false);

        Debug.Log("game over");

        //display game over screen
        MenuControl.isgameover = true;

        //disable joystick
        joystick.SetActive(false);

        //stop more enemeis from spawning
        enemyspawner.spawning = false;

        //stop everything
        Time.timeScale = 0;
        // make it false for indeadzone
        if (deadzonescreen != null)
        {
            deadzonescreen.SetActive(false);
        }


    }
}
