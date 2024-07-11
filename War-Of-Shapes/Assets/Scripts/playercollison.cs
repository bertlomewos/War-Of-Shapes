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

    public bool isheilded = false;


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
    }
    private void Update()
    {
        healthbar.setHealth(currentHealth);
    }

    public void takeDamage()
    {
        if(isheilded == false) 
        { 
        currentHealth -= damage;

        healthbar.setHealth(currentHealth);
        }
    }
    public void dangerZoneDamage()
    {
        currentHealth -= dd;

        healthbar.setHealth(currentHealth);
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
        if(collision.transform.tag == "Enemy" )
        {

            takeDamage();
            if (currentHealth <= 0)
            {

                GameOver();
            }
            
        }
      
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemybullet"))
        {
         
                takeDamage();
                if (currentHealth <= 0)
                {
                    GameOver();
                }
            
          
        }
        if (collision.gameObject.CompareTag("Deadzone"))
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
        if (collision.gameObject.CompareTag("Deadzone"))
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
