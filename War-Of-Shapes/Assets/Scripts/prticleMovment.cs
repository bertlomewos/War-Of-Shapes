using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class prticlemovment : MonoBehaviour
{
    public Transform target;
    public float speed = 5f;
    private Rigidbody2D rb;
    public float rotatespeed = 0.25f;


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
        else
        {
            //rotate twords target
            rotateTwordsTarget();
        }
    }
    private void FixedUpdate()
    {
        //move forwward
        rb.velocity = transform.up * speed * Time.fixedDeltaTime;
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
