﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
        if (SuccesManager.cardSkin != null)
            collector = SuccesManager.cardSkin;
        if (SceneManager.GetActiveScene().name=="MenuModifVic")
        {
           
            collector.SetFloat("Menu", 1);
            collector.SetFloat("_Fade", 1);
        }
        else
        {
            
            collector.SetFloat("Menu", 0);
        }
        
      
    }

  
    void Update()
    {
        float acceleration = Input.acceleration.x;
        if (acceleration != lastAcc)
        {
            accX += acceleration;
            lastAcc = acceleration;
        }

        
        if(collector.name!= "DistordMirror"&& collector.name != "LitThanosEffect")
        {
            accX = Mathf.Clamp(accX, -20, 20);
           
            collector.SetFloat("_Mouvement", accX);
           
        }
      
        else if (collector.name == "LitThanosEffect")
        {
            accX = Mathf.Clamp(accX, -7, 7);
            collector.SetVector("_Mouvement", new Vector2(-accX,0.5f));
        }
    }

   
}
