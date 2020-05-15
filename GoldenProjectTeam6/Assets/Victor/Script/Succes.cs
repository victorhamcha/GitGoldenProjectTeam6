using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
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
    public TextMeshProUGUI description;
    public TextMeshProUGUI titre;
    private void Start()
    {
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
    private void Update()
    {
      
    }
}
