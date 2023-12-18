using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using UnityEngine.UIElements;
using Slider = UnityEngine.UI.Slider;

public class SoundManager: MonoBehaviour
{
    [SerializeField] private AudioMixerGroup Master;
    [SerializeField] private Slider Music;
    [SerializeField] private Slider Sound;

    // Start is called before the first frame update
    public static SoundManager Instance;
    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);

#if !UNITY_EDITOR && UNITY_WEBGL
            LoadExtern();
#endif

        }
        else
        {
            Destroy(Instance.gameObject);
            Instance = this;
            DontDestroyOnLoad(gameObject);

        }
    }

    public void ChangeSoundValue(float value)
    {
        Master.audioMixer.SetFloat("SoundVolume", value);
    }

    public void ChangeMusicValue(float value)
    {
        Master.audioMixer.SetFloat("MusicVolume", value);
    }

    void Start()
    {
        Master.audioMixer.GetFloat("MusicVolume", out float valueMusic);
        Music.value = valueMusic;
        Master.audioMixer.GetFloat("SoundVolume", out float valueSound);
        Sound.value = valueSound;

    }
}
