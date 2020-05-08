using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class MainMenu : MonoBehaviour
{

    public GameObject achiev_EasyOnes;
    public GameObject achiev_Locked;
    public GameObject achiev_Unlocked;
    public GameObject UI_Achiev;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Play()
    {
        //SceneManager.LoadScene("Game");
        Debug.Log("Bouton Play");
    }

    public void Achievements()
    {
        UI_Achiev.SetActive(true);
    }

    public void Credits()
    {

    }
    public void Quit()
    {
        #if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
        #else
                        Application.Quit();
        #endif
    }

    public void Achievements_EasyOnes()
    { 
        achiev_EasyOnes.SetActive(true);
        achiev_Locked.SetActive(false);
        achiev_Unlocked.SetActive(false);
    }

    public void Achievements_Locked()
    {
        achiev_EasyOnes.SetActive(false);
        achiev_Locked.SetActive(true);
        achiev_Unlocked.SetActive(false);
    }

    public void Achievements_Unlocked()
    {
        achiev_EasyOnes.SetActive(false);
        achiev_Locked.SetActive(false);
        achiev_Unlocked.SetActive(true);
    }

    public void Achievements_Quit()
    {
        UI_Achiev.SetActive(false);
    }


}
