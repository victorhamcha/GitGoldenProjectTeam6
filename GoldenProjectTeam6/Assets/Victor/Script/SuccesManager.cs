using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class SuccesManager : MonoBehaviour
{
    bool inGame = false;


    //Vibration
    private long[] paternVibrationSucces = new long[2];

    //succes13
    [HideInInspector] public float swiped = 0f;

    //skin
    [HideInInspector] public static Material cardSkin;

    [Header("SuccesManagement")]
    public List<bool> lockInfo = new List<bool>();
    public List<Succes> allTheSucces = new List<Succes>();
    private int lvl = 0;
    [Header("EASY succes")]
    public List<Succes> easiestSucces = new List<Succes>();
    public TextMeshProUGUI titre1;
    public TextMeshProUGUI des1;
    public TextMeshProUGUI titre2;
    public TextMeshProUGUI des2;
    public TextMeshProUGUI titre3;
    public TextMeshProUGUI des3;

    [Header("SuccesUnlockAnim")]
    public Animator succesAnim;
    public TextMeshProUGUI sucesName;
    public Animation anim;

    [Header("Succes 12 Stuff")]
    public float timer = 0f;
    public CardScriptableObject boredomCard;

    //sound
    [Header("Audio")]
    public AudioManager audioManager;

    void Start()
    {
        paternVibrationSucces[0] = 100;
        paternVibrationSucces[1] = 150;
        inGame = SceneManager.GetActiveScene().name == "GeneralScene";


        for (int i = 0; i < allTheSucces.Count; i++)
        {
            allTheSucces[i].locked = lockInfo[i];
        }

        //easiest succes
        if (inGame)
        {
            LoadEasisestSucces();
            lvl = 0;
        }


    }

    // Update is called once per frame
    void Update()
    {
        if (inGame)
        {
            if (lockInfo[11])
            {
                timer += Time.deltaTime;
                if (timer >= 25)
                {
                    UnlockSuccess(allTheSucces[11].enumSucces);
                    if (allTheSucces[0].locked)
                        UnlockSuccess(allTheSucces[0].enumSucces);
                    FindObjectOfType<CardValuesWithScriptable>()._firstCardScriptable = boredomCard;
                    FindObjectOfType<CardValuesWithScriptable>().LoadValueFromScriptableObject();

                    //SceneManager.LoadScene("BaptisteTestArbo");
                }
            }

        }

    }

    public void UnlockSuccess(EnumSuccess._enumSuccess _successToUnlock)
    {
        if (_successToUnlock.ToString() != "none")
        {
            for (int i = 0; i < allTheSucces.Count; i++)
            {
                if (allTheSucces[i].locked)
                {
                    if (allTheSucces[i].enumSucces == _successToUnlock)
                    {
                        
                        allTheSucces[i].locked = false;
                        lockInfo[i] = allTheSucces[i].locked;
                        GPSAchievements.UnlockSucces(allTheSucces[i].id);
                        FindObjectOfType<SaveAndLoad>().SaveCards();
                        //saveSucces
                        if (succesAnim.GetBool("UNLOCK"))
                        {
                            Debug.Log("Different");
                            StartCoroutine(WaitAnim(allTheSucces[i].txtTitre));
                           
                        }
                        else
                        {
                            Debug.Log("Basic");
                            SuccesAnim(allTheSucces[i].txtTitre);
                        }
                        if(inGame)
                        {
                            LoadEasisestSucces();
                            lvl = 0;
                        }
                       


                        break;
                    }
                }
            }
        }
    }

 

    IEnumerator WaitAnim(string succesname)
    {
        Debug.Log("enter couroutine");
        while (succesAnim.GetBool("UNLOCK"))
        {
            yield return null;
        }
        audioManager.Play("SFX_UnlockSuccess");
        Vibration.Vibrate(200);
        Debug.Log("exit couroutine");
        succesAnim.SetTrigger("Unlock");
        succesAnim.SetBool("UNLOCK", true);
        StartCoroutine(WaitEndAnim());
        sucesName.text = succesname;
       
    }
    public void SuccesAnim(string succesname)
    {
        audioManager.Play("SFX_UnlockSuccess");
        Vibration.Vibrate(200);
        succesAnim.SetTrigger("Unlock");
        succesAnim.SetBool("UNLOCK", true);
        StartCoroutine(WaitEndAnim());
        sucesName.text = succesname;
       
    }


    public void LoadEasisestSucces()
    {
        easiestSucces.Clear();
        int succes = 0;
        while (succes < 3 && lvl <= 4)
        {

            for (int i = 0; i < allTheSucces.Count; i++)
            {



                if (allTheSucces[i].locked)
                {
                    if (lvl == 0)
                    {
                        if (allTheSucces[i]._difficulté.ToString() == "Friendly" && easiestSucces.Count < 3)
                        {

                            easiestSucces.Add(allTheSucces[i]);
                            succes++;
                            continue;
                        }

                    }
                    if (lvl == 1)
                    {

                        if (allTheSucces[i]._difficulté.ToString() == "Easy" && easiestSucces.Count < 3)
                        {

                            easiestSucces.Add(allTheSucces[i]);
                            succes++;
                            continue;
                        }

                    }
                    if (lvl == 2)
                    {

                        if (allTheSucces[i]._difficulté.ToString() == "Normal" && easiestSucces.Count < 3)
                        {
                            easiestSucces.Add(allTheSucces[i]);
                            succes++;
                            continue;
                        }

                    }
                    if (lvl == 3)
                    {
                        if (allTheSucces[i]._difficulté.ToString() == "Hard" && easiestSucces.Count < 3)
                        {
                            easiestSucces.Add(allTheSucces[i]);
                            succes++;
                            continue;
                        }

                    }
                    if (lvl == 4)
                    {

                        if (allTheSucces[i]._difficulté.ToString() == "Impossible" && easiestSucces.Count < 3)
                        {
                            easiestSucces.Add(allTheSucces[i]);
                            succes++;
                            continue;
                        }

                    }



                }

            }
            lvl++;
        }

        if (easiestSucces.Count > 0)
        {
            titre1.text = easiestSucces[0]._difficulté.ToString();
            des1.text = easiestSucces[0].txtTitre;
        }
        else
        {
            titre1.text = "No Succes";
            des1.text = "Succes Done";
        }

        if (easiestSucces.Count > 1)
        {
            titre2.text = easiestSucces[1]._difficulté.ToString();
            des2.text = easiestSucces[1].txtTitre;
        }
        else
        {
            titre2.text = "No Succes";
            des2.text = "Succes Done";
        }
        if (easiestSucces.Count > 2)
        {
            titre3.text =easiestSucces[2]._difficulté.ToString();
            des3.text = easiestSucces[2].txtTitre;
        }
        else
        {
            titre3.text = "No Succes";
            des3.text = "Succes Done";
        }
    }
    IEnumerator WaitEndAnim()
    {
        yield return new WaitForSeconds(4.6f);
        Debug.Log("Mput bool false");
        succesAnim.SetBool("UNLOCK", false);
    }
}
