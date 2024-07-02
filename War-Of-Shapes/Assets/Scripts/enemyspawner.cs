using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyspawner : MonoBehaviour
{
    [Range(0, 50)]
    [SerializeField] private float spawnRate = 2f;
    //making it static makes it the only one throughout the scoop of the gloab it is not an instance
    public static bool spawning;

    //this is an arrry of game objects (in this instance array of enemies )
    [SerializeField] private GameObject[] enemyPrefab;



    private void Awake()
    {
        spawning = true;
    }
    private void Start()
    {
        StartCoroutine(spawner());
    }

    private IEnumerator spawner()
    {
        WaitForSeconds wait = new WaitForSeconds(spawnRate);

        while (spawning)
        {
            yield return wait;
            spawn();
        }
    }

    public void spawn()
    {
        int rand = Random.Range(0, enemyPrefab.Length);
        GameObject enemyTospawn = enemyPrefab[rand];

        

        Instantiate(enemyTospawn, transform.position, Quaternion.identity);
    }
}
