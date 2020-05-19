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
    public List<string> apparitionOrder;


    public ContainAllObjectTree tree;
    public GameManager manage;
    public PauseMenu option;
    private CardValuesWithScriptable card;
    private SuccesManager succes;

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
    }

    public void SaveCards()
    {
        SaveSystem.SaveCards(card, succes);
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

        if (data.firstCardData != null)
        {
            //card._firstCardScriptable = Resources.Load<CardScriptableObject>("Resources/" + data.firstCardData + "/.asset");
            Debug.Log(data.firstCardData);
        }

            Debug.Log(succes);
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

        LoadCard();
        Debug.Log("load");
    }
}