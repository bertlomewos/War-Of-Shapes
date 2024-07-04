using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playercollison : MonoBehaviour
{
    public GameObject joystick;
    public GameObject pauseButton;

    //health
    public float maxHealth = 1000f;
    public float currentHealth;

    public healthBar healthbar;

    public float damage = 20f;

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
    }
}
