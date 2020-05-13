using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Contract_Manager : MonoBehaviour
{
    public List<GameObject> veryEasy = new List<GameObject>();
    public List<GameObject> Easy = new List<GameObject>();
    public List<GameObject> Medium = new List<GameObject>();
    public List<GameObject> Hard = new List<GameObject>();
    public List<GameObject> veryHard = new List<GameObject>();

    public RectTransform posCard1;
    public RectTransform posCard2;
    public RectTransform posCard3;

    private int nbCard = 1;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (veryEasy.Count != 0)
        {
            Debug.Log("Go in Very Easy");
            switch (nbCard)
            {
                case 1:
                    Debug.Log(veryEasy[0] + " " + nbCard);
                    veryEasy[0].transform.position = new Vector2(posCard1.transform.position.x, posCard1.transform.position.y);
                    veryEasy[0].gameObject.SetActive(true);
                    veryEasy.RemoveAt(0);
                    nbCard++;
                    break;
                case 2:
                    Debug.Log(veryEasy[0] + " " + nbCard);
                    veryEasy[0].transform.position = new Vector2(posCard2.transform.position.x, posCard2.transform.position.y);
                    veryEasy[0].gameObject.SetActive(true);
                    veryEasy.RemoveAt(0);
                    nbCard++;
                    break;
                case 3:
                    Debug.Log(veryEasy[0] + " " + nbCard);
                    veryEasy[0].transform.position = new Vector2(posCard3.transform.position.x, posCard3.transform.position.y);
                    veryEasy[0].gameObject.SetActive(true);
                    veryEasy.RemoveAt(0);
                    nbCard++;
                    break;

            }


        }
        else if (Easy.Count != 0)
        {
            switch (nbCard)
            {
                case 1:
                    Debug.Log(Easy[0] + " " + nbCard);
                    Easy[0].transform.position = new Vector2(posCard1.transform.position.x, posCard1.transform.position.y);
                    Easy[0].gameObject.SetActive(true);
                    Easy.RemoveAt(0);
                    nbCard++;
                    break;
                case 2:
                    Debug.Log(Easy[0] + " " + nbCard);
                    Easy[0].transform.position = new Vector2(posCard2.transform.position.x, posCard2.transform.position.y);
                    Easy[0].gameObject.SetActive(true);
                    Easy.RemoveAt(0);
                    nbCard++;
                    break;
                case 3:
                    Debug.Log(Easy[0] + " " + nbCard);
                    Easy[0].transform.position = new Vector2(posCard3.transform.position.x, posCard3.transform.position.y);
                    Easy[0].gameObject.SetActive(true);
                    Easy.RemoveAt(0);
                    nbCard++;
                    break;

            }
        }
        else if (Medium.Count != 0)
        {
            switch (nbCard)
            {
                case 1:
                    Debug.Log(Medium[0] + " " + nbCard);
                    Medium[0].transform.position = new Vector2(posCard1.transform.position.x, posCard1.transform.position.y);
                    Medium[0].gameObject.SetActive(true);
                    Medium.RemoveAt(0);
                    nbCard++;
                    break;
                case 2:
                    Debug.Log(Medium[0] + " " + nbCard);
                    Medium[0].transform.position = new Vector2(posCard2.transform.position.x, posCard2.transform.position.y);
                    Medium[0].gameObject.SetActive(true);
                    Medium.RemoveAt(0);
                    nbCard++;
                    break;
                case 3:
                    Debug.Log(Medium[0] + " " + nbCard);
                    Medium[0].transform.position = new Vector2(posCard3.transform.position.x, posCard3.transform.position.y);
                    Medium[0].gameObject.SetActive(true);
                    Medium.RemoveAt(0);
                    nbCard++;
                    break;

            }
        }
        else if (Hard.Count != 0)
        {
            switch (nbCard)
            {
                case 1:
                    Debug.Log(Hard[0] + " " + nbCard);
                    Hard[0].transform.position = new Vector2(posCard1.transform.position.x, posCard1.transform.position.y);
                    Hard[0].gameObject.SetActive(true);
                    Hard.RemoveAt(0);
                    nbCard++;
                    break;
                case 2:
                    Debug.Log(Hard[0] + " " + nbCard);
                    Hard[0].transform.position = new Vector2(posCard2.transform.position.x, posCard2.transform.position.y);
                    Hard[0].gameObject.SetActive(true);
                    Hard.RemoveAt(0);
                    nbCard++;
                    break;
                case 3:
                    Debug.Log(Hard[0] + " " + nbCard);
                    Hard[0].transform.position = new Vector2(posCard3.transform.position.x, posCard3.transform.position.y);
                    Hard[0].gameObject.SetActive(true);
                    Hard.RemoveAt(0);
                    nbCard++;
                    break;

            }
        }
        else if (veryHard.Count != 0)
        {
            switch (nbCard)
            {
                case 1:
                    Debug.Log(veryHard[0] + " " + nbCard);
                    veryHard[0].transform.position = new Vector2(posCard1.transform.position.x, posCard1.transform.position.y);
                    veryHard[0].gameObject.SetActive(true);
                    veryHard.RemoveAt(0);
                    nbCard++;
                    break;
                case 2:
                    Debug.Log(veryHard[0] + " " + nbCard);
                    veryHard[0].transform.position = new Vector2(posCard2.transform.position.x, posCard2.transform.position.y);
                    veryHard[0].gameObject.SetActive(true);
                    veryHard.RemoveAt(0);
                    nbCard++;
                    break;
                case 3:
                    Debug.Log(veryHard[0] + " " + nbCard);
                    veryHard[0].transform.position = new Vector2(posCard3.transform.position.x, posCard3.transform.position.y);
                    veryHard[0].gameObject.SetActive(true);
                    veryHard.RemoveAt(0);
                    nbCard++;
                    break;

            }
        }
        else
        {
            Debug.Log("liste vide");
            // Bah y'a plus rien
        }
    }
}
