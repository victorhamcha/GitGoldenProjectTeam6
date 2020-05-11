using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [HideInInspector] public Toggle _censuredToggle;
    [HideInInspector] public bool _isCensuredMod;
    public List<string> _savingDrawCardCard;
    public List<bool> _savingDrawCardBool;

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
}
