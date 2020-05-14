using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DataSheetTypes;
using System.IO;
#if UNITY_EDITOR
using UnityEditor;
#endif

[CreateAssetMenu(fileName = "New CardSHeet", menuName = "CardSheet")]
public class UpdateCards : ScriptableObject
{
    public Test sheettest;
    public List<CardScriptableObject> cards;
  

    
    public void CreateCards()
    {
        foreach (DataSheetTypes.Test card in DataSheet.test)
        {
            bool create = true;
            for (int i = 0; i < cards.Count; i++)
            {
                if (card.name == cards[i].name)
                {
                    create = false;
                    break;
                }
            }
            if (create)
            {
                if (!Directory.Exists("Assets/TheCards/"+card.place+"/"+card._event))
                {
                    //if it doesn't, create it
                    Directory.CreateDirectory("Assets/TheCards/" + card.place + "/" + card._event);

                }
                CardScriptableObject asset = ScriptableObject.CreateInstance<CardScriptableObject>();

                AssetDatabase.CreateAsset(asset, "Assets/TheCards/" + card.place + "/" + card._event +"/"+ card.name + ".asset");
                AssetDatabase.SaveAssets();

                EditorUtility.FocusProjectWindow();

                Selection.activeObject = asset;
                //cards.Add(asset);
                //if(card.iD!=cards.Count-1)
                //{
                cards.Insert(card.iD, asset);
                //}
            }
            


        }
        Update();
    }

    public void Update()
    {
        foreach (DataSheetTypes.Test card in DataSheet.test)
        {
            bool update = false;
            CardScriptableObject change = null;
            for (int i = 0; i < cards.Count; i++)
            {
                if (card.name == cards[i].name)
                {
                    update = true;
                    change = cards[i];
                    break;
                }
            }
            if (update)
            {
                change._title = card.titreCarte;
                change._image = (Sprite)AssetDatabase.LoadAssetAtPath("Assets/AssetsGraphiques/Card_Background/" + card.sprite + ".png", typeof(Sprite));
                change._description = card.description;
                change._placeEnum = (EnumPlaceGame._enumPlace)Enum.Parse(typeof(EnumPlaceGame._enumPlace), card.place);
                if (card.mort)
                {
                    change._isDeadCard = card.mort;
                    change._enumSuccessDeath = (EnumSuccess._enumSuccess)Enum.Parse(typeof(EnumSuccess._enumSuccess), card.successIfDie);
                }
                else
                {

                   



                    if (card.canSlideUp)
                    {
                        change._canSlideUp = card.canSlideUp;
                        change._isSwipingUpDescription = card.upSlideText;
                        if (card.upSuccesUnlock != "")
                        {
                            change._enumSuccessUp = (EnumSuccess._enumSuccess)Enum.Parse(typeof(EnumSuccess._enumSuccess), card.upSuccesUnlock);
                        }
                        if (card.upObjectUnlock != "")
                        {
                            change._enumObjectToUnlockUp = (EnumListObject._objectList)Enum.Parse(typeof(EnumListObject._objectList), card.upObjectUnlock);
                        }
                        if (card.upCardID != 0)
                        {
                            change._isNextCardUp = cards[card.upCardID];
                        }
                        else
                        {
                            change._isNextCardUp = change;
                        }
                    }

                    //LEFT//
                    change._canSlideLeft = true;
                    change._isSwipingLeftDescription = card.leftSlideText;
                    if (card.leftSucessUnlock != "")
                    {
                        change._enumSuccessLeft = (EnumSuccess._enumSuccess)Enum.Parse(typeof(EnumSuccess._enumSuccess), card.leftSucessUnlock);
                    }
                    if (card.leftObjectUnlock != "")
                    {
                        change._enumObjectToUnlockLeft = (EnumListObject._objectList)Enum.Parse(typeof(EnumListObject._objectList), card.leftObjectUnlock);
                    }
                    if (card.leftCardID != 0)
                    {
                        change._isNextCardLeft = cards[card.leftCardID];
                    }
                    else
                    {
                        change._isNextCardLeft = change;
                    }
                    //RIGHT//
                    change._canSlideRight = true;
                    change._isSwipingRightDescription = card.rightSlideText;
                    if (card.rightSucessUnlock != "")
                    {
                        change._enumSuccessRight = (EnumSuccess._enumSuccess)Enum.Parse(typeof(EnumSuccess._enumSuccess), card.rightSucessUnlock);
                    }
                    if (card.rightObjectUnlock != "")
                    {
                        change._enumObjectToUnlockRight = (EnumListObject._objectList)Enum.Parse(typeof(EnumListObject._objectList), card.rightObjectUnlock);
                    }
                    if (card.rightCardID != 0)
                    {
                        change._isNextCardRight = cards[card.rightCardID];
                    }
                    else
                    {
                        change._isNextCardRight = change;
                    }

                    if (card.finishEvent)
                    {
                        change._isEndingEvent = card.finishEvent;
                        change._eventCanBePlayOne = card.playedOnce;
                        change._firstCardOfEvent = cards[card.firstOfEventID];
                    }

                    if (card.hasVFX)
                    {
                        change._specialVFX = (GameObject)AssetDatabase.LoadAssetAtPath("Assets/AssetsGraphiques/" + card.sprite + ".png", typeof(GameObject));
                    }
                }

            }
        }
    }

    public void UpdateList()
    {
        foreach (DataSheetTypes.Test card in DataSheet.test)
        {
            bool update = false;
            CardScriptableObject change = null;
            for (int i = 0; i < cards.Count; i++)
            {
                if (card.name == cards[i].name)
                {
                    update = true;
                    change = cards[i];
                    break;
                }
            }
            if (update)
            {
                change._enumObjectConditionList.Clear();

                if (card.unlockUpNbrObject > 0)
                {


                    for (int i = 0; i < card.unlockUpNbrObject; i++)
                    {
                        Debug.Log("change");
                        if (i == 0)
                        {
                            change._enumObjectConditionList.Add((EnumListObject._objectList)Enum.Parse(typeof(EnumListObject._objectList), card.firstObject));
                        }
                        else
                        {
                            change._enumObjectConditionList.Add((EnumListObject._objectList)Enum.Parse(typeof(EnumListObject._objectList), card.secondObject));
                        }

                    }
                }
            }
        }
    }



    //asset._image = (Sprite)AssetDatabase.LoadAssetAtPath("Assets/AssetsGraphiques/" + card.imageName+".png", typeof(Sprite)); 
}
#if UNITY_EDITOR
[CustomEditor(typeof(UpdateCards))]
public class CardsEditor : Editor
{
    public override void OnInspectorGUI()
    {
        GUIStyle myStyleBold = new GUIStyle();
        myStyleBold.fontStyle = FontStyle.Bold;

        DrawDefaultInspector();

        UpdateCards script = (UpdateCards)target;
      
        GUI.backgroundColor = Color.white;
        
       if(GUILayout.Button("Update Valeurs"))
       {
            script.Update();
       }
        if (GUILayout.Button("Update Cards"))
        {
            script.CreateCards();
        }

        if (GUILayout.Button("Update Lists"))
        {
            script.UpdateList();
        }
    }
}
#endif