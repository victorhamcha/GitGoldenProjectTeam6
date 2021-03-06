﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [HideInInspector] public Toggle _censuredToggle;
    [HideInInspector] public bool _isCensuredMod;
    [HideInInspector] public List<string> _savingDrawCardCard;
    public List<string> _apparitionOrder;

    public bool inGame;

    private void Awake()
    {
        AttributionValeur();
    }

    private void OnApplicationQuit()
    {
        FindObjectOfType<SaveAndLoad>().SavePlayer();
    }

    void AttributionValeur()
    {
        if (inGame)
        {
            FindObjectOfType<SaveAndLoad>().LoadCard();
            if (SceneManager.GetActiveScene().name == "GeneralScene")
            {
                MusiqueManager.Instance.Play("RainSound");
            }
           
        }
        FindObjectOfType<SaveAndLoad>().LoadPlayer();

        if (SceneManager.GetActiveScene().name == "BaptisteTestArbo")
        {

        }
        else
        {

        }

        if (_savingDrawCardCard.Count < FindObjectOfType<SaveAndLoad>().alreadyDrawCards.Count)
        {
            _savingDrawCardCard = FindObjectOfType<SaveAndLoad>().alreadyDrawCards;
        }


        if (FindObjectOfType<ContainAllObjectTree>()._imageTreeUnlockSinceLastTime.Count < FindObjectOfType<SaveAndLoad>().unlockSinceLastTime.Count)
        {
            FindObjectOfType<ContainAllObjectTree>()._imageTreeUnlockSinceLastTime = FindObjectOfType<SaveAndLoad>().unlockSinceLastTime;
        }


        if (FindObjectOfType<ContainAllObjectTree>()._imageTreeChildAlreadyInTree.Count < FindObjectOfType<SaveAndLoad>().objectInTree.Count)
        {
            FindObjectOfType<ContainAllObjectTree>()._imageTreeChildAlreadyInTree = FindObjectOfType<SaveAndLoad>().objectInTree;
        }

        FindObjectOfType<PauseMenu>().options = FindObjectOfType<SaveAndLoad>().saveOptions;

        _apparitionOrder = FindObjectOfType<SaveAndLoad>().apparitionOrder;
        
    }

    

    public void LoadScene(int scene)
    {
        MusiqueManager.Instance.Stop("RainSound");
        FindObjectOfType<SaveAndLoad>().SavePlayer();
        SceneManager.LoadScene(scene);
        FindObjectOfType<SaveAndLoad>().LoadPlayer();
    }
}
