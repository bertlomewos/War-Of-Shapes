using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class poweUpHp : MonoBehaviour
{
    public powerUpManager power;
    public float energyLevel = 50;

    //audio part
    AudioManager audioManager;

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }
  

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            //Adio play
            audioManager.PlaySFX(audioManager.pickUp);
        


            Destroy(gameObject);

            //Exp increase
            tripletbullet.expCount += energyLevel;
            power.Apply(collision.gameObject);
        }
    }
}
