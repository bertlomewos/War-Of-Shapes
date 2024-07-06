using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mainmainevent : MonoBehaviour
{
    private void Start()
    {
        AudioManager.instance.Play("backGround");
    }
    public void loadscene(int index)
    {
        SceneManager.LoadScene(index);
        Time.timeScale = 1;
        //Scorec count reset
        scoreCount.scoreValue = 0;
        //setparticles to 0
        tripletbullet.expCount = 0;
    }

}
