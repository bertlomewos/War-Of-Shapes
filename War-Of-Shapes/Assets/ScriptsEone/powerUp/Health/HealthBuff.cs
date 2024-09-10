using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PowerUp/Revitalize")]
public class HealthBuff : powerUpManager
{
    public float amount;
 

    public override void Apply(GameObject target)
    {
        playercollison healthComponent = target.GetComponent<playercollison>();

        if (healthComponent != null)
        {
            if(healthComponent.currentHealth < healthComponent.maxHealth)
            {
                healthComponent.currentHealth += amount;
            }
            

        }
        else
        {
            Debug.LogWarning("Target does not have a PlayerCollision component!");
        }
    }
}
