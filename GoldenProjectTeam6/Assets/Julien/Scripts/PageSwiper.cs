using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI; 

public class PageSwiper : MonoBehaviour, IDragHandler, IEndDragHandler
{
    private Vector3 panelLocation;
    private float percentThreshold = 0.4f;
    private float easing = 0.5f;
    private int totalPages = 3;
    private int currentPage = 1;
    private float difference = 0.0f;
    private float differenceY = 0.0f;
    // Start is called before the first frame update
    void Start()
    {
        panelLocation = transform.position;
    }


    public void OnDrag(PointerEventData data)
    {
        difference = data.pressPosition.x - data.position.x;
        differenceY = data.pressPosition.y - data.position.y;


        if (difference > 0 && currentPage != totalPages)
        {
            transform.position = panelLocation - new Vector3(difference, 0, 0);
        }

        if (differenceY > 0 && currentPage != 1)
        {
            transform.position = panelLocation - new Vector3(0, differenceY, 0);
        }
    }

    public void OnEndDrag(PointerEventData data)
    {
        // X //
        float percentage = (data.pressPosition.x - data.position.x) / Screen.width;

        if (Mathf.Abs(percentage) >= percentThreshold)
        {

            Vector3 newLocation = panelLocation;
            if (percentage > 0 && currentPage < totalPages)
            {
                currentPage++;
                newLocation += new Vector3(-Screen.width, 0, 0);
            }
            else if (percentage < 0 && currentPage > 1)
            { 
                currentPage--;
                newLocation += new Vector3(Screen.width, 0, 0);
            }
            StartCoroutine(SmoothMove(transform.position, newLocation, easing));
            panelLocation = newLocation;
        }
        else
        {
            StartCoroutine(SmoothMove(transform.position, panelLocation, easing));
        }

        // Y //

        if (currentPage == 2 || currentPage == 3)
        {
            float percentage2 = (data.pressPosition.y - data.position.y) / Screen.height;


            Debug.Log(percentage2);
            Vector3 newLocation = panelLocation;
            if (percentage2 < 0 && currentPage != 1)
            {
                //currentPage++;
                newLocation -= new Vector3(0, differenceY, 0);
            }
            else if (percentage2 > 0 && currentPage != 1)
            {
                //currentPage--;
                newLocation += new Vector3(0, differenceY, 0);
            }
            StartCoroutine(SmoothMove(transform.position, newLocation, easing));
            panelLocation = newLocation;
        }

        else
        {
            StartCoroutine(SmoothMove(transform.position, panelLocation, easing));
        }
        
   
    }

    IEnumerator SmoothMove(Vector3 startpos, Vector3 endpos, float seconds)
    {
        float t = 0f;
        while (t <= 1.0)
        {
            t += Time.deltaTime / seconds;
            transform.position = Vector3.Lerp(startpos, endpos, Mathf.SmoothStep(0f, 1f, t));
            yield return null;
        }

    }
}