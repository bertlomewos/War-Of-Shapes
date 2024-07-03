using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class poweUpHp : MonoBehaviour
{
    public powerUpManager power;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
            power.Apply(collision.gameObject);
        }
    }
}
