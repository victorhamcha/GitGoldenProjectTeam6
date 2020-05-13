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
    private Color basicColor;

    [Header("Logic")]
    private Gyroscope gyro;
    private Quaternion rotation;
    private bool gyroActive;
    private float accX=0;
    private float lastAcc=0;
    [Header("tweaks")]
    [SerializeField] private Quaternion baseRotation = new Quaternion(0, 0, 0, 0);


    public void EnableGyro()
    {
        if (gyroActive)
            return;
        if(SystemInfo.supportsGyroscope)
        {
            gyro = Input.gyro;
            gyro.enabled = true;
            gyroActive = gyro.enabled;
        }
        else
        {
            Debug.Log("no gyro on your phone");
        }

      
    }

    void Start()
    {
        
        EnableGyro();
        if(gyroActive)
        {
            baseRotation = gyro.attitude;
        }
       
        basicColor =  collector.GetColor("_RotateColor");
    }

  
    void Update()
    {
        if(gyroActive)
        {
            rotation = gyro.attitude;            
            Debug.Log(rotateMax);
            rotateMax = (rotation.x * rotateSpeed)-(baseRotation.x*rotateSpeed);
            //rotateMax = Mathf.Clamp(rotateMax,-20,20);
            if(gyro.rotationRate.x>0.03f|| gyro.rotationRate.x < -0.03f)
            {
                collector.SetFloat("_Mouvement", rotateMax);
                collector.SetVector("_MouvementVector", new Vector2(rotation.x*Time.deltaTime*5, rotation.y * Time.deltaTime * 5));
            }
           
            //if(rotateMax>=-4.5&&rotateMax<=4.5)
            //{
            //    collector.SetColor("_RotateColor", collector.GetColor("_RotateColor") * 0);
            //}
            //else
            //{
            //    collector.SetColor("_RotateColor", basicColor);
            //}
           
          
        }

        //float acceleration = Input.acceleration.x;
        //if(acceleration!=lastAcc)
        //{
        //    accX += acceleration;
        //    lastAcc = acceleration;
        //}
     
        //accX = Mathf.Clamp(accX, -15, 15);
        //collector.SetFloat("_Mouvement", accX);
    }

    public Quaternion GetGyroRotation()
    {
        return rotation;
    }
}
