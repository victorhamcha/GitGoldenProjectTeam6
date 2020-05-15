using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Yslide : MonoBehaviour
{
    
    public ContratsPanel panel;
    private Vector2 originalPos;
    private Vector3 distance;
    public float minY;
    public float maxY;
    public float posY;
    public bool touching = false;
    public bool toucMax = false;
    public bool toucMin = false;
    private float lastmoveDownY;
    private float lastmoveUpY;
    public Succes lastSucces;
    public Transform txt;
    void Start()
    {
        originalPos = transform.position;
        minY = -0.8862568f-0.1f;
        
    }

    // Update is called once per frame
    void Update()
    {
        if(panel.androidControl.SwipeLeft|| panel.androidControl.SwipeRight)
        {
            transform.position = originalPos;
            toucMax = false;
            toucMin = false;
        }
        if (panel.j == 1)
        {
            lastSucces = panel.lockSucces[panel.lockSucces.Count - 1];
        }
        if (panel.j == 2)
        {
            lastSucces = panel.unlockSucces[panel.lockSucces.Count];
            
        }
        posY = transform.position.y;
        if(panel.j!=0)
        {
            if (Input.touchCount > 0)
            {
                Touch touch = Input.GetTouch(0);

                if (touch.phase == TouchPhase.Began)
                {
                    touching = true;
                    distance = Camera.main.ScreenToWorldPoint(new Vector3(touch.position.x, touch.position.y, 0)) - transform.position;
                }
                else if (touch.phase == TouchPhase.Moved)
                {
                    Vector2 pos_move = Camera.main.ScreenToWorldPoint(new Vector2(touch.position.x, touch.position.y));
                    float moveY = pos_move.y - distance.y;
                    if (transform.position.y > minY && Vector2.Distance(lastSucces.transform.position,txt.position)>1f && touching)
                    {
                        transform.position = new Vector2(originalPos.x, moveY);
                    }

                    else if (transform.position.y < minY)
                    {
                        transform.position = new Vector2(originalPos.x, -0.8862568f);
                        if (touching)
                        {
                            lastmoveDownY = moveY;
                        }
                        touching = false;
                        toucMin = true;
                    }
                    else if (Vector2.Distance(lastSucces.transform.position, txt.position) < 1f)
                    {
                        transform.position = new Vector2(originalPos.x, transform.position.y-1);
                        if (touching)
                        {
                            lastmoveUpY = moveY;
                        }
                        touching = false;
                        toucMax = true;
                    }
                    else if (!touching)
                    {

                        if (moveY > lastmoveDownY && toucMin)
                        {
                            touching = true;
                            toucMin = false;
                        }
                        else if (moveY < lastmoveUpY && toucMax)
                        {
                            touching = true;
                            toucMax = false;
                        }

                    }

                }







            }
        }
        



      
    }

    

    IEnumerator waitSucces()
    {
        yield return new WaitForSeconds(0.01f);
    }
    
}
