using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public static class Tesot
{
    public static AudioMixerGroup Master;
    public static void ChangeSoundValue(float value)
    {
        Master.audioMixer.SetFloat("SoundVolume", value);
    }

}
