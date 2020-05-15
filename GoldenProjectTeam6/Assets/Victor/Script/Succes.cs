using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class Succes : MonoBehaviour
{
    public enum difficulté { TrèsFacile, Facile,Moyen,Difficile, TrèsDifficile };
    public difficulté _difficulté;
    private ContratsPanel manager;
    public int id;
    public Image img;
    public bool locked=true;
    private bool insert = false;
    public Sprite succesIMG;
    public string txtTitre;
    public string txtDescription;
    public TextMeshProUGUI description;
    public TextMeshProUGUI titre;
    public bool inGame=false;
    private void Start()
    {
        
        if(SceneManager.GetActiveScene().name== "GeneralScene")
        {
            inGame = true;
        }
        if(!inGame)
        {
            description.text = txtDescription;
            titre.text = txtTitre;
            manager = GetComponentInParent<ContratsPanel>();
            if (!locked)
            {
                manager.unlockSucces.Add(this);
                insert = true;
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
