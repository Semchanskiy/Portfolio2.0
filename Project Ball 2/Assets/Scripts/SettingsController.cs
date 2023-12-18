using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SettingsController : MonoBehaviour
{
    public AudioMixer AudioMixer;
    private SettingsData settingsData;
    private ViewSettings viewSettings;

    void Start()
    {
        viewSettings = GetComponent<ViewSettings>();
        settingsData = FindObjectOfType<SettingsData>();
        LoadSettings(settingsData.soundVolume, settingsData.musicVolume);
    }
    public void LoadSettings(bool soundVolume, bool musicVolume)
    {
        viewSettings.LoadViewSettings(soundVolume,musicVolume);
    }
    
    public void OnOffSounds()
    {
        if (settingsData.soundVolume)
        {
            settingsData.soundVolume = false;
            AudioMixer.SetFloat("SoundVolume", -80);
            LoadSettings(settingsData.soundVolume, settingsData.musicVolume);
        }
        else
        {
            settingsData.soundVolume = true;
            AudioMixer.SetFloat("SoundVolume", -5);
            LoadSettings(settingsData.soundVolume, settingsData.musicVolume);
        }
    }

    public void OnOffMusic()
    {
        if (settingsData.musicVolume)
        {
            settingsData.musicVolume = false;
            AudioMixer.SetFloat("MusicVolume", -80);
            LoadSettings(settingsData.soundVolume, settingsData.musicVolume);
        }
        else
        {
            settingsData.musicVolume = true;
            AudioMixer.SetFloat("MusicVolume", -15);
            LoadSettings(settingsData.soundVolume, settingsData.musicVolume);
        }
    }
}
