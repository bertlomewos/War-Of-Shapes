using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class poweUpHp : MonoBehaviour
{
    public powerUpManager power;
    public float energyLevel = 50;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            AudioManager.instance.Play("pickUp");
            Destroy(gameObject);

            //Exp increase
            tripletbullet.expCount += energyLevel;
            power.Apply(collision.gameObject);
        }
    }
}
