using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ContratsPanel : MonoBehaviour
{
    public Swiping androidControl;
    private int j = 0;
    public TextMeshProUGUI txtPanel;
    private bool[] lockedSucces=new bool[25];
   
    void Start()
    {
      
        
    }

    // Update is called once per frame
    void Update()
    {
        if(androidControl.SwipeLeft)
        {
            j--;
        }
        else if (androidControl.SwipeRight)
        {
            j++;
        }

        switch(j)
        {
           case -1:
           {
             j = 2;

             break;
           }
           case 0:
          {
            txtPanel.text = "Passeport";
            break;
          }

            case 1:
           {
              txtPanel.text = "Lock Contract";
              break;
           }

            case 2:
           {
            txtPanel.text = "Succed Contract";
            break;
           }
            case 3:
          {
            j = 0;

            break;
          }
        }
    }
}
