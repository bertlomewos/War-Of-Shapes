using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossOne : MonoBehaviour
{

    public static float BChealth=0;
    public static float BMXhealth = 7000;
    public float damageAmount = 20;
    public Image bossbar;

    //shooting trakekrs

    [SerializeField] private Transform shootingPoint;
    [SerializeField] private Transform shootingPoint1;


    //shooting normi stright 
    [SerializeField] private Transform shootingPoint2;
    [SerializeField] private Transform shootingPoint3;
    [SerializeField] private Transform shootingPoint4;
    [SerializeField] private Transform shootingPoint5;
    [SerializeField] private Transform shootingPoint6;


    //bullet prefab
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private GameObject bulletPrefab1;

    //for traker
    [Range(0.1f, 10f)]
    [SerializeField] private float fireRate = 0.5f;
    private float shootTime;

    //for normi stright 
    [Range(0.1f,5f)]
    [SerializeField] private float fireRateNormiST = 0.5f;
    private float shootTimeNormiST;

    //died

    public GameObject won;
    public GameObject pause;




    void Awake()
    {
        BChealth = BMXhealth;
    }

    // Update is called once per frame
    void Update()
    {
        bossbar.fillAmount = BChealth / BMXhealth;


        if(shootTime <= 0)
        {
        shooting();

            shootTime = fireRate;

        }
        else
        {
            shootTime -= Time.deltaTime;
        }

        if(shootTimeNormiST <= 0)
        {
            normiShoot();
            shootTimeNormiST = fireRateNormiST;
        }
        else
        {
            shootTimeNormiST  -= Time.deltaTime;
        }
    }
    public void damage()
    {
       BChealth -= damageAmount;
    }

    public void shooting()
    {
        Instantiate(bulletPrefab, shootingPoint.position, shootingPoint.rotation);
        Instantiate(bulletPrefab, shootingPoint1.position, shootingPoint1.rotation);
    }

    public void normiShoot()
    {
        Instantiate(bulletPrefab1, shootingPoint2.position, shootingPoint2.rotation);
        Instantiate(bulletPrefab1, shootingPoint3.position, shootingPoint3.rotation);
        Instantiate(bulletPrefab1, shootingPoint4.position, shootingPoint4.rotation);
        Instantiate(bulletPrefab1, shootingPoint5.position, shootingPoint5.rotation);
        Instantiate(bulletPrefab1, shootingPoint6.position, shootingPoint6.rotation);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {

            damage();
            if (BChealth <= 0)
            {
                gameOver();
            }
        }
    }
    public void gameOver()
    {
        Destroy(gameObject);
        pause.SetActive(false);
        won.SetActive(true);
        Time.timeScale = 0;
    }
}
