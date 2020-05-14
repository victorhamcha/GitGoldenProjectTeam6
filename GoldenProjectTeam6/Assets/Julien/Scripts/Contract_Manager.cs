using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Contract_Manager : MonoBehaviour
{
    public bool[] isDone = new bool[25];
    public List<GameObject> contrats = new List<GameObject>();

   /* public List<GameObject> veryEasy = new List<GameObject>();
    public List<GameObject> Easy = new List<GameObject>();
    public List<GameObject> Medium = new List<GameObject>();
    public List<GameObject> Hard = new List<GameObject>();
    public List<GameObject> veryHard = new List<GameObject>();*/

    public RectTransform posCard1;
    public RectTransform posCard2;
    public RectTransform posCard3;

    private int nbCard = 1;

    static public int rankingPoints = 0;

    private int percentageGame = 0;

    public int nbContractVE = 0, nbContractE = 0, nbContractM = 0, nbContractH = 0, nbContractVH = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        for(int i1 = 0; i1 < isDone.Length; i1++)
        {
            if(contrats.Count == 0)
            {
                // Mettre UI en mode "y'a plus rien comme contrat"
            }

            if(isDone[i1] == false && nbCard <= 3)
            {
                switch (contrats[i1].gameObject.tag)
                {
                    case "VeryEasy":
                        switch (nbCard)
                        {
                            case 1:
                                contrats[i1].transform.position = new Vector2(posCard1.transform.position.x, posCard1.transform.position.y);
                                contrats[i1].SetActive(true);
                                nbCard++;
                                rankingPoints += 1;
                                break;
                            case 2:
                                contrats[i1].transform.position = new Vector2(posCard2.transform.position.x, posCard2.transform.position.y);
                                contrats[i1].SetActive(true);
                                nbCard++;
                                rankingPoints += 1;
                                break;
                            case 3:
                                contrats[i1].transform.position = new Vector2(posCard3.transform.position.x, posCard3.transform.position.y);
                                contrats[i1].SetActive(true);
                                nbCard++;
                                rankingPoints += 1;
                                break; 
                        }
                        break;
                    case "Easy":
                        switch (nbCard)
                        {
                            case 1:
                                contrats[i1].transform.position = new Vector2(posCard1.transform.position.x, posCard1.transform.position.y);
                                contrats[i1].SetActive(true);
                                nbCard++;
                                rankingPoints += 2;
                                break;
                            case 2:
                                contrats[i1].transform.position = new Vector2(posCard2.transform.position.x, posCard2.transform.position.y);
                                contrats[i1].SetActive(true);
                                nbCard++;
                                rankingPoints += 2;
                                break;
                            case 3:
                                contrats[i1].transform.position = new Vector2(posCard3.transform.position.x, posCard3.transform.position.y);
                                contrats[i1].SetActive(true);
                                nbCard++;
                                rankingPoints += 2;
                                break;
                        }
                        break;
                    case "Medium":
                        switch (nbCard)
                        {
                            case 1:
                                contrats[i1].transform.position = new Vector2(posCard1.transform.position.x, posCard1.transform.position.y);
                                contrats[i1].SetActive(true);
                                contrats[i1].SetActive(true);
                                nbCard++;
                                rankingPoints += 3;
                                break;
                            case 2:
                                contrats[i1].transform.position = new Vector2(posCard2.transform.position.x, posCard2.transform.position.y);
                                contrats[i1].SetActive(true);
                                nbCard++;
                                rankingPoints += 3;
                                break;
                            case 3:
                                contrats[i1].transform.position = new Vector2(posCard3.transform.position.x, posCard3.transform.position.y);
                                contrats[i1].SetActive(true);
                                nbCard++;
                                rankingPoints += 3;
                                break;
                        }
                        break;
                    case "Hard":
                        switch (nbCard)
                        {
                            case 1:
                                contrats[i1].transform.position = new Vector2(posCard1.transform.position.x, posCard1.transform.position.y);
                                contrats[i1].SetActive(true);
                                nbCard++;
                                rankingPoints += 4;
                                break;
                            case 2:
                                contrats[i1].transform.position = new Vector2(posCard2.transform.position.x, posCard2.transform.position.y);
                                contrats[i1].SetActive(true);
                                nbCard++;
                                rankingPoints += 4;
                                break;
                            case 3:
                                contrats[i1].transform.position = new Vector2(posCard3.transform.position.x, posCard3.transform.position.y);
                                contrats[i1].SetActive(true);
                                nbCard++;
                                rankingPoints += 4;
                                break;
                        }
                        break;
                    case "VeryHard":
                        switch (nbCard)
                        {
                            case 1:
                                contrats[i1].transform.position = new Vector2(posCard1.transform.position.x, posCard1.transform.position.y);
                                contrats[i1].SetActive(true);
                                nbCard++;
                                rankingPoints += 5;
                                break;
                            case 2:
                                contrats[i1].transform.position = new Vector2(posCard2.transform.position.x, posCard2.transform.position.y);
                                contrats[i1].SetActive(true);
                                nbCard++;
                                rankingPoints += 5;
                                break;
                            case 3:
                                contrats[i1].transform.position = new Vector2(posCard3.transform.position.x, posCard3.transform.position.y);
                                contrats[i1].SetActive(true); nbCard++;
                                nbCard++;
                                rankingPoints += 5;
                                break;
                        }
                        break;

                }
            }
        }

        percentageGame = rankingPoints * 100 / (nbContractVE * 1 + nbContractE * 2 + nbContractM * 3 + nbContractH * 4 + nbContractVH * 5);
        Debug.Log(percentageGame);


        // Quand un contrat est fini, on met son IsDone équivalent à true


        /*

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
                            rankingPoints += 1;
                            break;
                        case 2:
                            Debug.Log(veryEasy[0] + " " + nbCard);
                            veryEasy[0].transform.position = new Vector2(posCard2.transform.position.x, posCard2.transform.position.y);
                            veryEasy[0].gameObject.SetActive(true);
                            veryEasy.RemoveAt(0);
                            nbCard++;
                            rankingPoints += 1;
                            break;
                        case 3:
                            Debug.Log(veryEasy[0] + " " + nbCard);
                            veryEasy[0].transform.position = new Vector2(posCard3.transform.position.x, posCard3.transform.position.y);
                            veryEasy[0].gameObject.SetActive(true);
                            veryEasy.RemoveAt(0);
                            nbCard++;
                            rankingPoints += 1;
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
                            rankingPoints += 2;
                            break;
                        case 2:
                            Debug.Log(Easy[0] + " " + nbCard);
                            Easy[0].transform.position = new Vector2(posCard2.transform.position.x, posCard2.transform.position.y);
                            Easy[0].gameObject.SetActive(true);
                            Easy.RemoveAt(0);
                            nbCard++;
                            rankingPoints += 2;
                            break;
                        case 3:
                            Debug.Log(Easy[0] + " " + nbCard);
                            Easy[0].transform.position = new Vector2(posCard3.transform.position.x, posCard3.transform.position.y);
                            Easy[0].gameObject.SetActive(true);
                            Easy.RemoveAt(0);
                            nbCard++;
                            rankingPoints += 2;
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
                            rankingPoints += 3;
                            break;
                        case 2:
                            Debug.Log(Medium[0] + " " + nbCard);
                            Medium[0].transform.position = new Vector2(posCard2.transform.position.x, posCard2.transform.position.y);
                            Medium[0].gameObject.SetActive(true);
                            Medium.RemoveAt(0);
                            nbCard++;
                            rankingPoints += 3;
                            break;
                        case 3:
                            Debug.Log(Medium[0] + " " + nbCard);
                            Medium[0].transform.position = new Vector2(posCard3.transform.position.x, posCard3.transform.position.y);
                            Medium[0].gameObject.SetActive(true);
                            Medium.RemoveAt(0);
                            nbCard++;
                            rankingPoints += 3;
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
                            rankingPoints += 4;
                            break;
                        case 2:
                            Debug.Log(Hard[0] + " " + nbCard);
                            Hard[0].transform.position = new Vector2(posCard2.transform.position.x, posCard2.transform.position.y);
                            Hard[0].gameObject.SetActive(true);
                            Hard.RemoveAt(0);
                            nbCard++;
                            rankingPoints += 4;
                            break;
                        case 3:
                            Debug.Log(Hard[0] + " " + nbCard);
                            Hard[0].transform.position = new Vector2(posCard3.transform.position.x, posCard3.transform.position.y);
                            Hard[0].gameObject.SetActive(true);
                            Hard.RemoveAt(0);
                            nbCard++;
                            rankingPoints += 4;
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
                            rankingPoints += 5;
                            break;
                        case 2:
                            Debug.Log(veryHard[0] + " " + nbCard);
                            veryHard[0].transform.position = new Vector2(posCard2.transform.position.x, posCard2.transform.position.y);
                            veryHard[0].gameObject.SetActive(true);
                            veryHard.RemoveAt(0);
                            nbCard++;
                            rankingPoints += 5;
                            break;
                        case 3:
                            Debug.Log(veryHard[0] + " " + nbCard);
                            veryHard[0].transform.position = new Vector2(posCard3.transform.position.x, posCard3.transform.position.y);
                            veryHard[0].gameObject.SetActive(true);
                            veryHard.RemoveAt(0);
                            nbCard++;
                            rankingPoints += 5;
                            break;

                    }
                }
                else
                {
                    Debug.Log("liste vide");
                    // Bah y'a plus rien
                }

                */
    }
}
