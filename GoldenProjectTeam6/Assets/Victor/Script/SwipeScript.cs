using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwipeScript : MonoBehaviour
{
    public LayerMask card;
    public Quaternion rotationZ;
    public float rotateSpeed;
    public float zRotation;
    public bool reRotate=false;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            Vector2 touchPosition = Camera.main.ScreenToWorldPoint(touch.position);

           
            if ( touch.phase == TouchPhase.Moved)
            {
                rotationZ = Quaternion.Euler(0f, 0f, -touchPosition.x * rotateSpeed);
                transform.rotation = rotationZ * transform.rotation;
                Mathf.Clamp(rotationZ.z, -90, 90);
            }

            if (touch.phase == TouchPhase.Ended || touch.phase == TouchPhase.Canceled)
            {
                reRotate = true;
               
            }

        }

        if(reRotate)
        {
            Vector3 to = new Vector3(0, 0, 0);
            if (Vector3.Distance(transform.eulerAngles, to) > 1f)
            {
                float lastZ = transform.eulerAngles.z - 180;


                
                if((transform.eulerAngles.z-180)/Mathf.Abs((transform.eulerAngles.z - 180))>=0)
                {
                    transform.Rotate(0, 0, Time.deltaTime * 150);
                }
                else
                {
                    transform.Rotate(0, 0, Time.deltaTime * -150);
                }
                

            }
            else
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
                reRotate = false;
            }
        }
    }


}
