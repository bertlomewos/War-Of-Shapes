using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PowerUp/SpeedUP")]
public class speedBuff : powerUpManager
{
    public float amount;
    public float maxspeed;



    public override void Apply(GameObject target)
    {
        playerMovment speedComponent = target.GetComponent<playerMovment>();

        if (speedComponent != null)
        {
            if(speedComponent.speed < maxspeed)
            {
                speedComponent.speed += amount;
            }
                

        }
        else
        {
            Debug.LogWarning("Target does not have a PlayerCollision component!");
        }
    }
}
