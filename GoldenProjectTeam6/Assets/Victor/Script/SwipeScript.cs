using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
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
    public bool canGoUp;
    //Canvas//
    public GameObject img;
    private Image imgColor;
    public TextMeshProUGUI leftText;
    public TextMeshProUGUI rightText;
    public TextMeshProUGUI upText;

    //EFFECT//
    Material material;
    public float fade = 1f;
    public bool disolve = false;

    //Changement//
    private CardValuesWithScriptable card;
    // Start is called before the first frame update
    void Start()
    {
        card = GetComponent<CardValuesWithScriptable>();
        material = GetComponent<Image>().material;
        imgColor = img.GetComponent<Image>();
        originalPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
      
        upText.color = new Color(255 / 255f, 255 / 255f, 255 / 255f, (transform.position.y) / (0.911047f + 3.5f));
        if (transform.eulerAngles.z-180>0)
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
     

        
        if(!card.canSlideUp)
        {
           
                upText.text= "";
            
        }
        
        if (card._isADeadCard)
        {
            upText.text = "You are dead";
            rightText.text = "well done";
            leftText.text = "you should be so proud!";
        }
        

        
        img.transform.eulerAngles = new Vector3(0, 0, 0);
       
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
          

           if(touched)
           {
               
                if (touch.phase == TouchPhase.Began)
                {
                    touchRef = touch.position.x;
                    distance = Camera.main.ScreenToWorldPoint(new Vector3(touch.position.x, touch.position.y, 0)) - transform.position;
                }
                else if (touch.phase == TouchPhase.Moved)
                {
                   


                    Vector2 pos_move = Camera.main.ScreenToWorldPoint(new Vector2(touch.position.x, touch.position.y));
                    transform.position = new Vector2(pos_move.x - distance.x, pos_move.y-distance.y);


                    touchOffSet = touch.position.x - touchRef;
                    Vector3 rotationZ = new Vector3(0, 0, 0);
                    rotationZ.z = touchOffSet * rotateSpeed * Time.deltaTime;


                  

                    transform.Rotate(-rotationZ);

                    transform.eulerAngles = new Vector3(0, 0, ClampAngle(transform.eulerAngles.z, -maxRotation, maxRotation)); ;


                    touchRef = touch.position.x;

                }

                else if (touch.phase == TouchPhase.Ended || touch.phase == TouchPhase.Canceled)
                {
                    touched = false;
                    if((transform.eulerAngles.z==maxRotation && transform.position.x <= -2.2) || (transform.eulerAngles.z-360 ==-maxRotation&& transform.position.x >= 2.2) ||(transform.position.y>=4.5f&& card.canSlideUp))
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
           
            img.SetActive(false);
            fade -= Time.deltaTime*2;

            if(fade<=0f)
            {
                if (transform.eulerAngles.z == maxRotation && transform.position.x <= -2.2)
                {
                    card.GoLeft();
                   
                }
                else if ( transform.eulerAngles.z - 360 == -maxRotation && transform.position.x >= 2.2)
                {
                    card.GoRight();
                   
                }
                else if (transform.position.y >= 4.5f && card.canSlideUp)
                {
                    card.VerifyIfCanSlideUp();
                  
                }
                transform.eulerAngles = new Vector3(0, 0, 0);
                transform.position = originalPos;
                fade = 1f;
                img.SetActive(true);

                disolve = false;
            }

            material.SetFloat("_Fade", fade);
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
                card.VerifyIfCanSlideUp();
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
