using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio : MonoBehaviour
{
    public AudioClip _mainMenuButton;
    public AudioSource _audioSource;


    // Start is called before the first frame update
    void Start()
    {
      
    }

    public void MainMenuButton()
    {
        _audioSource.clip = _mainMenuButton;
        _audioSource.Play();
    }
}
