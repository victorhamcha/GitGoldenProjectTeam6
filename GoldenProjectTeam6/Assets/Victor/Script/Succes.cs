using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class Succes : MonoBehaviour
{

    public string id;
    //DIffiuclité
    public enum difficulté { TrèsFacile, Facile,Moyen,Difficile, TrèsDifficile };
    public difficulté _difficulté;
    public EnumSuccess._enumSuccess enumSucces;
    public bool locked=true;
   
    //TXT
    public string txtTitre;
    public string txtDescription;

    //UI in menu scene
    private ContratsPanel manager;
    private TextMeshProUGUI description;
    private TextMeshProUGUI titre;
    private Image img;
   //public Sprite succesIMG;
    //verify scene
    private bool inMenu=false;
    private void Awake()
    {
        
     
    
      
    }
    private void Start()
    {
        if (SceneManager.GetActiveScene().name == "MenuModifVic")
        {
            inMenu = true;
        }
        if (inMenu)
        {
            //text
            description = GetComponentsInChildren<TextMeshProUGUI>()[1];
            titre = GetComponentsInChildren<TextMeshProUGUI>()[0];

            titre.text = txtTitre;
            ////////////////////////////////////////////////////////////
            img = GetComponentInChildren<Image>();


            manager = GetComponentInParent<ContratsPanel>();
            StartCoroutine(waitForLoading());
        }
    }
    private void Update()
    {
      
    }

    IEnumerator waitForLoading()
    {
        yield return new WaitForSeconds(0.01f);
        if (!locked)
        {
            manager.unlockSucces.Add(this);
            description.text = txtDescription;
        }
        else
        {
            manager.lockSucces.Add(this);
            description.text = "???????????????";
        }
    }
}
