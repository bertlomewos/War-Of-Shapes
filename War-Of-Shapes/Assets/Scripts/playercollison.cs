using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playercollison : MonoBehaviour
{
    public GameObject joystick;

    //health
    public float maxHealth = 100;
    public float currentHealth;

    public healthBar healthbar;

    public float damage = 20f;

    private void Start()
    {
        currentHealth = maxHealth;
        healthbar.setHealth(maxHealth);
    }

    public void takeDamage()
    {
        currentHealth -= damage;

        healthbar.setHealth(currentHealth);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.transform.tag == "Enemy")
        {

            takeDamage();
            if (currentHealth <= 0)
            { 

               //distroy the player
                Destroy(gameObject);

                
                Debug.Log("game over");

                //display game over screen
                MenuControl.isgameover = true;
                //disable joystick
                joystick.SetActive(false);
                //stop more enemeis from spawning
                enemyspawner.spawning = false;
            }
        }
    }
}
