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
    public GameObject UI_Credits;
    public GameObject UI_MainMenu;

    public GameObject button_EasyOnes;
    public GameObject button_Unlocked;
    public GameObject button_Locked;
    public GameObject button_EasyOnesPressed;
    public GameObject button_UnlockedPressed;
    public GameObject button_LockedPressed;

    private bool easyOnes_pressed = false;
    private bool locked_pressed = true;
    private bool unlocked_pressed = true;

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
        UI_Credits.SetActive(true);
        UI_MainMenu.SetActive(false);
    }


    public void Achievements_EasyOnes()
    {
        achiev_EasyOnes.SetActive(true);
        achiev_Locked.SetActive(false);
        achiev_Unlocked.SetActive(false);

        button_Locked.SetActive(true);
        button_Unlocked.SetActive(true);

        button_LockedPressed.SetActive(false);
        button_UnlockedPressed.SetActive(false);

        if (easyOnes_pressed)
        {
            easyOnes_pressed = !easyOnes_pressed;
            button_EasyOnes.SetActive(false);
            button_EasyOnesPressed.SetActive(true);
            locked_pressed = true;
            unlocked_pressed = true;
}
        else
        {
            easyOnes_pressed = !easyOnes_pressed;
            button_EasyOnes.SetActive(true);
            button_EasyOnesPressed.SetActive(false);
        }
        
    }
    public void Achievements_Locked()
    {
        achiev_EasyOnes.SetActive(false);
        achiev_Locked.SetActive(true);
        achiev_Unlocked.SetActive(false);

        button_Unlocked.SetActive(true);
        button_EasyOnes.SetActive(true);

        button_EasyOnesPressed.SetActive(false);
        button_UnlockedPressed.SetActive(false);

        if (locked_pressed)
        {
            locked_pressed = !locked_pressed;
            button_Locked.SetActive(false);
            button_LockedPressed.SetActive(true);
            easyOnes_pressed = true;
            unlocked_pressed = true;
        }
        else
        {
            locked_pressed = !locked_pressed;
            button_Locked.SetActive(true);
            button_LockedPressed.SetActive(false);
            
        }
    }

    public void Achievements_Unlocked()
    {
        achiev_EasyOnes.SetActive(false);
        achiev_Locked.SetActive(false);
        achiev_Unlocked.SetActive(true);

        button_Locked.SetActive(true);
        button_EasyOnes.SetActive(true);

        button_EasyOnesPressed.SetActive(false);
        button_LockedPressed.SetActive(false);

        if (unlocked_pressed)
        {
            unlocked_pressed = !unlocked_pressed;
            button_Unlocked.SetActive(false);
            button_UnlockedPressed.SetActive(true);
            easyOnes_pressed = true;
            locked_pressed = true;
        }
        else
        {
            unlocked_pressed = !unlocked_pressed;
            button_Unlocked.SetActive(true);
            button_UnlockedPressed.SetActive(false);
        }
    }

    public void Achievements_Quit()
    {
        UI_Achiev.SetActive(false);
    }

    public void Main_Menu()
    {
        UI_MainMenu.SetActive(true);
    }


}
