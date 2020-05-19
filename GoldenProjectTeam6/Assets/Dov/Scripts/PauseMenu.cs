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
    private int togglesID;


    private void Start()
    {
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
        options[togglesID] = toggle.isOn;
        FindObjectOfType<SaveAndLoad>().SavePlayer();
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
            PauseMenuUI.SetActive(true);
            Time.timeScale = 0f;
            GameIsPaused = true;
        }
        else
        {
            PauseMenuUI.SetActive(false);
            Time.timeScale = 1f;
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
