using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ContratsPanel : MonoBehaviour
{
    public Swiping androidControl;
    public int j = 1;
    public TextMeshProUGUI txtPanel;
    public List<Succes> lockSucces = new List<Succes>();
    public List<Succes> unlockSucces = new List<Succes>();
    public Transform startPosition;
    public Transform unlock;
    public Transform locked;
    public Transform passeport;
    public float space;


    private void Awake()
    {
        StartCoroutine(waitSucces());
    }

    void Start()
    {

        

    }

    // Update is called once per frame
    void Update()
    {

        if (androidControl.SwipeLeft)
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
            j = 0;

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
            unlockSucces[i].transform.localPosition = new Vector2(0, startPosition.position.y+765  - space * (i));
        }
        for (int i = 0; i < lockSucces.Count; i++)
        {
            lockSucces[i].transform.SetParent(locked);
            lockSucces[i].transform.localPosition = new Vector2(0, startPosition.position.y+765  - space * (i));
        }
    }
}
