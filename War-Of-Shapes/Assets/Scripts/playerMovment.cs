using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;

public class playerMovment : MonoBehaviour
{
    // Movement
    public float speed = 5f;
    private Rigidbody2D rb;
    private Vector2 direction;

    // Shooting
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private GameObject bulletPrefab1;
    [SerializeField] private GameObject bulletPrefab2;

    [SerializeField] private GameObject bulletPrefab3;
    [SerializeField] private GameObject bulletPrefab4;

/*    [SerializeField] private GameObject bulletPrefab5;
    [SerializeField] private GameObject bulletPrefab6;
*/


    [SerializeField] private Transform shootingPoint;
    [SerializeField] private Transform shootingPoint1;
    [SerializeField] private Transform shootingPoint2;

    [SerializeField] private Transform shootingPoint3;
    [SerializeField] private Transform shootingPoint4;

    [SerializeField] private Transform shootingPoint5;
    [SerializeField] private Transform shootingPoint6;
    public bool activate = false;
    public bool secondActive = false;
    public bool thirdActivate = false;

    [Range(0.1f, 1f)]
    [SerializeField] private float fireRate = 0.5f;
    [SerializeField] private float fireRate2 = 0.5f;
    [SerializeField] private float fireRate3 = 0.5f;
    [SerializeField] private float fireRate4 = 0.5f;



    private float shootTime;
    private float shootTime2;
    private float shootTime3;
    private float shootTime4;

    public List<GameObject> enemies;
    public GameObject closestEnemy;
    public static Vector2 targetDir;
    public static bool activateFire = false;
    public GameObject navigationArrow;



    //audio part
    AudioManager audioManager;


    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }


    private void Start()
    {
        // Set the Rigidbody
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        // Find the closest enemy
        FindClosestEnemy();

        if (closestEnemy != null)
        {
            // Rotate towards the closest enemy
            MoveShootingPointsTowardsTarget(closestEnemy.transform);

        }
        else
        {
            // Rotate the shooting points based on the player's movement direction
            MoveShootingPoints();
        }

    
        HandleShooting();
        

        if(activate == true)
        {
            navigationArrow.SetActive(true);
        }

    }

    private void FixedUpdate()
    {
        // Move the player
        if (rb != null)
        {
            rb.velocity = direction * speed * Time.fixedDeltaTime;
        }
    }

    private void HandleShooting()
    {
        if (closestEnemy != null && shootTime <= 0f)
        {

            Shoot();
            shootTime = fireRate;
        }
        else
        {
            shootTime -= Time.deltaTime;
        }

        if (activate && closestEnemy != null && shootTime2 <= 0f)
        {
            ShootTwoMore();
            shootTime2 = fireRate2;
        }
        else
        {
            shootTime2 -= Time.deltaTime;
        }

        if (secondActive && closestEnemy != null && shootTime3 <= 0f)
        {
            ShootFourMore();
            shootTime3 = fireRate3;
        }
        else
        {
            shootTime3 -= Time.deltaTime;
        }       
        if (thirdActivate && closestEnemy != null && shootTime4 <= 0f)
        {
            shootSixMore();
            shootTime4 = fireRate4;
        }
        else
        {
            shootTime4 -= Time.deltaTime;
        }

    }

   

    private void MoveShootingPointsTowardsTarget(Transform target)
    {
        targetDir = (target.position - transform.position).normalized;
        shootingPoint.position = transform.position + (Vector3)targetDir;
      
    }

    private void MoveShootingPoints()
    {
        if (direction != Vector2.zero)
        {
            Vector2 moveDir = direction.normalized;
            shootingPoint.position = transform.position + (Vector3)moveDir;
           
        }
    }


    private void FindClosestEnemy()
    {
        string enemyType = "BossEnemy";
        enemies = GameObject.FindGameObjectsWithTag(enemyType).ToList();
        if (enemies.Count > 0)
        {
            float minDistance = Mathf.Infinity;
            foreach (GameObject enemy in enemies)
            {
                float distance = Vector3.Distance(transform.position, enemy.transform.position);
                if (distance < minDistance)
                {
                    minDistance = distance;
                    closestEnemy = enemy;
                }
            }
        }
        else
        {
            closestEnemy = null;
        }
    }
    private void Shoot()
    {
        //Adio play
        audioManager.PlaySFX(audioManager.shootOne);
        Instantiate(bulletPrefab, shootingPoint.position, shootingPoint.rotation);
    }

    private void ShootTwoMore()
    {
        //Adio play
        audioManager.PlaySFX(audioManager.shootTwo);
        Instantiate(bulletPrefab1, shootingPoint1.position, shootingPoint1.rotation);
        Instantiate(bulletPrefab2, shootingPoint2.position, shootingPoint2.rotation);
    }
    private void ShootFourMore()
    {
        //Adio play
        audioManager.PlaySFX(audioManager.shootTwo);
        Instantiate(bulletPrefab3, shootingPoint3.position, shootingPoint3.rotation);
        Instantiate(bulletPrefab4, shootingPoint4.position, shootingPoint4.rotation);
    }
    private void shootSixMore()
    {
        //Adio play
        audioManager.PlaySFX(audioManager.shootTwo);
        Instantiate(bulletPrefab1, shootingPoint5.position, shootingPoint5.rotation);
        Instantiate(bulletPrefab2, shootingPoint6.position, shootingPoint6.rotation);
    }

    // Access the new input system to know which direction it wants to be pushed
    private void OnMove(InputValue input) => direction = input.Get<Vector2>().normalized;
}