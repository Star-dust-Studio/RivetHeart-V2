using UnityEngine;

public class PlaySoundAcrossScene : MonoBehaviour
{
    private static readonly string MusicPref = "MusicPref";
    private static readonly string SoundPref = "SoundPref";

    private float soundVolumeFloat, musicVolumeFloat;
    public AudioSource MusicAudio;
    public AudioSource[] SoundAudio;

    void Awake()
    {
        ContinueSettings();
    }

    private void ContinueSettings()
    {
        musicVolumeFloat = PlayerPrefs.GetFloat(MusicPref);
        soundVolumeFloat = PlayerPrefs.GetFloat(SoundPref);

        MusicAudio.volume = musicVolumeFloat;

        for (int i = 0; i < SoundAudio.Length; i++)
        {
            SoundAudio[i].volume = soundVolumeFloat;
        }
    }
}
