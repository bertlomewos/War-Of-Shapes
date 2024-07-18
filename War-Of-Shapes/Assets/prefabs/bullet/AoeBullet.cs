using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AoeBullet : MonoBehaviour
{
    [SerializeField] private float speed = 300f;
    [Range(1, 10)]
    [SerializeField] private float lifespan = 3f;

    private Rigidbody2D rb;


    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Destroy(gameObject, lifespan);
    }

    private void FixedUpdate()
    {
        rb.velocity = transform.up * speed * Time.fixedDeltaTime;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            // Increment score
            scoreCount.scoreValue++;

            // Update highscore
            PlayerPrefs.SetInt("highestScore", scoreCount.highscore);

            // Destroy the enemy and the bullet
            Destroy(collision.gameObject);
            Destroy(gameObject);

         
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("rangAOE"))
        {
            Destroy(gameObject);
        }
    }
}
