﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SaveAndLoad : MonoBehaviour
{
    public List<string> objectInTree;
    public List<string> alreadyDrawCards;
    public List<string> unlockSinceLastTime;
    public List<bool> saveOptions;
    public string firstCard;
    public List<string> apparitionOrder;


    public ContainAllObjectTree tree;
    public GameManager manage;
    public PauseMenu option;
    private CardValuesWithScriptable card;
    private SuccesManager succes;
    private ContratsPanel contrats;

    private void Awake()
    {
        succes = FindObjectOfType<SuccesManager>();
    }

    void Start()
    {
        objectInTree = FindObjectOfType<ContainAllObjectTree>()._imageTreeChildAlreadyInTree;
        unlockSinceLastTime = FindObjectOfType<ContainAllObjectTree>()._imageTreeUnlockSinceLastTime;
        alreadyDrawCards = FindObjectOfType<GameManager>()._savingDrawCardCard;
        apparitionOrder = FindObjectOfType<GameManager>()._apparitionOrder;
        saveOptions = FindObjectOfType<PauseMenu>().options;
        card = FindObjectOfType<CardValuesWithScriptable>();
        contrats = FindObjectOfType<ContratsPanel>();
    }

    public void SaveCards()
    {
        
            
            SaveSystem.SaveCards(card, succes);
            if(!PlayerPrefs.HasKey("firstsucces"))
            {
            PlayerPrefs.SetFloat("firstsucces", 1f);
            }
                
    }

    public void SavePlayer()
    {
        SaveSystem.SavePlayer(tree, manage, option);
        SaveCards();
        Debug.Log("save");
    }

    public void SavePassport()
    {
        SaveSystem.SavePassport(contrats);
        Debug.Log("savePassport");
    }

    public void LoadPassport()
    {
        PassportData data = SaveSystem.LoadPassport();
        Debug.Log("loadpasseport");
        contrats.changeMat = data.materialIndexData;
        contrats.nameText =  data.nameData;
        contrats.countryText = data.countryData;
        Debug.Log(data.nameData);
        contrats.skinTXT.text = contrats.skinName[data.materialIndexData];
    }

    public void LoadCard()
    {
        CardsData data = SaveSystem.LoadCards();

    


        if (succes == null)
        {
            succes = FindObjectOfType<SuccesManager>();
        }
        if (data.allSuccesData != null)
        {
            succes.lockInfo = data.allSuccesData;
        }

    }

    public void LoadPlayer()
    {
        PlayerData data = SaveSystem.LoadPlayer();

        objectInTree = data.imageTreeData;
        unlockSinceLastTime = data.imageTreeUnlockSinceLastTimeData;

        alreadyDrawCards = data.savingDrawCardCardData;
        apparitionOrder = data.apparationOrderData;

        
        saveOptions = data.optionsData;
       
        if(PlayerPrefs.HasKey("firstsucces"))
        LoadCard();

    }
}