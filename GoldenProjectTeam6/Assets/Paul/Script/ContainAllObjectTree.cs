﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContainAllObjectTree : MonoBehaviour
{
     public List<GameObject> _imageTreeChilds;
    //Save the following variable (_imageTreeChildAlreadyInTree)
     public List<bool> _imageTreeChildAlreadyInTree;

     public List<GameObject> _cardToReset;
    

    void Start()
    {
        Attribution();
    }

    void Update()
    {
        if ( Input.GetMouseButtonDown(0))
        {
            _cardToReset = _imageTreeChilds;
            for (int i = 0; i < _cardToReset.Count; i++)
            {
                _cardToReset[i].GetComponent<ImageArborescence>()._cardID._cardAlreadyDraw = false;
                Debug.Log(_cardToReset[i].GetComponent<ImageArborescence>()._cardID + " = " + _cardToReset[i].GetComponent<ImageArborescence>()._cardID._cardAlreadyDraw);
                _cardToReset[i].GetComponent<ImageArborescence>()._alreadyInTree = false;
                Debug.Log(_cardToReset[i].GetComponent<ImageArborescence>().name + " = " + _cardToReset[i].GetComponent<ImageArborescence>()._alreadyInTree);
            }
            Debug.Log("J'ai reset");
            _imageTreeChildAlreadyInTree.Clear();
            _imageTreeChilds.Clear();
            Attribution();
            
        }
    }

    void Attribution()
    {
        foreach (Transform child in transform)
        {
            _imageTreeChilds.Add(child.gameObject);
        }
        


        for (int i = 0; i < _imageTreeChilds.Count; i++)
        {
            _imageTreeChilds[i].GetComponent<ImageArborescence>()._idInParent = i;
            for (int j = 0; j < FindObjectOfType<GameManager>()._savingDrawCardCard.Count; j++)
            {
                if (FindObjectOfType<GameManager>()._savingDrawCardCard.Contains(_imageTreeChilds[i].GetComponent<ImageArborescence>()._cardID._title))
                {
                    Debug.Log("Bool " + j + " = " + FindObjectOfType<GameManager>()._savingDrawCardBool[j]);
                    _imageTreeChilds[i].GetComponent<ImageArborescence>()._alreadyDraw = FindObjectOfType<GameManager>()._savingDrawCardBool[j];
                }
                else
                {
                    Debug.Log("Je contiens pas");
                }
            }
        }
        
        FindObjectOfType<SaveAndLoad>().SavePlayer();
        
    }
}
