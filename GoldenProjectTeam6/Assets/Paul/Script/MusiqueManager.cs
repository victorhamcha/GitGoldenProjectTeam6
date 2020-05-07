using System;
using UnityEngine;
using UnityEngine.UI;

public class MusiqueManager : MonoBehaviour
{
    [HideInInspector] public AudioSource audioSrc;
    [HideInInspector] public Toggle _toggleWhichChanges;
    int _volumeToggle;
    public Sound[] musics;


    void Start()
    {
        audioSrc = GetComponent<AudioSource>();
        SetVolume();
    }


    public void Play(string name)
    {
        Sound s = Array.Find(musics, sound => sound.name == name);
        if (s == null)
            return;
        s.source.Play();
    }

    public void ChangeToggle()
    {
        if (_toggleWhichChanges.isOn)
        {
            _volumeToggle = 1;
        }
        else
        {
            _volumeToggle = 0;
        }
        SetVolume();
    }

    public void SetVolume()
    {
        audioSrc.volume = _volumeToggle;
    }
}