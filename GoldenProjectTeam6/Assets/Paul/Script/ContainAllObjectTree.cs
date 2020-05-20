using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContainAllObjectTree : MonoBehaviour
{
     public List<GameObject> _imageTreeChilds;
    //Save the following variable (_imageTreeChildAlreadyInTree)
     public List<string> _imageTreeChildAlreadyInTree;
     public List<string> _imageTreeUnlockSinceLastTime;

    public List<bool> _allCardFinishEvent;
    public List<bool> _allCardUnlock;



    void Start()
    {
        Attribution();
        StartCoroutine(VerifyingSuccess());
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

    IEnumerator VerifyingSuccess()
    {
        for (int i = 0; i < FindObjectOfType<OngletArboManager>()._listEvents.Count; i++)
        {
            _allCardFinishEvent.Add(false);
        }
        yield return new WaitForSeconds(2);

        int verifierFinish = 0;
        int verifierUnlock = 0;

        for (int i = 0; i < _imageTreeChilds.Count; i++)
        {
            _allCardUnlock.Add(false);

            if (_imageTreeChilds[i].gameObject.activeInHierarchy)
            {
                _allCardUnlock[i] = true;
                verifierUnlock++;

                if (_imageTreeChilds[i].GetComponent<ImageArborescence>()._cardID._isDeadCard)
                {
                    _allCardFinishEvent[_imageTreeChilds[i].GetComponent<ImageArborescence>()._idInList] = true;
                    verifierFinish++;
                }
            }
        }

        if(verifierFinish == _allCardFinishEvent.Count)
        {
            SuccesManager succesManager;
            succesManager = FindObjectOfType<SuccesManager>();
            if (succesManager.allTheSucces[10].locked)
                succesManager.UnlockSuccess(succesManager.allTheSucces[10].enumSucces);
        }
        if (verifierUnlock == _allCardUnlock.Count)
        {
            SuccesManager succesManager;
            succesManager = FindObjectOfType<SuccesManager>();
            if (succesManager.allTheSucces[2].locked)
                succesManager.UnlockSuccess(succesManager.allTheSucces[2].enumSucces);
        }
    }
}
