using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PowerUp/ExtraBullet")]

public class tripletbullet : powerUpManager
{

    
    public override void Apply(GameObject target)
    {
        playerMovment shootingpoint = target.GetComponent<playerMovment>();
        shootingpoint.activate = true;
    }
}
