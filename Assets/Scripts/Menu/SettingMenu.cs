using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SettingMenu : MonoBehaviour
{
    public AudioMixer audioMixer;
    public GameObject volSlider;
    public GameObject sensiSlider;


    private void Awake()
    {
        volSlider.GetComponent<Slider>().value = PlayerPrefs.GetFloat("volume");
        sensiSlider.GetComponent<Slider>().value = StaticSettings.mouseSensitivity;
    }

    public void SetVolume(float volume)
    {
        PlayerPrefs.SetFloat("volume", volume);
        audioMixer.SetFloat("volume", volume);
    }

    public void SetQuality(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
    }

    public void SetFullscreen(bool isFullScreen)
    {
        Screen.fullScreen = isFullScreen;
    }

    public void SetSensitivity(float sensitivity)
    {
        StaticSettings.mouseSensitivity = sensitivity;
    }

}

