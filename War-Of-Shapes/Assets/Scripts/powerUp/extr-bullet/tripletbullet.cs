using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PowerUp/ExtraBullet")]

public class tripletbullet : powerUpManager
{
    public static float expCount = 0;
    public static float trashHold = 500;
    public static float secondTrashHold = 1000;

    public override void Apply(GameObject target)
    {
        playerMovment shootingpoint = target.GetComponent<playerMovment>();
        if(expCount == trashHold) {
            AudioManager.instance.Play("levelUp");
            shootingpoint.activate = true;

        }
        if(expCount == secondTrashHold)
        {
            AudioManager.instance.Play("levelUp");
            shootingpoint.secondActive = true;
        }
    }
}
