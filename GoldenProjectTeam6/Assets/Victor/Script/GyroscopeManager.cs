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
    private Gyroscope gyro;
    private Quaternion rotation;
    private bool gyroActive;
    private float accX=0;
    private float lastAcc=0;
    [Header("tweaks")]
    [SerializeField] private Quaternion baseRotation = new Quaternion(0, 0, 1, 0);


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
    }

  
    void Update()
    {
        if(gyroActive)
        {
            rotation = gyro.attitude;            
            Debug.Log(rotation);
            rotateMax = rotation.x * rotateSpeed - 0.2f * rotateSpeed;
            rotateMax = Mathf.Clamp(rotateMax,-20,20);
            collector.SetFloat("_Mouvement", rotateMax);         
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
