using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public GameObject PauseMenuUI;
    public List<bool> options;
    public Toggle music, sound, censure;
    public GameObject card;
    private int togglesID;

    [HideInInspector] public AudioManager audioManager;


    private void Start()
    {
        audioManager = FindObjectOfType<AudioManager>();

        if (MusiqueManager.Instance != null)
            MusiqueManager.Instance._toggleWhichChanges.isOn = options[0];
        else
            music.isOn = options[0];
        
        sound.isOn = options[1];
        censure.isOn = options[2];
        
    }

    public void TogglesID(int id)
    {
        togglesID = id;
    }

    public void ChangeToggles(Toggle toggle)
    {
        if(toggle.isOn)
        {
            audioManager.Play("SFX_Toggle01");
            Debug.Log("go 1");
        }
        else
        {
            Debug.Log("go 2");
            audioManager.Play("SFX_Toggle02");
        }

        options[togglesID] = toggle.isOn;
        FindObjectOfType<SaveAndLoad>().SavePlayer();
        MusiqueManager.Instance.ChangeToggle();
       // AudioManager.Instance.ChangeToggle();
    }

    public void Resume()
    {
        PauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    public void Pause()
    {
        if(!GameIsPaused)
        {
            audioManager.Play("SFX_Button01");
            PauseMenuUI.SetActive(true);
            Time.timeScale = 0f;
            card.SetActive(false);
            GameIsPaused = true;
        }
        else
        {
            audioManager.Play("SFX_Button01");
            PauseMenuUI.SetActive(false);
            Time.timeScale = 1f;
            card.SetActive(true);
            GameIsPaused = false;
        }
       
    }

    public void LoadMenu()
    {
        Time.timeScale = 1f;
        FindObjectOfType<SaveAndLoad>().SavePlayer();
        SceneManager.LoadScene("MenuModifVic");
        FindObjectOfType<SaveAndLoad>().LoadPlayer();
    }
}
