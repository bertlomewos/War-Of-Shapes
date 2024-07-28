using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossOne : MonoBehaviour
{

    public float BChealth;
    public float BMXhealth = 1000;
    public float damageAmount = 20;
    public Image bossbar;
    
    void Start()
    {
        BChealth = BMXhealth;
    }

    // Update is called once per frame
    void Update()
    {
        bossbar.fillAmount = BChealth / BMXhealth;
    }
    public void damage()
    {
       BChealth -= damageAmount;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            damage();
            if(BChealth <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
}
