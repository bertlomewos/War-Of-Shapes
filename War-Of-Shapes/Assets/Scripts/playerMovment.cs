using System.Collections;
using System.Collections.Generic;
using UnityEditor.Search;
using UnityEngine;
using UnityEngine.InputSystem;

public class playerMovment : MonoBehaviour
{
    // Movement
    public float speed = 5f;
    private Rigidbody2D rb;
    private Vector2 direction;

    // Shooting stuff
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private GameObject bulletPrefab1;
    [SerializeField] private GameObject bulletPrefab2;
    [SerializeField] private Transform shootingPoint;
    [SerializeField] private Transform shootingPoint1;
    [SerializeField] private Transform shootingPoint2;

    public bool activate = false;

    [Range(0.1f, 1f)]
    [SerializeField] private float fireRate;
   
    [SerializeField] private float fireRate2 = 0.5f;

    private float shootTime;
    private float shootTime2;

    private void Start()
    {
        // Sets the Rigidbody
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        HandleShooting();
    }

    private void FixedUpdate()
    {
        // Move the actual body
        if (rb != null)
        {
            rb.velocity = direction * speed * Time.fixedDeltaTime;
        }
    }

    private void HandleShooting()
    {
        if (shootTime <= 0f)
        {
            Shoot();
            shootTime = fireRate;
        }
        else
        {
            shootTime -= Time.deltaTime;
        }

        if (activate && shootTime2 <= 0f)
        {
            ShootTwoMore();
            shootTime2 = fireRate2;
        }
        else
        {
            shootTime2 -= Time.deltaTime;
        }
    }

    private void Shoot()
    {
        Instantiate(bulletPrefab, shootingPoint.position, shootingPoint.rotation);
    }

    private void ShootTwoMore()
    {
        Instantiate(bulletPrefab1, shootingPoint1.position, shootingPoint1.rotation);
        Instantiate(bulletPrefab2, shootingPoint2.position, shootingPoint2.rotation);
    }

    // Access the new input system to know which direction it wants to be pushed
    private void OnMove(InputValue input) => direction = input.Get<Vector2>().normalized;
}
