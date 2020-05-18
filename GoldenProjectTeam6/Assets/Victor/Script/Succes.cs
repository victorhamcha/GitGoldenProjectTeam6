using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class Succes : MonoBehaviour
{

    public int id;
    //DIffiuclité
    public enum difficulté { TrèsFacile, Facile,Moyen,Difficile, TrèsDifficile };
    public difficulté _difficulté;
   
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
    private bool inGame=false;
    private void Awake()
    {
        
        if(SceneManager.GetActiveScene().name== "GeneralScene")
        {
            inGame = true;
        }
        if(!inGame)
        {
            //text
            description = GetComponentsInChildren<TextMeshProUGUI>()[1];
            titre = GetComponentsInChildren<TextMeshProUGUI>()[0];
            description.text = txtDescription;
            titre.text = txtTitre;
            ////////////////////////////////////////////////////////////
            img = GetComponentInChildren<Image>();
            

            manager = GetComponentInParent<ContratsPanel>();
            if (!locked)
            {
                manager.unlockSucces.Add(this);
               
            }
            else
            {
                manager.lockSucces.Add(this);
            }
        }
      
    }
    private void Update()
    {
      
    }
}
