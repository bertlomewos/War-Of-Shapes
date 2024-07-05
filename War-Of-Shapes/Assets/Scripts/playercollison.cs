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
    public float currentHealth;

    public healthBar healthbar;

    public float damage = 20f;
    public float dd = 10f;
    public bool indeadzone = false;

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
        currentHealth -= damage;

        healthbar.setHealth(currentHealth);
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
            }
        }
        if (collision.gameObject.CompareTag("Deadzone"))
        {
            indeadzone = false;
            deadzonescreen.SetActive(false);
        }


        }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Deadzone"))
        {
            indeadzone = true;
            dangerZoneDamage();
            deadzonescreen.SetActive(true);
            if (currentHealth <= 0)
            {
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
            }
        }
    }
    public void GameOver()
    {
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
        deadzonescreen.SetActive(false);
    }
}
