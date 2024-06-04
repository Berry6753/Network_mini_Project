using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    private AudioSource[] audios;

    private void Awake()
    {
        audios = FindObjectsOfType<AudioSource>();
    }

    public void SoundSetting(float value)
    {
        foreach (AudioSource audio in audios)
        {
            audio.volume = value;
        }
    }
}
