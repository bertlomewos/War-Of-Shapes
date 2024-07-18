using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Audio;

public class mainmainevent : MonoBehaviour
{
    public Slider musicSlider;
    public Slider SFXSlider;
    public Slider buttonSlider;

    public AudioMixer mixer;

    //missions
    public GameObject[] missions;
    private int currentMissionIndex = 0;

    public GameObject winnerPanel;
    public GameObject pauseButton;

 
 
    private void Start()
    {
        if (PlayerPrefs.HasKey("musicVolume") || PlayerPrefs.HasKey("SFXVolume") || PlayerPrefs.HasKey("buttonVolume"))
        {
            loadValue();
        }
        else { 
            setMusicVolume();
            setSFXVolume();
            setButtonVolume();
        }
        InitializeMissions();
    }
    private void InitializeMissions()
    {
        for (int i = 0; i < missions.Length; i++)
        {
            missions[i].SetActive(false);
        }
        if (missions.Length > 0)
        {
            missions[0].SetActive(true);
        }
    }
    private void FixedUpdate()
    {
        CheckMissions();
    }

    private void CheckMissions()
    {
        if (currentMissionIndex < missions.Length && missions[currentMissionIndex] == null)
        {
            currentMissionIndex++;
            if (currentMissionIndex < missions.Length)
            {
                missions[currentMissionIndex].SetActive(true);
            }
            else
            {
                ShowWinnerPanel();
            }
        }
    }

    private void ShowWinnerPanel()
    {
        if (winnerPanel != null)
        {
            pauseButton.SetActive(false);
            winnerPanel.SetActive(true);
            Time.timeScale = 0;
        }
    }
    public void setMusicVolume()
    {
       float volume = musicSlider.value;
        mixer.SetFloat("music", volume);
        PlayerPrefs.SetFloat("musicVolume", volume);
    }
    public void setSFXVolume()
    {
        float volume = SFXSlider.value;
        mixer.SetFloat("SFX", volume);
        PlayerPrefs.SetFloat("SFXVolume", volume);
    }
    public void setButtonVolume()
    {
        float volume = buttonSlider.value;
        mixer.SetFloat("button", volume);
        PlayerPrefs.SetFloat("buttonVolume", volume);
    }
    public   void loadValue()
    {
        musicSlider.value = PlayerPrefs.GetFloat("musicVolume");
        SFXSlider.value = PlayerPrefs.GetFloat("SFXVolume");
        buttonSlider.value = PlayerPrefs.GetFloat("buttonVolume");

        setMusicVolume();
        setSFXVolume();
        setButtonVolume();
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
    //existing the game
    public void exist()
    {
        Application.Quit();
    }

}
