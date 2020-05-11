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
    [HideInInspector] public List<bool> _savingDrawCardBool;

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

        if (_savingDrawCardBool.Count < FindObjectOfType<SaveAndLoad>().alreadyDrawBool.Count)
        {
            _savingDrawCardBool = FindObjectOfType<SaveAndLoad>().alreadyDrawBool;
        }
        if (FindObjectOfType<ContainAllObjectTree>()._imageTreeChildAlreadyInTree.Count < FindObjectOfType<SaveAndLoad>().objectInTree.Count)
        {
            FindObjectOfType<ContainAllObjectTree>()._imageTreeChildAlreadyInTree = FindObjectOfType<SaveAndLoad>().objectInTree;
        }
    }

    public void ChangeToggle()
    {
        if (_censuredToggle.isOn)
        {
            _isCensuredMod = true;
        }
        else
        {
            _isCensuredMod = false;
        }
    }

    public void LoadScene(int scene)
    {
        FindObjectOfType<SaveAndLoad>().SavePlayer();
        SceneManager.LoadScene(scene);
        FindObjectOfType<SaveAndLoad>().LoadPlayer();
    }
}
