﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

#if UNITY_EDITOR
using UnityEditor;
#endif

[CreateAssetMenu(fileName = "New Card", menuName = "Card")]
public class CardScriptableObject : ScriptableObject
{
    [Header("VISUEL")]
    [TextArea(1, 1)] public string _title;
    [Space(10)]
    public Sprite _image;
    [Space(10)]
    [TextArea(5, 1)] public string _description;


    [HideInInspector] public int _cardID;

    [HideInInspector] public bool _cardAlreadyDraw;
    [HideInInspector] public bool _canSlideUp;
    [HideInInspector] public bool _canSlideRight;
    [HideInInspector] public bool _canSlideLeft;

    [HideInInspector] public EnumSuccess._enumSuccess _enumSuccessRight;
    [HideInInspector] public EnumSuccess._enumSuccess _enumSuccessLeft;
    [HideInInspector] public EnumSuccess._enumSuccess _enumSuccessUp;
    [HideInInspector] public EnumSuccess._enumSuccess _enumSuccessDeath;

    [HideInInspector] public CardScriptableObject _isNextCardUp;
    [TextArea(5, 1)] [HideInInspector] public string _isSwipingUpDescription;

    [HideInInspector] public CardScriptableObject _isNextCardRight;
    [HideInInspector] public CardScriptableObject _isNextCardLinkedIn;
    [HideInInspector] public CardScriptableObject _isPreviousCardLinkedIn;
    [HideInInspector] public Color colorTextUp;

    [HideInInspector] public string _isSwipingRightDescription;
    [HideInInspector] public CardScriptableObject _isNextCardLeft;
    [HideInInspector] public string _isSwipingLeftDescription;
    [HideInInspector] public CardScriptableObject _firstCardOfEvent;
    [Space(10)]
    [HideInInspector] public bool _isSuccess;
    [HideInInspector] public bool _hasSpecialVFX;


    [HideInInspector] public bool _isEndingEvent;

    [HideInInspector] public bool _eventCanBePlayOne;

    [HideInInspector] public string _enumSuccessString;
    [HideInInspector] public string _enumDirectpionSwipeString;
    [HideInInspector] public string _enumPlaceString;
    [HideInInspector] public List<string> _enumObjectString;

    //[HideInInspector] public List<int> _conditionObjetListForCardManager;

    [HideInInspector] public Color _colorInspector = Color.red;


    [HideInInspector] public List<EnumListObject._objectList> _conditionsObjectList = new List<EnumListObject._objectList>();

    [HideInInspector] public EnumListObject._objectList _enumObjectToUnlockRight;
    [HideInInspector] public EnumListObject._objectList _enumObjectToUnlockLeft;
    [HideInInspector] public EnumListObject._objectList _enumObjectToUnlockUp;


    public EnumPlaceGame._enumPlace _placeEnum;

    public bool isLinkedIn = false;
    [HideInInspector] public string url;
    [HideInInspector] public bool _isDeadCard;
    [HideInInspector] public bool _isContratCard;

    [Space(20)]
    public List<EnumListObject._objectList> _enumObjectConditionList;

    [HideInInspector] public EnumDirectionSwipeCard._swipeDirection _swipeDirectionEnd;

    [HideInInspector] public GameObject _specialVFX;

    void ForceSerialization()
    {
#if UNITY_EDITOR
        UnityEditor.EditorUtility.SetDirty(this);
#endif
    }
}

#if UNITY_EDITOR
    [CustomEditor(typeof(CardScriptableObject))]
public class CardScriptableObject_Editor : Editor
{
    [HideInInspector] public EnumDirectionSwipeCard._swipeDirection _swipeDirectionObject;
    [HideInInspector] public EnumListObject._objectList _enumObjectCondition;

    int _lineSize;

    public override void OnInspectorGUI()
    {
        GUIStyle myStyleBold = new GUIStyle();
        myStyleBold.fontStyle = FontStyle.Bold;

        DrawDefaultInspector();

        CardScriptableObject script = (CardScriptableObject)target;

        if(!script.isLinkedIn)
        {
            GUI.backgroundColor = script._colorInspector;
            script._isContratCard = EditorGUILayout.Toggle("Is a contract card", script._isContratCard);
            GUI.backgroundColor = Color.white;
            EditorGUILayout.Space(20);

            if (!script._isContratCard) // if bool is true, show other fields
            {
                GUI.backgroundColor = script._colorInspector;
                script._isDeadCard = EditorGUILayout.Toggle("Is a dead Card", script._isDeadCard);
                GUI.backgroundColor = Color.white;
                EditorGUILayout.Space(20);


                if (!script._isDeadCard) // if bool is true, show other fields
                {
                    GUI.backgroundColor = script._colorInspector;
                    script._canSlideUp = EditorGUILayout.Toggle("Can Slide Up", script._canSlideUp);
                    GUI.backgroundColor = Color.white;

                    if (script._canSlideUp)
                    {
                        //EditorGUILayout.SelectableLabel("If the card can Slide Up", myStyleBold);
                        script._isNextCardUp = EditorGUILayout.ObjectField("Next Card By Sliding UP", script._isNextCardUp, typeof(CardScriptableObject), true) as CardScriptableObject;
                        script._isSwipingUpDescription = EditorGUILayout.TextField("Description when player slide UP", script._isSwipingUpDescription);

                        script._enumObjectToUnlockUp = (EnumListObject._objectList)EditorGUILayout.EnumPopup("Object to unlock UP", script._enumObjectToUnlockUp);

                        script._enumSuccessUp = (EnumSuccess._enumSuccess)EditorGUILayout.EnumPopup("Success to Unlock UP", script._enumSuccessUp);
                        EditorGUILayout.Space(20);

                        #region Commentaire

                        /*if(_lineSize == 0 && script._conditionsObjectList.Count != 0)
                        {
                            _lineSize = script._conditionsObjectList.Count;
                        }
                        _lineSize = EditorGUILayout.IntField("Conditions numbers size", _lineSize);

                        if(_lineSize != script._conditionsObjectList.Count)
                        {
                            if(_lineSize < script._conditionsObjectList.Count)
                            {
                                script._conditionsObjectList.RemoveAt(script._conditionsObjectList.Count - 1);
                            }
                            else if(_lineSize > script._conditionsObjectList.Count)
                            {
                                for (int i = 0; i < _lineSize - script._conditionsObjectList.Count; i++)
                                {
                                    script._conditionsObjectList.Add(0);
                                }
                            }
                        }
                        for (int i = 0; i < script._conditionsObjectList.Count; i++)
                        {
                            _enumObjectCondition = (EnumListObject._objectList)EditorGUILayout.EnumPopup("Condition " + i, _enumObjectCondition);
                            //_enumObjectConditionList[i] = _enumObjectCondition;
                        }

                        //script._enumObjectConditionListPublic = _enumObjectConditionList;*/

                        //EditorGUILayout.SelectableLabel("SWIPE", myStyleBold);
                        //EditorGUILayout.SelectableLabel("RIGHT", myStyleBold);
                        #endregion
                    }
                    EditorGUILayout.Space(10);
                    GUI.backgroundColor = script._colorInspector;
                    script._canSlideRight = EditorGUILayout.Toggle("Can Slide Right", script._canSlideRight);
                    GUI.backgroundColor = Color.white;


                    if (script._canSlideRight)
                    {
                        script._isNextCardRight = EditorGUILayout.ObjectField("Next Card By Sliding RIGHT", script._isNextCardRight, typeof(CardScriptableObject), true) as CardScriptableObject;
                        script._isSwipingRightDescription = EditorGUILayout.TextField("Description when player slide RIGHT", script._isSwipingRightDescription);
                        script._enumObjectToUnlockRight = (EnumListObject._objectList)EditorGUILayout.EnumPopup("Object to unlock RIGHT", script._enumObjectToUnlockRight);

                        script._enumSuccessRight = (EnumSuccess._enumSuccess)EditorGUILayout.EnumPopup("Success to Unlock RIGHT", script._enumSuccessRight);
                        EditorGUILayout.Space(20);
                    }
                    EditorGUILayout.Space(10);
                    GUI.backgroundColor = script._colorInspector;
                    script._canSlideLeft = EditorGUILayout.Toggle("Can Slide Left", script._canSlideLeft);
                    GUI.backgroundColor = Color.white;


                    if (script._canSlideLeft)
                    {
                        script._isNextCardLeft = EditorGUILayout.ObjectField("Next Card By Sliding LEFT", script._isNextCardLeft, typeof(CardScriptableObject), true) as CardScriptableObject;
                        script._isSwipingLeftDescription = EditorGUILayout.TextField("Description when player slide LEFT", script._isSwipingLeftDescription);
                        script._enumObjectToUnlockLeft = (EnumListObject._objectList)EditorGUILayout.EnumPopup("Object to unlock LEFT", script._enumObjectToUnlockLeft);

                        script._enumSuccessLeft = (EnumSuccess._enumSuccess)EditorGUILayout.EnumPopup("Success to Unlock LEFT", script._enumSuccessLeft);
                        EditorGUILayout.Space(20);
                    }
                    EditorGUILayout.Space(10);
                    GUI.backgroundColor = script._colorInspector;
                    script._isEndingEvent = EditorGUILayout.Toggle("This Card Finish an Event", script._isEndingEvent);
                    GUI.backgroundColor = Color.white;

                    if (script._isEndingEvent)
                    {
                        script._eventCanBePlayOne = EditorGUILayout.Toggle("This Card Can Be Play Once", script._eventCanBePlayOne);
                        script._firstCardOfEvent = EditorGUILayout.ObjectField("First card of this event", script._firstCardOfEvent, typeof(CardScriptableObject), true) as CardScriptableObject;
                        script._swipeDirectionEnd = (EnumDirectionSwipeCard._swipeDirection)EditorGUILayout.EnumPopup("Success to Unlock LEFT", script._swipeDirectionEnd);
                        EditorGUILayout.Space(20);
                    }


                }
                else
                {
                    EditorGUILayout.Space(20);
                    script._enumSuccessDeath = (EnumSuccess._enumSuccess)EditorGUILayout.EnumPopup("Success to Unlock when you die", script._enumSuccessDeath);

                }


                EditorGUILayout.Space(10);
                GUI.backgroundColor = script._colorInspector;
                script._hasSpecialVFX = EditorGUILayout.Toggle("This Card has a special VFX", script._hasSpecialVFX);
                GUI.backgroundColor = Color.white;

                if (script._hasSpecialVFX)
                {
                    script._specialVFX = EditorGUILayout.ObjectField("Special VFX GameObject", script._specialVFX, typeof(GameObject), true) as GameObject;
                    EditorGUILayout.Space(20);
                }
            }
        }
        else
        {

            script.colorTextUp = EditorGUILayout.ColorField("Color Text", script.colorTextUp);

            GUI.backgroundColor = script._colorInspector;
            script._canSlideUp = EditorGUILayout.Toggle("Can Slide Up", script._canSlideUp);
            GUI.backgroundColor = Color.white;

            script._isNextCardLinkedIn = EditorGUILayout.ObjectField("Previous Card By Sliding", script._isNextCardLinkedIn, typeof(CardScriptableObject), true) as CardScriptableObject;
            script._isPreviousCardLinkedIn = EditorGUILayout.ObjectField("Next Card By Sliding", script._isPreviousCardLinkedIn, typeof(CardScriptableObject), true) as CardScriptableObject;
            script._isSwipingLeftDescription = EditorGUILayout.TextField("Description when player slide LEFT", script._isSwipingLeftDescription);
            script._isSwipingRightDescription = EditorGUILayout.TextField("Description when player slide RIGHT", script._isSwipingRightDescription);
            script.url = EditorGUILayout.TextField("URL LinkedIn", script.url);
            script._isSwipingUpDescription = EditorGUILayout.TextField("Description when player slide UP", script._isSwipingUpDescription);


            
        }

        if (GUILayout.Button("Update Valeurs"))
        {
#if UNITY_EDITOR
            EditorUtility.SetDirty(script);
#endif
        }


    }
}
#endif
