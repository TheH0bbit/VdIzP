using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SettingsMenu : MonoBehaviour
{

    public AudioMixer audioMixer;
    public AudioMixer audioMixer2;


    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("Volume", volume);
    }
    public void SetSFX(float volumeSFX)
    {
        audioMixer2.SetFloat("Volume", volumeSFX);
    }
}
