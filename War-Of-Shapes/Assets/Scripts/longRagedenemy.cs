using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class longRangedenemy : MonoBehaviour
{
    public Transform target;
    public float speed = 5f;
    private Rigidbody2D rb;
    public float rotatespeed = 0.25f;

    public float distanceToshoot = 5f;
    public float distanceToStop = 3f;

    public Transform firingPoint;
    [SerializeField] private GameObject bulletPrefab;
    

    public float firerate;
    public float firetime;


    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
   
    }
    private void Update()
    {
        //get the target
        if (!target)
        {
            gettarget();
        }
        else {
            //rotate twords target
            rotateTwordsTarget();
        }
        if(target != null && Vector2.Distance(target.position, transform.position) <= distanceToshoot)
        {
            shoot();
        }
    }
    private void FixedUpdate()
    {
        //move forwward

        if (target)
        {
            float distance = Vector2.Distance(target.position, transform.position);

            // Move forward if not too close to the target
            if (distance > distanceToStop)
            {
                rb.velocity = transform.up * speed * Time.fixedDeltaTime;
            }
            else
            {
                rb.velocity = Vector2.zero;
            }
        }
    }

    private void shoot()
    {
        if(firetime <= 0f)
        {
            Instantiate(bulletPrefab, firingPoint.position, firingPoint.rotation);
            firetime = firerate;
        }
        else
        {
            firetime -= Time.deltaTime;
        }
    }

    private void rotateTwordsTarget()
    {
        Vector2 targetdir = target.position - transform.position;
        float angle = Mathf.Atan2(targetdir.y, targetdir.x) * Mathf.Rad2Deg - 90f;
        Quaternion q = Quaternion.Euler(new Vector3(0, 0, angle));
        transform.localRotation = Quaternion.Slerp(transform.localRotation, q, rotatespeed);
    }

    private void gettarget()
    {
        GameObject player = GameObject.FindWithTag("Player");
        if (player != null)
        {
            target = player.transform;
        }
    }

}
