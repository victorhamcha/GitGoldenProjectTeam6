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
        firstCard = FindObjectOfType<CardValuesWithScriptable>()._firstCardScriptable.name;
    }


    public void SavePlayer()
    {
        SaveSystem.SaveScore(tree, manage, option, card);
        Debug.Log("save");
    }

    public void LoadPlayer()
    {
        PlayerData data = SaveSystem.LoadPlayer();

        objectInTree = data.imageTreeData;
        unlockSinceLastTime = data.imageTreeUnlockSinceLastTimeData;

        alreadyDrawCards = data.savingDrawCardCardData;

        saveOptions = data.optionsData;

        firstCard = data.firstCardData;

        Vector3 position;
        position.x = data.position2[0];
        position.y = data.position2[1];
        position.z = data.position2[2];
        transform.position = position;

        Vector3 position2;
        position2.x = data.position2[0];
        position2.y = data.position2[1];
        position2.z = data.position2[2];
        transform.position = position2;

        Vector3 position3;
        position3.x = data.position3[0];
        position3.y = data.position3[1];
        position3.z = data.position3[2];
        transform.position = position3;

        Vector3 position4;
        position4.x = data.position4[0];
        position4.y = data.position4[1];
        position4.z = data.position4[2];
        transform.position = position4;

        Debug.Log("load");
    }
}