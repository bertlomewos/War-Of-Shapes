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

    void Start()
    {
        currentEnergy = 0;

        // Ensure playercollison is set
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            playercollison = player.GetComponent<playercollison>();
            if (playercollison == null)
            {
                Debug.LogError("playercollison component not found on the Player object.");
            }
        }
        else
        {
            Debug.LogError("Player object not found.");
        }

        // Additional null checks for the public fields
        if (energyOrb == null)
        {
            Debug.LogError("Energy Orb Image is not assigned.");
        }

        if (mission == null)
        {
            Debug.LogError("Mission GameObject is not assigned.");
        }
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
                if (playercollison != null)
                {
                    playercollison.currentHealth += 500;
                }
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
