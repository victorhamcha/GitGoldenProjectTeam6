using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Yslide : MonoBehaviour
{
    
    private Vector2 originalPos;
    private Vector3 distance;
    public float minY;
    public float maxY;
    void Start()
    {
        originalPos = transform.position;

    }

    // Update is called once per frame
    void Update()
    {


        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);




            if (touch.phase == TouchPhase.Began)
            {

                distance = Camera.main.ScreenToWorldPoint(new Vector3(touch.position.x, touch.position.y, 0)) - transform.position;
            }
            else if (touch.phase == TouchPhase.Moved)
            {
                Vector2 pos_move = Camera.main.ScreenToWorldPoint(new Vector2(touch.position.x, touch.position.y));
                float moveY = pos_move.y - distance.y;
              
                if(transform.position.y<maxY&&transform.position.y>minY)
                transform.position = new Vector2(originalPos.x, moveY);
            }

            else if (touch.phase == TouchPhase.Ended || touch.phase == TouchPhase.Canceled)
            {




            }





        }



      
    }

    private void OnMouseEnter()
    {
        if (Input.touchCount > 0)
        {

            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began)
            {

            }
        }

    }

    IEnumerator waitSucces()
    {
        yield return new WaitForSeconds(0.01f);
    }
}
