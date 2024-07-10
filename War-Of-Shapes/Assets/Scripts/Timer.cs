using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    //timer count down for shwild
    public GameObject sheild;
    public Image counter;
    float timeRemaining;
    public float maxTime  = 5.0f;
    public static bool isPlayerIn = false;
 

    void Start()
    {
        timeRemaining = maxTime;
    }

    void Update()
    {
        if(isPlayerIn == true) {        
        if (timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;
            counter.fillAmount = timeRemaining / maxTime;

        }
        else
        {
            sheild.SetActive(false);
        }
       }

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isPlayerIn = true;
        }
        if (collision.gameObject.CompareTag("Enemy"))
        {
                Destroy(collision.gameObject);
            
        }
    }
}
