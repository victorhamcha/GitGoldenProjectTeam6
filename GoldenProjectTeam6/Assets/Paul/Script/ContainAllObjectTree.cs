using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContainAllObjectTree : MonoBehaviour
{
     public List<GameObject> _imageTreeChilds;
    //Save the following variable (_imageTreeChildAlreadyInTree)
     public List<string> _imageTreeChildAlreadyInTree;
     public List<string> _imageTreeUnlockSinceLastTime;


    void Start()
    {
        Attribution();
    }

    void Update()
    {
        if ( Input.GetMouseButtonDown(1))
        {
            
            _imageTreeChildAlreadyInTree.Clear();
            _imageTreeChilds.Clear();
            _imageTreeUnlockSinceLastTime.Clear();
            Attribution();
            
        }
    }

    void Attribution()
    {
        foreach (Transform child in transform)
        {
            _imageTreeChilds.Add(child.gameObject);
        }

        for (int i = 0; i < FindObjectOfType<GameManager>()._apparitionOrder.Count; i++)
        {
            foreach (Transform child in transform)
            {
                if(child.GetComponent<ImageArborescence>()._cardID.name == FindObjectOfType<GameManager>()._apparitionOrder[i])
                {
                    child.GetComponent<ImageArborescence>()._ordreList = i;
                }
            }
        }

        //for (int i = 0; i < _imageTreeChilds.Count; i++)
        //{
        //    _imageTreeChilds[i].GetComponent<ImageArborescence>()._idInParent = i;
        //    for (int j = 0; j < FindObjectOfType<GameManager>()._savingDrawCardCard.Count; j++)
        //    {
        //        if (FindObjectOfType<GameManager>()._savingDrawCardCard.Contains(_imageTreeChilds[i].GetComponent<ImageArborescence>()._cardID._title))
        //        {
        //            Debug.Log("Bool " + j + " = " + FindObjectOfType<GameManager>()._savingDrawCardBool[j]);
        //            _imageTreeChilds[i].GetComponent<ImageArborescence>()._alreadyDraw = FindObjectOfType<GameManager>()._savingDrawCardBool[j];
        //        }
        //        else
        //        {
        //            Debug.Log("Je contiens pas");
        //        }
        //    }
        //}
        
        FindObjectOfType<SaveAndLoad>().SavePlayer();
        
    }
}
