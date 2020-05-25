using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GyroscopeManager : MonoBehaviour
{

    [Header("shader")]
    public Material collector;
    public float rotateSpeed;
    public float rotateMax;
    public float paralaxSpeed;

    [Header("Logic")]
    private float accX=0;
    private float lastAcc=0;


    void Start()
    {
        if(SuccesManager.cardSkin!=null)
        collector = SuccesManager.cardSkin;      
    }

  
    void Update()
    {
        float acceleration = Input.acceleration.x;
        if (acceleration != lastAcc)
        {
            accX += acceleration;
            lastAcc = acceleration;
        }

        accX = Mathf.Clamp(accX, -20, 20);
        if(collector.name!= "DistordMirror"&& collector.name != "LitThanosEffect")
        collector.SetFloat("_Mouvement", accX);
        else if (collector.name == "LitThanosEffect")
        {

            
            accX = Mathf.Clamp(accX,-1f, 11f);
            collector.SetVector("_Mouvement", new Vector2(accX,0.5f));
        }
    }

   
}
