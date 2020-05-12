using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveAndLoad : MonoBehaviour
{
     public List<string> objectInTree;
     public List<string> alreadyDrawCards;
     public List<string> unlockSinceLastTime;

    public ContainAllObjectTree tree;
    public GameManager manage;

    void Start()
    {
        objectInTree = FindObjectOfType<ContainAllObjectTree>()._imageTreeChildAlreadyInTree;
        unlockSinceLastTime = FindObjectOfType<ContainAllObjectTree>()._imageTreeUnlockSinceLastTime;
        alreadyDrawCards = FindObjectOfType<GameManager>()._savingDrawCardCard;
    }


    public void SavePlayer()
    {
        SaveSystem.SaveScore(tree, manage);
    }

    public void LoadPlayer()
    {
        PlayerData data = SaveSystem.LoadPlayer();

        objectInTree = data.imageTreeData;
        unlockSinceLastTime = data.imageTreeUnlockSinceLastTimeData;

        alreadyDrawCards = data.savingDrawCardCardData;


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
    }
}