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


    private void Start()
    {

        if(PlayerPrefs.HasKey("firstTime"))
        {
            if (MusiqueManager.Instance != null)
                MusiqueManager.Instance._toggleWhichChanges.isOn = options[0];
            else
                music.isOn = options[0];

            sound.isOn = options[1];
            censure.isOn = options[2];
        }
        else
        {
            music.isOn = true;
            sound.isOn = true;
            censure.isOn = true;
            PlayerPrefs.SetFloat("firstTime", 1f);
            PlayerPrefs.Save();
        }
       
        
    }

    public void TogglesID(int id)
    {
        togglesID = id;
    }

    public void ChangeToggles(Toggle toggle)
    {
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
            PauseMenuUI.SetActive(true);
            Time.timeScale = 0f;
            card.SetActive(false);
            GameIsPaused = true;
        }
        else
        {
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
        FindObjectOfType<SaveAndLoad>().LoadPlayer();
        string loadScene = "MenuModifVic";
        StartCoroutine(WaitForAnim(loadScene));

    }

    IEnumerator WaitForAnim(string loadScene)
    {
        TransitionScene _animMaster = FindObjectOfType<TransitionScene>();
        _animMaster.EndAnim();
        yield return new WaitForSeconds(_animMaster._animTime);
        SceneManager.LoadScene(loadScene);
    }
}
