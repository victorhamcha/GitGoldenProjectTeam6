using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuccesManager : MonoBehaviour
{
    public List<Succes> allTheSucces = new List<Succes>();
    public List<Succes> easiestSucces = new List<Succes>();
  
    private int lvl=0;
    void Start()
    {
        for (int i =0; i<allTheSucces.Count;i++)
        {
            //allTheSucces[i].locked = SaveSystem.LoadSucces;
        }

        for (int i = 0; i < allTheSucces.Count; i++)
        {
           
            if(easiestSucces.Count>=3||lvl>4)
            {
                break;
            }
            if (allTheSucces[i].locked)
            {
                if(lvl==0)
                {
                    if(allTheSucces[i]._difficulté.ToString()== "TrèsFacile")
                    {
                        easiestSucces.Add(allTheSucces[i]);
                        continue;
                    }
                }
                else if (lvl == 1)
                {
                    if (allTheSucces[i]._difficulté.ToString() == "Facile")
                    {
                        easiestSucces.Add(allTheSucces[i]);
                        continue;

                    }
                }
                else if (lvl == 2)
                {
                    if (allTheSucces[i]._difficulté.ToString() == "Moyen")
                    {
                        easiestSucces.Add(allTheSucces[i]);
                        continue;

                    }
                }
                else if (lvl == 3)
                {
                    if (allTheSucces[i]._difficulté.ToString() == "Difficile")
                    {
                        easiestSucces.Add(allTheSucces[i]);
                        continue;

                    }
                }
                else if (lvl == 4)
                {
                    if (allTheSucces[i]._difficulté.ToString() == "TrèsDifficile")
                    {
                        easiestSucces.Add(allTheSucces[i]);
                        continue;

                    }
                }
                lvl++;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SuccesAnim()
    {

    }
}
