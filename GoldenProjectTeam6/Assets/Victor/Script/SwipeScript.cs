using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SwipeScript : MonoBehaviour
{
    bool touched = false;
    //ROTATION//
    public float maxRotation = 20f;
    public float rotateSpeed;
    public float zRotation;
    public bool reRotate=false;
    private float touchOffSet;
    private float touchRef;
    private Vector2 originalPos;
    private Vector3 distance;
    public LayerMask mask;

    //Canvas//
    public GameObject panel;
    public GameObject img;
    public Transform imagePos;
    private Image imgColor;
    public Text leftText;
    public Text rightText;

    //EFFECT//
    Material material;
    float fade = 1f;
    bool disolve = false;
    // Start is called before the first frame update
    void Start()
    {
        material = GetComponent<SpriteRenderer>().material;
        imgColor = img.GetComponent<Image>();
        originalPos = transform.position;
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
            //RaycastHit2D hit = Physics2D.Raycast(touch.position, Vector2.left);

           if(touched)
           {
                if (touch.phase == TouchPhase.Began)
                {
                    touchRef = touch.position.x;
                    distance = Camera.main.ScreenToWorldPoint(new Vector3(touch.position.x, touch.position.y, 0)) - transform.position;
                }
                else if (touch.phase == TouchPhase.Moved)
                {
                    //transform.position = touchPosition;


                    Vector2 pos_move = Camera.main.ScreenToWorldPoint(new Vector2(touch.position.x, touch.position.y));
                    transform.position = new Vector2(pos_move.x - distance.x, pos_move.y-distance.y);


                    touchOffSet = touch.position.x - touchRef;
                    Vector3 rotationZ = new Vector3(0, 0, 0);
                    rotationZ.z = touchOffSet * rotateSpeed * Time.deltaTime;


                    //rotationZ = Quaternion.Euler(0f, 0f, -touchPosition.x * rotateSpeed);

                    transform.Rotate(-rotationZ);

                    transform.eulerAngles = new Vector3(0, 0, ClampAngle(transform.eulerAngles.z, -maxRotation, maxRotation)); ;


                    touchRef = touch.position.x;

                }

                else if (touch.phase == TouchPhase.Ended || touch.phase == TouchPhase.Canceled)
                {
                    touched = false;
                    if(transform.eulerAngles.z==maxRotation|| transform.eulerAngles.z ==-maxRotation)
                    {
                        disolve = true;
                    }
                    else
                    {
                        reRotate = true;
                    }
                   

                }
           }
           
                

            
        }



        if(disolve)
        {
            //GetComponent<Collider2D>().isTrigger = true;

            fade -= Time.deltaTime;

            if(fade<=0f)
            {
                fade = 0f;
                disolve = false;
            }

            material.SetFloat("Fade", fade);
        }
        else if (reRotate)
        {
            Vector3 to = new Vector3(0, 0, 0);
            if (Vector3.Distance(transform.eulerAngles, to) > 1f||Vector2.Distance(transform.position,originalPos)!=0)
            {
                float lastZ = transform.eulerAngles.z - 180;

                transform.position = Vector2.MoveTowards(transform.position, originalPos,10*rotateSpeed*Time.deltaTime);
                
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
  
       

    
    private void OnMouseOver()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began)
            {
                touched = true;
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
