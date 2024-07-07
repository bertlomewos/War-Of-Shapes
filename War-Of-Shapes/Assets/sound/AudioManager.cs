using System;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour {

	[SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource SFXsource;
    [SerializeField] AudioSource buttonsource;


    public AudioClip background; 
    public AudioClip shootOne;
    public AudioClip shootTwo;
    public AudioClip levelUp;
    public AudioClip death;
    public AudioClip pickUp;

    private void Start()
    {
        musicSource.clip = background;
        musicSource.Play();
    }
    public void PlaySFX(AudioClip clip)
    {
        SFXsource.PlayOneShot(clip);
    }
    public void buttonplay(AudioClip clip)
    {
        buttonsource.PlayOneShot(clip);
    }
}
