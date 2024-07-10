using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class MenuControl : MonoBehaviour
{
    public static bool isgameover;
    public GameObject gameOverScreen;
    public GameObject pauseScreen;
    public mainmainevent mme;
    

    //private bool ispaused = false;

    private void Awake()
    {
        //like the start function. normally used to set up global variables
        isgameover = false;
    }
    private void Start()
    {
        
    }
    private void Update()
    {
        if (isgameover)
        {
            gameOverScreen.SetActive(true);
        }

    }
    // game pause and play
    public void pauseGame()
    { 

        pauseScreen.SetActive(true);
        Time.timeScale = 0;

    }
    public void playGame()
    {
        pauseScreen.SetActive(false);
        Time.timeScale = 1;
    }

    //locading a game scene
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
