using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveAndLoad : MonoBehaviour
{
    public List<bool> objectInTree;
    public List<bool> alreadyDrawBool;
    public List<string> alreadyDrawCards;

    public ContainAllObjectTree tree;
    public GameManager manage;

    private void Start()
    {
        objectInTree = FindObjectOfType<ContainAllObjectTree>()._imageTreeChildAlreadyInTree;
        alreadyDrawBool = FindObjectOfType<GameManager>()._savingDrawCardBool;
        alreadyDrawCards = FindObjectOfType<GameManager>()._savingDrawCardCard;

    }


    public void SavePlayer()
    {
        Debug.Log(alreadyDrawBool.Count);
        SaveSystem.SaveScore(tree, manage);
    }

    public void LoadPlayer()
    {
        PlayerData data = SaveSystem.LoadPlayer();
        objectInTree = data.imageTreeData;

        alreadyDrawBool = data.savingDrawCardBoolData;
        alreadyDrawCards = data.savingDrawCardCardData;


        Debug.Log("load");

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