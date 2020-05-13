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

    public Vector2 paraPos=new Vector2(0,0);
    float vX = -1;
    float vY = 0.098f;

    [Header("Logic")]
    private Gyroscope gyro;
    private Quaternion rotation;
    private bool gyroActive;
    private float accX=0;
    private float lastAcc=0;
    private float lastAccX=0;
    private float lastAccY=0;
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
            //Debug.Log(rotateMax);
            //rotateMax = (rotation.x * rotateSpeed) - (baseRotation.x * rotateSpeed);
            //lastAcc = rotation.y - baseRotation.y;
            //accX = rotation.x - baseRotation.x;
            //rotateMax = Mathf.Clamp(rotateMax, -20, 20);
            if (gyro.rotationRate.x > 0.03f || gyro.rotationRate.x < -0.03f)
            {
                //collector.SetFloat("_Mouvement", rotateMax);
                //collector.SetVector("_MouvementVector", new Vector2(gyro.attitude.x,gyro.attitude.y));
            }

            ////if(rotateMax>=-4.5&&rotateMax<=4.5)
            ////{
            ////    collector.SetColor("_RotateColor", collector.GetColor("_RotateColor") * 0);
            ////}
            ////else
            ////{
            ////    collector.SetColor("_RotateColor", basicColor);
            ////}


        }

        float acceleration = Input.acceleration.x;
        if (acceleration != lastAcc)
        {
            accX += acceleration;
            lastAcc = acceleration;
        }

        accX = Mathf.Clamp(accX, -20, 20);
        collector.SetFloat("_Mouvement", accX);
        //if(Input.acceleration.y*0.02f!= lastAccY)
        //{
        //    vY += Input.acceleration.z * 0.02f;
        //    lastAccY= Input.acceleration.z * 0.02f;
        //}
        //if (Input.acceleration.x * 0.02f != lastAccX)
        //{
        //    vX += Input.acceleration.x * 0.02f;
        //    lastAccX = Input.acceleration.x * 0.02f;
        //}

        
        
        //vY= Mathf.Clamp(vY, -1.6f, 1.3f);
        //vX= Mathf.Clamp(vX, -2.75f, 1.15f);
        //paraPos = new Vector2(vX, vY);
        //collector.SetVector("_MouvementVector",paraPos);
    }

    public Quaternion GetGyroRotation()
    {
        return rotation;
    }
}
