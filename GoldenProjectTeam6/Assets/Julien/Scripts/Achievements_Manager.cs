using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Achievements_Manager : MonoBehaviour
{
    static bool IsSuccess1Unlocked = false;
    static bool IsSuccess2Unlocked = false;
    static bool IsSuccess3Unlocked = false;
    static bool IsSuccess4Unlocked = false;
    static bool IsSuccess5Unlocked = false;
    static bool IsSuccess6Unlocked = false;
    static bool IsSuccess7Unlocked = false;
    static bool IsSuccess8Unlocked = false;
    static bool IsSuccess9Unlocked = false;
    static bool IsSuccess10Unlocked = false;
    static bool IsSuccess11Unlocked = false;
    static bool IsSuccess12Unlocked = false;
    static bool IsSuccess13Unlocked = false;
    static bool IsSuccess14Unlocked = false;
    static bool IsSuccess15Unlocked = false;
    static bool IsSuccess16Unlocked = false;
    static bool IsSuccess17Unlocked = false;
    static bool IsSuccess18Unlocked = false;
    static bool IsSuccess19Unlocked = false;
    static bool IsSuccess20Unlocked = false;

   public List<GameObject> Achievements = new List<GameObject>();
   public List<bool> Booleens = new List<bool>();

    private RectTransform rect;
    public GameObject sizeReference;

    public int nbSuccess = 0;

    // Start is called before the first frame update
    void Start()
    {
        rect = this.GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        // Resizing du rect transform des achievements suivant combien il y a d'achievements
        //rect.sizeDelta = new Vector2(rect.sizeDelta.x,(sizeReference.GetComponent<RectTransform>().sizeDelta.y + this.GetComponent<VerticalLayoutGroup>().spacing) * (nbSuccess));
        

        for(int i = 0; i < Booleens.Count; i++)
        {
            // Si succès unlocked
            if(Booleens[i])
            {
                if(!Achievements[i].activeInHierarchy)
                {  
                    nbSuccess++;
                    Achievements[i].SetActive(true);
                    
                }            
            }
            else
            { 
                Achievements[i].SetActive(false);
            }
        }

    }
}
