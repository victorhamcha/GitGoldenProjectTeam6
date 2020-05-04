using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SwipeScript : MonoBehaviour
{
    //ROTATION//
    public float maxRotation = 20f;
    public float rotateSpeed;
    public float zRotation;
    public bool reRotate=false;
    private float touchOffSet;
    private float touchRef;

    //Canvas//
    public GameObject panel;
    public GameObject img;
    public Transform imagePos;
    private Image imgColor;

    public Text leftText;
    public Text rightText;

    // Start is called before the first frame update
    void Start()
    {
        imgColor = img.GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {

        if(transform.eulerAngles.z-180>0)
        {
            imgColor.color = new Color(0 / 255f, 0 / 255f, 0 / 255f, ((Mathf.Abs(transform.eulerAngles.z-360) / maxRotation) * 40) / 255f);
            rightText.color = new Color(255 / 255f, 255 / 255f, 255 / 255f, ((Mathf.Abs(transform.eulerAngles.z - 360) / maxRotation)));
            leftText.color = new Color(255 / 255f, 255 / 255f, 255 / 255f, 0);
        }
        else if(transform.eulerAngles.z - 180 < 0)
        {
            imgColor.color = new Color(0 / 255f, 0 / 255f, 0 / 255f, ((Mathf.Abs(transform.eulerAngles.z) / maxRotation) * 40) / 255f);
            leftText.color = new Color(255 / 255f, 255 / 255f, 255 / 255f, ((Mathf.Abs(transform.eulerAngles.z) / maxRotation)));
            rightText.color = new Color(255 / 255f, 255 / 255f, 255 / 255f, 0);
        }
       

        //Debug.Log(((Mathf.Abs(transform.eulerAngles.z) / maxRotation) * 40));
        

        panel.transform.eulerAngles = transform.eulerAngles;
        img.transform.eulerAngles = new Vector3(0, 0, 0);
        panel.transform.position = imagePos.position;
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            Vector2 touchPosition = Camera.main.ScreenToWorldPoint(touch.position);
           
            if (touch.phase==TouchPhase.Began)
            {
                touchRef = touch.position.x;
            }
            else if ( touch.phase == TouchPhase.Moved)
            {

                touchOffSet = touch.position.x- touchRef;
                Vector3 rotationZ = new Vector3(0, 0, 0);
                rotationZ.z = touchOffSet*rotateSpeed*Time.deltaTime;


                //rotationZ = Quaternion.Euler(0f, 0f, -touchPosition.x * rotateSpeed);

                transform.Rotate(-rotationZ);
                
                transform.eulerAngles = new Vector3(0, 0,ClampAngle(transform.eulerAngles.z,-maxRotation,maxRotation));;
                
               
                touchRef = touch.position.x;
               
            }

            else if (touch.phase == TouchPhase.Ended || touch.phase == TouchPhase.Canceled)
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
                    transform.Rotate(0, 0, Time.deltaTime * 15);
                }
                else
                {
                    transform.Rotate(0, 0, Time.deltaTime * -15);
                }
                

            }
            else
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
                reRotate = false;
            }
        }
    }

    public static float ClampAngle(float angle, float min, float max)
    {
        angle = Mathf.Repeat(angle, 360);
        min = Mathf.Repeat(min, 360);
        max = Mathf.Repeat(max, 360);
        bool inverse = false;
        var tmin = min;
        var tangle = angle;
        if (min > 180)
        {
            inverse = !inverse;
            tmin -= 180;
        }
        if (angle > 180)
        {
            inverse = !inverse;
            tangle -= 180;
        }
        var result = !inverse ? tangle > tmin : tangle < tmin;
        if (!result)
            angle = min;

        inverse = false;
        tangle = angle;
        var tmax = max;
        if (angle > 180)
        {
            inverse = !inverse;
            tangle -= 180;
        }
        if (max > 180)
        {
            inverse = !inverse;
            tmax -= 180;
        }

        result = !inverse ? tangle < tmax : tangle > tmax;
        if (!result)
            angle = max;
        return angle;
    }



}
