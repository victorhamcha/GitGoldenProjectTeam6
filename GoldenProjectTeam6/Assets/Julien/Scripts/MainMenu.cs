using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class MainMenu : MonoBehaviour
{

    //public GameObject achiev_EasyOnes;
    //public GameObject achiev_Locked;
    //public GameObject achiev_Unlocked;
    public GameObject UI_Achiev;
    public GameObject UI_Credits;
    public GameObject UI_MainMenu;
    private bool loadingScene = false;

    //public GameObject button_EasyOnes;
    //public GameObject button_Unlocked;
    //public GameObject button_Locked;
    //public GameObject button_EasyOnesPressed;
    //public GameObject button_UnlockedPressed;
    //public GameObject button_LockedPressed;

    private bool menu=true;

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
       // SceneManager.LoadScene("GeneralScene");
       if(!loadingScene)
        StartCoroutine(LoadYourAsyncScene("GeneralScene"));
    }

    public void Arbo()
    {
        //SceneManager.LoadScene("BaptisteTestArbo");
        if (!loadingScene)
            StartCoroutine(LoadYourAsyncScene("BaptisteTestArbo"));
    }
    public void Tuto()
    {
        SwipeScript.isTuto = true;
        //SceneManager.LoadScene("BaptisteTestArbo");
        if (!loadingScene)
            StartCoroutine(LoadYourAsyncScene("GeneralScene"));
    }

    public void Achievements()
    {
        if(menu)
        {
            UI_Achiev.SetActive(true);
            UI_MainMenu.SetActive(false);
            menu = false;
        }
        else
        {
            UI_Achiev.SetActive(false);
            UI_MainMenu.SetActive(true);
            menu = true;
        }
      
    }

    public void Credits()
    {
        if (menu)
        {
            menu = false;
            StartCoroutine(WaitAnimCreditOn());
        }
        else
        {
            menu = true;
            StartCoroutine(WaitAnimCreditOff());

        }

    }

    IEnumerator WaitAnimCreditOn()
    {
        TransitionScene _animMaster = FindObjectOfType<TransitionScene>();
        _animMaster.EndAnim();
        yield return new WaitForSeconds(_animMaster._animTime);
        //UI_Credits.SetActive(true);
        //UI_MainMenu.SetActive(false);
        SceneManager.LoadScene("TestCardJulien");
        yield return new WaitForSeconds(_animMaster._animTime);
        _animMaster.StartAnim();
    }

    IEnumerator WaitAnimCreditOff()
    {
        TransitionScene _animMaster = FindObjectOfType<TransitionScene>();
        _animMaster.EndAnim();
        yield return new WaitForSeconds(_animMaster._animTime);
        //UI_Credits.SetActive(false);
        //UI_MainMenu.SetActive(true);
        SceneManager.LoadScene("MenuModifVic");
        yield return new WaitForSeconds(_animMaster._animTime);
        _animMaster.StartAnim();
    }


    //    public void Achievements_EasyOnes()
    //    {
    //        achiev_EasyOnes.SetActive(true);
    //        achiev_Locked.SetActive(false);
    //        achiev_Unlocked.SetActive(false);

    //        button_Locked.SetActive(true);
    //        button_Unlocked.SetActive(true);

    //        button_LockedPressed.SetActive(false);
    //        button_UnlockedPressed.SetActive(false);

    //        if (easyOnes_pressed)
    //        {
    //            easyOnes_pressed = !easyOnes_pressed;
    //            button_EasyOnes.SetActive(false);
    //            button_EasyOnesPressed.SetActive(true);
    //            locked_pressed = true;
    //            unlocked_pressed = true;
    //}
    //        else
    //        {
    //            easyOnes_pressed = !easyOnes_pressed;
    //            button_EasyOnes.SetActive(true);
    //            button_EasyOnesPressed.SetActive(false);
    //        }

    //    }
    //    public void Achievements_Locked()
    //    {
    //        achiev_EasyOnes.SetActive(false);
    //        achiev_Locked.SetActive(true);
    //        achiev_Unlocked.SetActive(false);

    //        button_Unlocked.SetActive(true);
    //        button_EasyOnes.SetActive(true);

    //        button_EasyOnesPressed.SetActive(false);
    //        button_UnlockedPressed.SetActive(false);

    //        if (locked_pressed)
    //        {
    //            locked_pressed = !locked_pressed;
    //            button_Locked.SetActive(false);
    //            button_LockedPressed.SetActive(true);
    //            easyOnes_pressed = true;
    //            unlocked_pressed = true;
    //        }
    //        else
    //        {
    //            locked_pressed = !locked_pressed;
    //            button_Locked.SetActive(true);
    //            button_LockedPressed.SetActive(false);

    //        }
    //    }

    //    public void Achievements_Unlocked()
    //    {
    //        achiev_EasyOnes.SetActive(false);
    //        achiev_Locked.SetActive(false);
    //        achiev_Unlocked.SetActive(true);

    //        button_Locked.SetActive(true);
    //        button_EasyOnes.SetActive(true);

    //        button_EasyOnesPressed.SetActive(false);
    //        button_LockedPressed.SetActive(false);

    //        if (unlocked_pressed)
    //        {
    //            unlocked_pressed = !unlocked_pressed;
    //            button_Unlocked.SetActive(false);
    //            button_UnlockedPressed.SetActive(true);
    //            easyOnes_pressed = true;
    //            locked_pressed = true;
    //        }
    //        else
    //        {
    //            unlocked_pressed = !unlocked_pressed;
    //            button_Unlocked.SetActive(true);
    //            button_UnlockedPressed.SetActive(false);
    //        }
    //    }

    //    public void Achievements_Quit()
    //    {
    //        UI_Achiev.SetActive(false);
    //        UI_MainMenu.SetActive(true);
    //    }

    public void Load_Menu()
    {
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

    IEnumerator LoadYourAsyncScene(string scene)
    {
        loadingScene = true;

        TransitionScene _animMaster = FindObjectOfType<TransitionScene>();
        _animMaster.EndAnim();
        yield return new WaitForSeconds(_animMaster._animTime);
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(scene);

        // Wait until the asynchronous scene fully loads
        while (!asyncLoad.isDone)
        {
            yield return null;
        }
    }
}
