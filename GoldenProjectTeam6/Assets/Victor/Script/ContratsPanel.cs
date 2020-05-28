using System.Collections;
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
    public TextMeshProUGUI txtPage;

    [Header("Succes Settings")]
    public List<Succes> lockSucces = new List<Succes>();
    public List<Succes> unlockSucces = new List<Succes>();
    public RectTransform startPosition;
    public Transform unlock;
    public Transform locked;
    public Transform passeport;
    public float space;
    public ScrollRect scroller;

    //BAR//
    [Header("Bar Settings")]
    public int progress;
    public int lvl;
    public Transform bar;
    public Transform barBG;
    public TextMeshProUGUI prctBar;
    public TextMeshProUGUI statusTMP;
    public TextMeshProUGUI LevelTXT;
    public Image imgCharacter;
    public string[] statuttxt = new string[5];
    public Sprite[] imgLvl = new Sprite[5];
    public Color[] colorLvl = new Color[5];

    //Skin
    public Material[] skinLvl = new Material[5];
    public string[] skinName = new string[5];
    public int changeMat=0;
    public TextMeshProUGUI skinTXT;

    //Name
    public TMP_InputField nameTXT;
    public string nameText;
    //Country
    public TMP_InputField CountryTXT;
    public string countryText;
    private void Awake()
    {
        
    }

    void Start()
    {
        StartCoroutine(waitSucces());
        SwipeModif();
    }

    // Update is called once per frame
    void Update()
    {
       
        
        if (androidControl.SwipeLeft)
        {
            page--;
            scroller.enabled = false;
            if(page==-1)
            {
                page = 2;
            }
            SwipeModif();
        }
        else if (androidControl.SwipeRight)
        {
            page++;
            scroller.enabled = false;
            if (page==3)
            {
                page = 0;
            }
            SwipeModif();
        }

       
    }


    public void SwipeModif()
    {
        switch (page)
        {
            case -1:
                {
                    page = 2;

                    break;
                }
            case 0:
                {
                    txtPanel.text = "Passport";
                    locked.gameObject.SetActive(false);
                    unlock.gameObject.SetActive(false);
                    passeport.gameObject.SetActive(true);
                    scroller.content = null;
                    break;
                }

            case 1:
                {
                    txtPanel.text = "Locked Contracts";
                    scroller.enabled = true;
                    locked.gameObject.SetActive(true);
                    unlock.gameObject.SetActive(false);
                    passeport.gameObject.SetActive(false);
                    scroller.content = locked.GetComponent<RectTransform>();
                    break;
                }

            case 2:
                {
                    txtPanel.text = "Unlocked Contracts";
                    scroller.enabled = true;
                    locked.gameObject.SetActive(false);
                    passeport.gameObject.SetActive(false);
                    unlock.gameObject.SetActive(true);
                    scroller.content = unlock.GetComponent<RectTransform>();
                    break;
                }
            case 3:
                {
                    page = 0;

                    break;
                }

        }

        txtPage.text = "Page " + (page + 1) + "/3";
    }
    public void SaveModif()
    {
        FindObjectOfType<SaveAndLoad>().SavePassport();
    }
   

    IEnumerator waitSucces()
    {
        yield return new WaitForSeconds(0.015f);
       
        float height = lockSucces.Count * (space)+400;
        Debug.Log(height);
        float height2 = unlockSucces.Count * (space)+400;
        Debug.Log(height2);
        unlockSucces.Reverse();
        lockSucces.Reverse();
        for (int i = 0; i < unlockSucces.Count; i++)
        {
            unlockSucces[i].transform.SetParent(unlock);
            unlockSucces[i].GetComponent<RectTransform>().anchoredPosition= new Vector2(0, startPosition.offsetMax.y - (space * (i))  - (80.9f * 7.5f));
            
        }
        for (int i = 0; i < lockSucces.Count; i++)
        {
            lockSucces[i].transform.SetParent(locked);
            lockSucces[i].GetComponent<RectTransform>().anchoredPosition = new Vector2(0, startPosition.offsetMax.y - (space * (i)) -(80.9f*7.5f));
        }

        //parameters
        int succesCount = lockSucces.Count + unlockSucces.Count;
        progress = unlockSucces.Count * 100 / succesCount;
        lvl = progress / 20;
        int progressLVL = (((progress - lvl * 20) * 100) / 20);

        if(lvl>4)
        {
            lvl = 4;
            progressLVL = 100;
        }

        //bar UI
        bar.localScale = new Vector3((progressLVL / 100f) * barBG.localScale.x, barBG.localScale.y, barBG.localScale.z);
        prctBar.text = progressLVL.ToString() + "%";
        LevelTXT.text = "Level : " + (lvl + 1);
        bar.GetComponentInChildren<Image>().color = new Color(colorLvl[lvl].r, colorLvl[lvl].g, colorLvl[lvl].b, colorLvl[lvl].a);
        //character UI
        statusTMP.text = statuttxt[lvl];
        imgCharacter.sprite = imgLvl[lvl];
        //LoadPassport
        SuccesManager.cardSkin = skinLvl[changeMat];

        if (countryText == "")
        {
            countryText = "Insert Country";
            CountryTXT.text = "Insert Name";
        }
        if (nameText == "")
        {
            nameText = "Insert Name";
            nameTXT.text = "Insert Name";
        }
        CountryTXT.text = countryText;
        nameTXT.text = nameText;
        FindObjectOfType<SaveAndLoad>().LoadPassport();
        if(countryText=="")
        {
            countryText = "Insert Country";
            CountryTXT.text = "Insert Name";
        }
        if(nameText=="")
        {
           nameText = "Insert Name";
            nameTXT.text = "Insert Name";
        }
        CountryTXT.text = countryText;
        nameTXT.text = nameText;
        SuccesManager.cardSkin = skinLvl[changeMat];
        imgCharacter.material = skinLvl[changeMat];


    }


    public void ChangeSkin(int i)
    {
       
        changeMat += i;
        if(changeMat> lvl)
        {
            changeMat = 0;
        }
        else if (changeMat<0)
        {
            changeMat = lvl;
        }
        skinTXT.text = skinName[changeMat];
        SuccesManager.cardSkin = skinLvl[changeMat];
        imgCharacter.material= skinLvl[changeMat];
        imgCharacter.material.SetFloat("Menu", 1);
        FindObjectOfType<GyroscopeManager>().collector= skinLvl[changeMat];
    }

    private void OnApplicationQuit()
    {
        FindObjectOfType<SaveAndLoad>().SavePassport();
    }
}
