using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [HideInInspector] public Toggle _censuredToggle;
    [HideInInspector] public bool _isCensuredMod;
    [HideInInspector] public List<string> _savingDrawCardCard;

    private void Awake()
    {
        AttributionValeur();
    }


    void AttributionValeur()
    {
        FindObjectOfType<SaveAndLoad>().LoadPlayer();

        if (_savingDrawCardCard.Count < FindObjectOfType<SaveAndLoad>().alreadyDrawCards.Count)
        {
            _savingDrawCardCard = FindObjectOfType<SaveAndLoad>().alreadyDrawCards;
        }


        if (FindObjectOfType<ContainAllObjectTree>()._imageTreeUnlockSinceLastTime.Count < FindObjectOfType<SaveAndLoad>().unlockSinceLastTime.Count)
        {
            FindObjectOfType<ContainAllObjectTree>()._imageTreeUnlockSinceLastTime = FindObjectOfType<SaveAndLoad>().unlockSinceLastTime;
        }


        if (FindObjectOfType<ContainAllObjectTree>()._imageTreeChildAlreadyInTree.Count < FindObjectOfType<SaveAndLoad>().objectInTree.Count)
        {
            FindObjectOfType<ContainAllObjectTree>()._imageTreeChildAlreadyInTree = FindObjectOfType<SaveAndLoad>().objectInTree;
        }
    }

    

    public void LoadScene(int scene)
    {
        FindObjectOfType<SaveAndLoad>().SavePlayer();
        SceneManager.LoadScene(scene);
        FindObjectOfType<SaveAndLoad>().LoadPlayer();
    }
}
