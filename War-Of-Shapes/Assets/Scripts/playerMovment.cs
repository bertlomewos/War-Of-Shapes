using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class playerMovment : MonoBehaviour
{
    public float speed = 5;
    private Rigidbody2D rb;
    public Vector2 direction;

    //shooting stuff
    [SerializeField] private GameObject bulletprefab;
    [SerializeField] private Transform shootingpoint;
    [Range(0.1f, 1f)]
    [SerializeField] private float fireRate = 0.5f;
    private float shootTime;

    private void Start()
    {
        //sets the rigidbody 
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if(shootTime <= 0f) { 
        shoot();
            shootTime = fireRate;
        }
        else
        {
            shootTime -= Time.deltaTime;
        }
    }
    private void FixedUpdate()
    { 
        // move the actual body
        if(rb != null)
        {
            rb.velocity = direction * speed * Time.fixedDeltaTime;
        }
       
    }

    private void shoot()
    {
        Instantiate(bulletprefab, shootingpoint.position, shootingpoint.rotation);
    }

    //access the new input system to know which directon it wants it to be pushed
    private void OnMove(InputValue input) => direction = input.Get<Vector2>().normalized;
}
