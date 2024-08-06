using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Audio;
using Cinemachine;

public class mainmainevent : MonoBehaviour
{
    public Slider musicSlider;
    public Slider SFXSlider;
    public Slider buttonSlider;

    public AudioMixer mixer;

    //missions
    public GameObject[] missions;
    private int currentMissionIndex = 0;

    public GameObject Boss;
    public GameObject enemySpawner;

    //tutorial

    public int doneGameT = 0;
    public GameObject tutorialPanal;

    //camera ref
    public CinemachineVirtualCamera virtualCamera;
    private float zoomSpeed = 5f; // Adjust the speed of zooming out


    private void Start()
    {
        if (PlayerPrefs.HasKey("musicVolume") || PlayerPrefs.HasKey("SFXVolume") || PlayerPrefs.HasKey("buttonVolume"))
        {
            loadValue();
        }
        else
        {
            setMusicVolume();
            setSFXVolume();
            setButtonVolume();
        }
        InitializeMissions();

        doneGameT = PlayerPrefs.GetInt("doneGameT", 0);

        virtualCamera = GetComponent<CinemachineVirtualCamera>();

      
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
                Boss.SetActive(true);
            }
        }
    }

    private void ShowWinnerPanel()
    {
        if (Boss != null)
        {
            //Boss.SetActive(true);
            if (virtualCamera != null)
            {
                // Get the current field of view value
                float currentFOV = virtualCamera.m_Lens.FieldOfView;

                // Increase the field of view to zoom out
                currentFOV += zoomSpeed * Time.deltaTime;

                // Update the field of view of the virtual camera
                virtualCamera.m_Lens.FieldOfView = currentFOV;
            }
            enemySpawner.SetActive(false);
            
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

    public void loadValue()
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
        //Score count reset
        scoreCount.scoreValue = 0;
        //set particles to 0
        tripletbullet.expCount = 0;
    }

    public void tutorial()
    {
        if (doneGameT == 0)
        {
            tutorialPanal.SetActive(true);
            PlayerPrefs.SetInt("doneGameT", 1);
        }
        else
        {
            loadscene(1);
        }
    }

    //exiting the game
    public void exist()
    {
        Application.Quit();
    }
}
