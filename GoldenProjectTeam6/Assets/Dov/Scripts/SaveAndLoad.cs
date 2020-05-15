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
    private CardValuesWithScriptable card;

    void Start()
    {
        objectInTree = FindObjectOfType<ContainAllObjectTree>()._imageTreeChildAlreadyInTree;
        unlockSinceLastTime = FindObjectOfType<ContainAllObjectTree>()._imageTreeUnlockSinceLastTime;
        alreadyDrawCards = FindObjectOfType<GameManager>()._savingDrawCardCard;
        saveOptions = FindObjectOfType<PauseMenu>().options;
        //firstCard = FindObjectOfType<CardValuesWithScriptable>()._firstCardScriptable.name;
    }

    public void SaveCards()
    {
        SaveSystem.SaveCards(card);
    }

    public void SavePlayer()
    {
        SaveSystem.SavePlayer(tree, manage, option);
        SaveCards();
        Debug.Log("save");
    }


    public void LoadCard()
    {
        CardsData data = SaveSystem.LoadCards();

        foreach (CardValuesWithScriptable cvws in FindObjectsOfType<CardValuesWithScriptable>())
        {
            if (cvws.name == data.firstCardData)
            {
                card = cvws;
                break;
            }
        }

        Debug.Log("load card");
    }

    public void LoadPlayer()
    {
        PlayerData data = SaveSystem.LoadPlayer();

        objectInTree = data.imageTreeData;
        unlockSinceLastTime = data.imageTreeUnlockSinceLastTimeData;

        alreadyDrawCards = data.savingDrawCardCardData;

        saveOptions = data.optionsData;

        LoadCard();
        Debug.Log("load");
    }
}