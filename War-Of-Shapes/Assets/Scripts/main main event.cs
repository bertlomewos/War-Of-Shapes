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
    private void loadValue()
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
