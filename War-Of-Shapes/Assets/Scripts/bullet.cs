using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            //kill score
            scoreCount.scoreValue++;

            //highscore
            PlayerPrefs.SetInt("highestScore", scoreCount.highscore);

            //distroy yourself
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }
}
