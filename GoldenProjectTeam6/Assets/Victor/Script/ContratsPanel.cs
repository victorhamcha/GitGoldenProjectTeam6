﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ContratsPanel : MonoBehaviour
{
    [Header("Panel Settings")]
    public Swiping androidControl;
    public int page = 0;
    public TextMeshProUGUI txtPanel;

    [Header("Succes Settings")]
    public List<Succes> lockSucces = new List<Succes>();
    public List<Succes> unlockSucces = new List<Succes>();
    public Transform startPosition;
    public Transform unlock;
    public Transform locked;
    public Transform passeport;
    public float space;

    //BAR//
    [Header("Bar Settings")]
    public int progress;
    public int lvl;
    public Transform bar;
    public Transform barBG;
    public TextMeshProUGUI prctBar;
    public TextMeshProUGUI statusTMP;
    public Image imgCharacter;
    public string[] statuttxt = new string[5];
    public Sprite[] imgLvl = new Sprite[5];
    public Color[] colorLvl = new Color[5];
    private void Awake()
    {
        StartCoroutine(waitSucces());
    }

    void Start()
    {
        //parameters
        int succesCount = lockSucces.Count + unlockSucces.Count;
        progress = unlockSucces.Count * 100 / succesCount;
        lvl = progress / 20;
        int progressLVL = (((progress - lvl * 20)*100)/20);
        
        //bar UI
        bar.localScale = new Vector3((progressLVL / 100f)*barBG.localScale.x,barBG.localScale.y,barBG.localScale.z);
        prctBar.text = progressLVL.ToString()+"%";
        bar.GetComponentInChildren<Image>().color = new Color(colorLvl[lvl].r, colorLvl[lvl].g, colorLvl[lvl].b, colorLvl[lvl].a);
        //character UI
        statusTMP.text = "status : " + statuttxt[lvl];
        imgCharacter.sprite = imgLvl[lvl];

    }

    // Update is called once per frame
    void Update()
    {
       
        
        if (androidControl.SwipeLeft)
        {
            page--;
        }
        else if (androidControl.SwipeRight)
        {
            page++;
        }

        switch(page)
        {
           case -1:
           {
             page = 2;

             break;
           }
           case 0:
          {
            txtPanel.text = "Passeport";
                    locked.gameObject.SetActive(false);
                    unlock.gameObject.SetActive(false);
                    passeport.gameObject.SetActive(true);
                    break;
          }

            case 1:
           {
              txtPanel.text = "Lock Contract";
                    locked.gameObject.SetActive(true);
                    unlock.gameObject.SetActive(false);
                    passeport.gameObject.SetActive(false);
                    break;
           }

            case 2:
           {
            txtPanel.text = "Succed Contract";

                    locked.gameObject.SetActive(false);
                    passeport.gameObject.SetActive(false);
                    unlock.gameObject.SetActive(true);
                    break;
           }
            case 3:
          {
            page = 0;

            break;
          }
        }
    }

   

    IEnumerator waitSucces()
    {
        yield return new WaitForSeconds(0.01f);
        unlockSucces.Reverse();
        lockSucces.Reverse();
        for (int i = 0; i < unlockSucces.Count; i++)
        {
            unlockSucces[i].transform.SetParent(unlock);
            unlockSucces[i].transform.localPosition = new Vector2(0, startPosition.position.y+ 475 - space * (i));
        }
        for (int i = 0; i < lockSucces.Count; i++)
        {
            lockSucces[i].transform.SetParent(locked);
            lockSucces[i].transform.localPosition = new Vector2(0, startPosition.position.y+ 475 - space * (i));
        }
    }
}