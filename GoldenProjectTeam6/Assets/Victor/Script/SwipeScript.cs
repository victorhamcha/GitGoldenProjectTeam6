using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SwipeScript : MonoBehaviour
{
    //Anim related variables
    //public Animator animCard;
    //private float inactivity = 0.0f;

    bool touched = false;
    //ROTATION//
    public float maxRotation = 20f;
    public float rotateSpeed;
    public float zRotation;
    

    private float touchOffSet;
    private float touchRef;
    private Vector2 originalPos;
    private Vector2 originalPosPlus;
    private Vector3 distance;
    private bool smooth = false;
    private bool step1 = false;
    private bool canTurn=true;
    public bool reRotate = false;
    public bool canGoUp;
    public float maxX = 265;
    public float maxY = 425;
    public float offSetsmooth = 0.4f;
    private int nbCardTuto = 0;
    //Canvas//
    public GameObject img;
    private Image imgColor;
    public TextMeshProUGUI leftText;
    public TextMeshProUGUI rightText;
    public TextMeshProUGUI upText;
    public GameObject ArrowSlideUp;
    public GameObject FingerRight;
    public GameObject FingerLeft;
    public GameObject FingerUp;

    //EFFECT//
    public Material material;
    public float fade = 1f;
    public bool disolve = false;
    public bool undisolve = false;

    public bool canslidup;
    //Changement//
    private CardValuesWithScriptable card;

    //description
    public RectTransform descriptionTransform;
    private Vector2 originalDescriptionPosition;

    //BackGround
    public Image BG;
    public Sprite[] bgTexture;
    public Material _mtrl;
    private float rotateShader = 1;
    private bool animGO=false;
    private Sprite _newBG;

    // Start is called before the first frame update
    void Start()
    {
       // animCard = GetComponent<Animator>();
        
        /*if(SceneManager.GetActiveScene().name == "TestCardJulien")
        {
            animCard.SetBool("IsCredit", true);
        }
        else
        {
            animCard.SetBool("IsCredit", false);
        }*/
       
        if (descriptionTransform!=null)
        {
            originalDescriptionPosition = descriptionTransform.anchoredPosition;
        }


        //img.SetActive(false);
        card = GetComponent<CardValuesWithScriptable>();
        material = GetComponent<Image>().material;
        if(SuccesManager.cardSkin!=null)
        material = SuccesManager.cardSkin;
        
        GetComponent<Image>().material = material;
        imgColor = img.GetComponent<Image>();
        originalPos = transform.position;
        material.SetFloat("_Fade", 1f);
        _mtrl.SetFloat("_opacity", rotateShader);
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.LogError("canslideup : " + card.canSlideUp);
        
        if(!touched)
        {
            //inactivity += Time.deltaTime;
            //Debug.Log(inactivity);
        }
        else
        {
            //inactivity = 0.0f;
        }

        /*if(inactivity > 30.0f && animCard.enabled == false && SceneManager.GetActiveScene().name == "GeneralScene")
        {
            animCard.enabled = true;
            img.SetActive(true);
            
        }*/
        

        canslidup=card.canSlideUp;
       
        upText.color = new Color(255 / 255f, 255 / 255f, 255 / 255f, (transform.position.y-0.5f) / (maxY/1.5f));
        if (transform.eulerAngles.z-180>0)
        {
            imgColor.color = new Color(0 / 255f, 0 / 255f, 0 / 255f, ((Mathf.Abs(transform.eulerAngles.z-360) / (maxRotation/2)) * 40) / 255f);
            rightText.color = new Color(255 / 255f, 255 / 255f, 255 / 255f, ((Mathf.Abs(transform.eulerAngles.z - 360) / (maxRotation / 2))));
            leftText.color = new Color(255 / 255f, 255 / 255f, 255 / 255f, 0);
        }
        else if(transform.eulerAngles.z - 180 < 0)
        {
            imgColor.color = new Color(0 / 255f, 0 / 255f, 0 / 255f, ((Mathf.Abs(transform.eulerAngles.z) / maxRotation) * 40) / 255f);
            leftText.color = new Color(255 / 255f, 255 / 255f, 255 / 255f, ((Mathf.Abs(transform.eulerAngles.z) / maxRotation)));
            rightText.color = new Color(255 / 255f, 255 / 255f, 255 / 255f, 0);
        }
     

        if(touched)
        {
            if (SceneManager.GetActiveScene().name == "Tuto")
            {
                FingerRight.SetActive(false);
                FingerLeft.SetActive(false);
                FingerUp.SetActive(false);
            }
        }
        else
        {
            if (SceneManager.GetActiveScene().name == "Tuto")
            {
                switch (nbCardTuto)
                {
                    case 0:
                        FingerLeft.SetActive(false);
                        FingerUp.SetActive(false);
                        FingerRight.SetActive(true);
                        break;
                    case 1:
                        FingerRight.SetActive(false);
                        FingerUp.SetActive(false);
                        FingerLeft.SetActive(true);
                        break;
                    case 2:
                        FingerRight.SetActive(false);
                        FingerLeft.SetActive(false);
                        FingerUp.SetActive(false);
                        break;
                    case 3:
                        FingerRight.SetActive(false);
                        FingerLeft.SetActive(false);
                        FingerUp.SetActive(true);
                        break;
                    case 4:
                        FingerRight.SetActive(false);
                        FingerLeft.SetActive(false);
                        FingerUp.SetActive(false);
                        break;

                }
            }
        }
        Debug.Log(nbCardTuto);

            if(!card._firstCardScriptable._canSlideUp && card._firstCardScriptable.isLinkedIn == false)
            {
           
                upText.text= "";
                ArrowSlideUp.SetActive(false);
            }
            else if(card._firstCardScriptable._canSlideUp && !touched)
            {
                ArrowSlideUp.SetActive(true);
            }
            else if(card._firstCardScriptable._canSlideUp &&!canslidup && touched)
            {
                ArrowSlideUp.SetActive(false);
                upText.text = "You don't have the object required";
            }
            else if(card._firstCardScriptable._canSlideUp && canslidup && touched)
            {
                ArrowSlideUp.SetActive(false);
            }

        
        if (card._isADeadCard)
        {
            upText.text = "You did it, you're dead!";
            rightText.text = "Find an other way to die";
            leftText.text = "Go to menu";
        }
         else if (card._firstCardScriptable._isEndingEvent)
        {
            upText.text = "";
            rightText.text = "Go in another direction";
            leftText.text = "Continue this way";
        }



        img.transform.eulerAngles = new Vector3(0, 0, 0);
       
        if (Input.touchCount > 0&&canTurn)
        {
            Touch touch = Input.GetTouch(0);
          

           if(touched)
           {
               
                if (touch.phase == TouchPhase.Began)
                {
                    //animCard.enabled = false;
                    card.audioManager.Play("SFX_Click");


                    ArrowSlideUp.SetActive(false);
                    touchRef = touch.position.x;
                    distance = Camera.main.ScreenToWorldPoint(new Vector3(touch.position.x, touch.position.y, 0)) - transform.position;
                }
                else if (touch.phase == TouchPhase.Moved)
                {

                    ArrowSlideUp.SetActive(false);

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
                    

                    img.SetActive(false);
                    touched = false;
                    if((transform.eulerAngles.z>=maxRotation-0.1f&& transform.eulerAngles.z <= maxRotation + 0.1f && Mathf.Abs(transform.position.x)>= maxX) || (transform.eulerAngles.z-360 >=-maxRotation-0.1f&& transform.eulerAngles.z - 360 <= -maxRotation+0.1f && transform.position.x >= maxX) ||(transform.position.y>= maxY && card.canSlideUp))
                    {
                        disolve = true;
                        card.audioManager.PlayRandomPitch("SFX_Swipe", 1f, 2.5f);
                    }
                    else
                    {
                        originalPosPlus = (originalPos- (Vector2)transform.position).normalized;
                        reRotate = true;
                    }
                   

                }
           }
           
                

            
        }



        if(disolve)
        {
            if (SceneManager.GetActiveScene().name == "Tuto")
            {
                FingerRight.SetActive(false);
                FingerLeft.SetActive(false);
                FingerUp.SetActive(false);

            }
            ArrowSlideUp.SetActive(false);
            canTurn = false;
            img.SetActive(false);
          
            fade -= Time.deltaTime*2;

            if(fade<=0f)
            {
                
                nbCardTuto++;
                string place = card._titleCard.text;
                if ((transform.eulerAngles.z >= maxRotation - 0.1f && transform.eulerAngles.z <= maxRotation + 0.1f && Mathf.Abs(transform.position.x) >= maxX))
                {
                    card.GoLeft();
                   
                }
                else if (transform.eulerAngles.z - 360 >= -maxRotation - 0.1f && transform.eulerAngles.z - 360 <= -maxRotation + 0.1f && transform.position.x >= maxX)
                {
                    card.GoRight();
                    Debug.Log("Go Right");
                    // if (TutoSwipeRight) startcoroutine(waitfortransition); tutoswiperight = false; tutoswipeleft = true;
                   
                }
                else if (transform.position.y >= maxY && card.canSlideUp)
                {
                    card.GoUp();
                    ArrowSlideUp.SetActive(false);
                  
                }
                transform.eulerAngles = new Vector3(0, 0, 0);
                transform.position = originalPos;
                disolve = false;
                undisolve = true;
                descriptionTransform.anchoredPosition = originalDescriptionPosition;
                if(place!= card._firstCardScriptable._title)
                {
                    if (card._firstCardScriptable._title == "The Zoo")
                    {
                        SwitchBG(bgTexture[3]);
                    }
                    else if (card._firstCardScriptable._title == "The Circus")
                    {
                        SwitchBG(bgTexture[1]);
                    }
                    else if (card._firstCardScriptable._title == "The Food Courts")
                    {
                        SwitchBG(bgTexture[2]);
                    }
                    else
                    {
                        SwitchBG(bgTexture[0]);
                    }
                }
              

            }

            material.SetFloat("_Fade", fade);
        }
        else if (reRotate)
        {
            Vector3 to = new Vector3(0, 0, 0);
            if (Vector3.Distance(transform.eulerAngles, to) > 2f||(Vector2.Distance(transform.position,originalPos)>0.05||!smooth))
            {
                float lastZ = transform.eulerAngles.z - 180;

               if(offSetsmooth>0.05f)
                {
                    if (step1)
                    {
                        if (!smooth)
                            smooth = Vector2.Distance(transform.position, originalPos) >= offSetsmooth;
                    }
                    else
                    {

                        step1 = Vector2.Distance(transform.position, originalPos) <= offSetsmooth - 0.05f;

                    }

                    if (!smooth)
                        transform.position += (Vector3)originalPosPlus * 10 * Time.deltaTime;
                    else
                        transform.position = Vector2.MoveTowards(transform.position, originalPos, 5 * Time.deltaTime);
                }
               else
                {
                    smooth = true;
                    transform.position = Vector2.MoveTowards(transform.position, originalPos, 10 * Time.deltaTime);
                }
               


                if ((transform.eulerAngles.z-180)/Mathf.Abs((transform.eulerAngles.z - 180))>=0)
                {
                    transform.Rotate(0, 0, Time.deltaTime * rotateSpeed*40);
                }
                else
                {
                    transform.Rotate(0, 0, Time.deltaTime * -rotateSpeed*40);
                }
               

            }
            else
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
                transform.position = originalPos;
                if (canslidup)
                {
                    ArrowSlideUp.SetActive(true);
                }
                reRotate = false;
                smooth = false;
                step1 = false;
            }
        }
        else if(undisolve)
        {
            if (fade >= 1f)
            {
                fade = 1f;
                undisolve = false;
                canTurn = true;
            }
            else
            {
                fade += Time.deltaTime * 1.5f;
            }
            material.SetFloat("_Fade", fade);
        }

        if(animGO)
        {
            rotateShader -= 0.05f;
            if(rotateShader<=0f)
            {
                rotateShader = 0;
                _mtrl.SetFloat("_opacity", rotateShader);
                animGO = false;
                BG.sprite = _newBG;
                
            }
            _mtrl.SetFloat("_opacity", rotateShader);
           
        }
        else if(rotateShader!=1f)
        {
            rotateShader = 1f;
        }
    }
  
       

    
    private void OnMouseOver()
    {
        if (Input.touchCount > 0)
        {

            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began)
            {
                if(card._firstCardScriptable._canSlideUp)
                card.VerifyIfCanSlideUp();
              if(!disolve)
              {
                    img.SetActive(true);
              }
               
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

    public void SwitchBG(Sprite newBG)
    {

        rotateShader = 1f;
        _mtrl.SetTexture("_NewBG", newBG.texture);
        animGO = true;
        _newBG = newBG;
       


    }

}
