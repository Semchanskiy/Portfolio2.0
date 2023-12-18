using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ViewSettings : MonoBehaviour
{
    public Text _soundsText;
    public Text _musicText;

    public void LoadViewSettings(bool soundVolume, bool musicVolume)
    {
        if (soundVolume)
        {
            _soundsText.text = ("On");
        }
        else
        {
            _soundsText.text = ("Off");
        }
        if (musicVolume)
        {
            _musicText.text = ("On");
        }
        else
        {
            _musicText.text = ("Off");
        }
    }
}
