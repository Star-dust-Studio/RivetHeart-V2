using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIMasterSoundController : MonoBehaviour
{
    private static readonly string FirstPlay = "FirstPlay";
    private static readonly string MusicPref = "MusicPref";
    private static readonly string SoundPref = "SoundPref";
    private int firstPlayInt;
    public Slider soundVolumeSlider, musicVolumeSlider;
    private float soundVolumeFloat, musicVolumeFloat;
    public AudioSource[] MusicAudio;
    public AudioSource[] SoundAudio;
   
    // public AudioSource AllBgm;

    //public AudioSource AllSfx;

    //private float musicVolume = 1f;
    //private float soundVolume = 1f;

    // Start is called before the first frame update
    void Start()
    {
        firstPlayInt = PlayerPrefs.GetInt(FirstPlay);

        if(firstPlayInt == 0)
        {
            musicVolumeFloat = .125f;
            soundVolumeFloat = .75f;
            musicVolumeSlider.value = musicVolumeFloat;
            soundVolumeSlider.value = soundVolumeFloat;
            PlayerPrefs.SetFloat(MusicPref, musicVolumeFloat);
            PlayerPrefs.SetFloat(SoundPref, soundVolumeFloat);
            PlayerPrefs.SetInt(FirstPlay, -1);
        }
        else
        {
            musicVolumeFloat = PlayerPrefs.GetFloat(MusicPref);
            musicVolumeSlider.value = musicVolumeFloat;
            soundVolumeFloat = PlayerPrefs.GetFloat(SoundPref);
            soundVolumeSlider.value = soundVolumeFloat;
        }
        
        //AllBgm.Play();
    }

    public void SaveSoundSetting()
    {
        PlayerPrefs.SetFloat(MusicPref, musicVolumeSlider.value);
        PlayerPrefs.SetFloat(SoundPref, soundVolumeSlider.value);
    }

    private void OnApplicationFocus(bool inFocus)
    {
        if(!inFocus)
        {
            SaveSoundSetting();
        }
    }

    public void UpdateSound()
    {
        for (int i = 0; i < MusicAudio.Length; i++)
        {
            MusicAudio[i].volume = musicVolumeSlider.value;
        }
            

        for(int i = 0; i < SoundAudio.Length; i++)
        {
            SoundAudio[i].volume = soundVolumeSlider.value;
        }
    }

    // Update is called once per frame
    //void Update()
    // {
    // AllBgm.volume = musicVolume;
    //  AllSfx.volume = soundVolume;
    // }

    //public void updateVolume(float volume)
    // {
    //musicVolume = volume;
    //soundVolume = volume;
    // }
}
