using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class missions : MonoBehaviour
{
    //Mission
    public GameObject mission;
    public Image energyOrb;
    float currentEnergy;
    public float reqEnergy = 10f;
    bool isPlayerIn = false;
    playercollison playercollison;
  

    //missions
    public GameObject mission2;
    void Start()
    {
        currentEnergy = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (isPlayerIn)
        {
            if (currentEnergy < reqEnergy)
            {
                currentEnergy += Time.deltaTime;
                energyOrb.fillAmount = currentEnergy / reqEnergy;

            }
            else
            {
                Destroy(mission);
                mission2.SetActive(true);
                playercollison.isheilded = true;
            }
        }
       
      
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isPlayerIn = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isPlayerIn = false;
        }
    }
}
