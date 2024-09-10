using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyspawner : MonoBehaviour
{
    [Range(0, 50)]
    [SerializeField] private float spawnRate = 2f;
    public static bool spawning;

    // Array of enemy prefabs
    [SerializeField] private GameObject[] enemyPrefab;

    // Counter to track the number of spawned enemies
    public int enemiesSpawned = 0;
    public int maxEnemies = 100;

    private void Awake()
    {
        spawning = true;
    }

    private void Start()
    {
        StartCoroutine(Spawner());
    }

    private IEnumerator Spawner()
    {
        WaitForSeconds wait = new WaitForSeconds(spawnRate);

        while (spawning)
        {
            yield return wait;

            Spawn();
            enemiesSpawned++;
            if (enemiesSpawned >= maxEnemies)
            {

                spawning = false;
            }
        }
    }

    public void Spawn()
    {
        int rand = Random.Range(0, enemyPrefab.Length);
        GameObject enemyToSpawn = enemyPrefab[rand];

        Instantiate(enemyToSpawn, transform.position, Quaternion.identity);
        Instantiate(enemyToSpawn, transform.position, Quaternion.identity);
    }
}
