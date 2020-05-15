using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveAndLoad : MonoBehaviour
{
    public List<string> objectInTree;
    public List<string> alreadyDrawCards;
    public List<string> unlockSinceLastTime;
    public List<bool> saveOptions;
    public string firstCard;


    public ContainAllObjectTree tree;
    public GameManager manage;
    public PauseMenu option;
    public CardValuesWithScriptable card;

    void Start()
    {
        objectInTree = FindObjectOfType<ContainAllObjectTree>()._imageTreeChildAlreadyInTree;
        unlockSinceLastTime = FindObjectOfType<ContainAllObjectTree>()._imageTreeUnlockSinceLastTime;
        alreadyDrawCards = FindObjectOfType<GameManager>()._savingDrawCardCard;
        saveOptions = FindObjectOfType<PauseMenu>().options;
        //firstCard = FindObjectOfType<CardValuesWithScriptable>()._firstCardScriptable.name;
    }


    public void SavePlayer()
    {
        SaveSystem.SaveScore(tree, manage, option, card);
        Debug.Log("save");
    }

    public void LoadCard()
    {
        PlayerData data = SaveSystem.LoadPlayer();

        firstCard = data.firstCardData;

        Debug.Log("load card");
    }

    public void LoadPlayer()
    {
        PlayerData data = SaveSystem.LoadPlayer();

        objectInTree = data.imageTreeData;
        unlockSinceLastTime = data.imageTreeUnlockSinceLastTimeData;

        alreadyDrawCards = data.savingDrawCardCardData;

        saveOptions = data.optionsData;


        Debug.Log("load");
    }
}