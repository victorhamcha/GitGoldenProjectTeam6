using System;
using UnityEngine;
using UnityEngine.UI;

public class MusiqueManager : MonoBehaviour
{
    public Toggle _toggleWhichChanges;
    int _volumeToggle = 1;
    public Sound[] musics;
    //public static MusiqueManager Instance { get; private set; }


    private void Awake()
    {
        //if (Instance == null)
        //{
        //    Instance = this;
        //    DontDestroyOnLoad(this);
            
        //}
        //else
        //{
        //    Destroy(gameObject);
        //}
    }
    void Start()
    {
        foreach (Sound s in musics)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            //s.source.volume = GameObject.Find("SliderAudio").GetComponent<Slider>().value;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
            s.source.playOnAwake = s.playOnAwake;
            s.source.volume = s.volume;
        }
        SetVolume();
        PlayOnAwake();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
            FindObjectOfType<MusiqueManager>().Play("Them");
    }

    void PlayOnAwake()
    {
        for (int i = 0; i < musics.Length; i++)
        {
            if (musics[i].playOnAwake)
            {
                Play(musics[i].name);
            }
        }
    }

    public void Play(string name)
    {
        if(_volumeToggle == 1)
        {
            Sound s = Array.Find(musics, sound => sound.name == name);
            if (s == null)
                return;
            s.source.Play();
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
        SetVolume();
    }

    public void SetVolume()
    {
        foreach (Sound s in musics)
        {
            s.source.volume = _volumeToggle;
        }
    }
}