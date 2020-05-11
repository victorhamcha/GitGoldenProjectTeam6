using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [HideInInspector] public Toggle _censuredToggle;
    [HideInInspector] public bool _isCensuredMod;
    public List<string> _savingDrawCardCard;
    public List<bool> _savingDrawCardBool;

    private void Start()
    {
        FindObjectOfType<SaveAndLoad>().LoadPlayer();
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
        SceneManager.LoadScene(scene);
    }
}
