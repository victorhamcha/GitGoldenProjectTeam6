using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Yslide : MonoBehaviour
{
    
    public ContratsPanel panel;
    public Vector2 originalPos;
    private Vector3 distance;
    public float minY;
    public float maxY;
    public Swiping swiping;
    public bool touching = false;
    public bool toucMax = false;
    public bool toucMin = false;
    private float lastmoveDownY;
    private float lastmoveUpY;
    public Succes lastSucces;
    private bool canTOuch = true;
    Touch touch;


    public Transform txt;
    void Start()
    {
        originalPos = GetComponent<RectTransform>().anchoredPosition;
        minY = -0.8862568f-0.1f;
        
    }

    // Update is called once per frame
    void Update()
    {
       
        if (swiping.SwipeLeft|| swiping.SwipeRight)
        {
            if (panel.page == 1)
            {
                if (panel.lockSucces.Count > 0)
                {
                    lastSucces = panel.lockSucces[panel.lockSucces.Count - 1];
                   
                }
            }
            if (panel.page == 2)
            {
                if (panel.unlockSucces.Count > 0)
                {
                    lastSucces = panel.unlockSucces[panel.unlockSucces.Count - 1];
                  
                }
               
            }
            
            GetComponent<RectTransform>().anchoredPosition = originalPos;
            toucMax = false;
            toucMin = false;
           
            //canTOuch = false;
            distance = Camera.main.ScreenToWorldPoint(new Vector3(touch.position.x, touch.position.y, 0)) - transform.position;
        }      
       
        if(panel.page!=0)
        {
                if (Input.touchCount > 0)
                {
                    touch = Input.GetTouch(0);
                    if (touch.phase == TouchPhase.Began)
                    {
                        touching = true;
                        distance = Camera.main.ScreenToWorldPoint(new Vector3(touch.position.x, touch.position.y, 0)) - transform.position;
                    }
                    else if (touch.phase == TouchPhase.Moved)
                    {
                        Vector2 pos_move = Camera.main.ScreenToWorldPoint(new Vector2(touch.position.x, touch.position.y));
                        float moveY = pos_move.y - distance.y;
                        if (transform.position.y > minY && Vector2.Distance(lastSucces.transform.position, txt.position) > 1f && touching)
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
                            transform.position = new Vector2(originalPos.x, transform.position.y - 1);
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

       //if(Input.GetMouseButtonUp(0))
       //{
       //     canTOuch = true;
       //}
    }



    
    //IEnumerator waitSucces()
    //{
    //    yield return new WaitForSeconds(0.5f);
    //    canTOuch = true;
    //}
    
}
