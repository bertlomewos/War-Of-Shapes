using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class playerMovment : MonoBehaviour
{
    //movment
    public float speed = 5;
    private Rigidbody2D rb;
    public Vector2 direction;

    //shooting stuff
    [SerializeField] private GameObject[] bulletprefab;
    [SerializeField] private Transform shootingpoint;
    [SerializeField] private Transform shootingpoint1;
    [SerializeField] private Transform shootingpoint2;

    
    public bool activate = false;

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
        if(shootTime <= 0f) 
        { 
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
        

        int rand = Random.Range(0, bulletprefab.Length);
        GameObject bulletTospawn = bulletprefab[rand];

        Instantiate(bulletTospawn, shootingpoint.position, shootingpoint.rotation);
        if(activate == true)
        {
            Instantiate(bulletTospawn, shootingpoint1.position, shootingpoint1.rotation);
            Instantiate(bulletTospawn, shootingpoint2.position, shootingpoint2.rotation);
        }
       
    }

    //access the new input system to know which directon it wants it to be pushed
    private void OnMove(InputValue input) => direction = input.Get<Vector2>().normalized;
}
