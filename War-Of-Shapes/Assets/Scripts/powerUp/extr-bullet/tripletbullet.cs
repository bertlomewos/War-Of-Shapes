using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PowerUp/ExtraBullet")]

public class tripletbullet : powerUpManager
{
    public static float expCount = 0;
    public static float trashHold = 300;

    public override void Apply(GameObject target)
    {
        playerMovment shootingpoint = target.GetComponent<playerMovment>();
        if(expCount == trashHold) { 
            shootingpoint.activate = true;
        }
    }
}
