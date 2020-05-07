using UnityEngine.Audio;
using System;
using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;
    [HideInInspector] public Toggle _toggleWhichChanges;
    int _volumeToggle = 1;

    void Awake()
    {
        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            //s.source.volume = GameObject.Find("SliderAudio").GetComponent<Slider>().value;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
            s.source.playOnAwake = s.playOnAwake;
        }
        SetAudio();
        PlayOnAwake();
    }

    void PlayOnAwake()
    {
        for (int i = 0; i < sounds.Length; i++)
        {
            if (sounds[i].playOnAwake)
            {
                Play(sounds[i].name);
            }
        }
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
        SetAudio();
    }

    public void SetAudio()
    {
        foreach (Sound s in sounds)
        {
            s.source.volume = _volumeToggle;
        }
    }
    public void Play(string name)
    {
        if(_volumeToggle == 1)
        {
            Sound s = Array.Find(sounds, sound => sound.name == name);
            if (s == null)
                return;
            s.source.Play();
        }
    }

    public void PlaySoundClick()
    {
        FindObjectOfType<AudioManager>().Play("Click");
    }
}
