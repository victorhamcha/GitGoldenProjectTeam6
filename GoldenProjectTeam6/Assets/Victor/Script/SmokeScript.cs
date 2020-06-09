using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmokeScript : MonoBehaviour
{
    public Transform card;


    public float ellapsetime1 = 50/1000;
    public float ellapsetime2 = 800/1000;
    public long vibrationTime = 200;

    bool firstV=false;
    bool secondV=false;
    bool timerD=false;

    float ellapseBase1=50/1000;
    float ellapseBase2=800/1000;
    void Start()
    {
        ellapseBase1 = ellapsetime1;
        ellapseBase2 = ellapsetime2;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = card.position;
        transform.rotation = card.rotation;

        if(!firstV)
        {
            Vibration.Vibrate(vibrationTime);
            firstV = true;
        }
        else if(ellapsetime1>0&&firstV)
        {
            ellapsetime1 -= Time.deltaTime;
        }
        else if(firstV&&!secondV)
        {
            Vibration.Vibrate(vibrationTime);
            secondV = true;
        }
        else if(firstV&&secondV&&ellapsetime2>0)
        {
            ellapsetime2 -= Time.deltaTime;
        }
        else if(firstV&&secondV&&ellapsetime2<=0)
        {
            firstV = false;
            secondV = false;
            ellapsetime1 = ellapseBase1;
            ellapsetime2 = ellapseBase2;
        }
    }
}
