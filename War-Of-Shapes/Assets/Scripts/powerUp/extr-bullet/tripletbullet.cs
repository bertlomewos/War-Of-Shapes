using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PowerUp/ExtraBullet")]

public class tripletbullet : powerUpManager
{
    public static float expCount = 0;
    public static float trashHold = 700;
    public static float secondTrashHold = 1600;
    public static float thirdTrashHold = 3000;

    //audio
    AudioManager audioManager;


                
    public override void Apply(GameObject target)
    {
        // Find the "Audio" GameObject and get the AudioManager component
        GameObject audioGameObject = GameObject.FindGameObjectWithTag("Audio");
        if (audioGameObject != null)
        {
            audioManager = audioGameObject.GetComponent<AudioManager>();
        }
        playerMovment shootingpoint = target.GetComponent<playerMovment>();
        if(expCount == trashHold) {
            // Check if audioManager is not null before calling PlaySFX()
            if (audioManager != null)
            {
                //Adio play
                audioManager.PlaySFX(audioManager.levelUp);
            }
            shootingpoint.activate = true;

        }
        if(expCount == secondTrashHold)
        {
            // Check if audioManager is not null before calling PlaySFX()
            if (audioManager != null)
            {
                //Adio play
                audioManager.PlaySFX(audioManager.levelUp);
            }
            shootingpoint.secondActive = true;
        }
        if (expCount == thirdTrashHold)
        {
            // Check if audioManager is not null before calling PlaySFX()
            if (audioManager != null)
            {
                //Adio play
                audioManager.PlaySFX(audioManager.levelUp);
            }
            shootingpoint.thirdActivate = true;
        }
    }
}
