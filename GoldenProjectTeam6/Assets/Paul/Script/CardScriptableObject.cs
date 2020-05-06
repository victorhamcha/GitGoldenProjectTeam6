using System;
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

    


    [HideInInspector] public bool _canSlideUp;
    [HideInInspector] public CardScriptableObject _isNextCardUp;
    [TextArea(5, 1)] [HideInInspector] public string _isSwipingUpDescription;

    [HideInInspector] public CardScriptableObject _isNextCardRight;
    [HideInInspector] public string _isSwipingRightDescription;
    [HideInInspector] public CardScriptableObject _isNextCardLeft;
    [HideInInspector] public string _isSwipingLeftDescription;
    [HideInInspector] public CardScriptableObject _firstCardOfEvent;
    [Space(10)]
    [HideInInspector] public bool _isSuccess;
    [Space(10)]
    [HideInInspector] public bool _isUnlockingObject;
    [HideInInspector] public int _findObjectInListToggle;

    [HideInInspector] public bool _isEndingEvent;

    [HideInInspector] public bool _eventCanBePlayOne;

    [HideInInspector] public string _enumSuccessString;
    [HideInInspector] public string _enumDirectpionSwipeString;
    [HideInInspector] public string _enumPlaceString;
    [HideInInspector] public List<string> _enumObjectString;

    //[HideInInspector] public List<int> _conditionObjetListForCardManager;

    [HideInInspector] public Color _colorInspector = Color.red;


    [HideInInspector] public List<EnumListObject._objectList> _conditionsObjectList = new List<EnumListObject._objectList>();
    
    [HideInInspector] public EnumListObject._objectList _enumObjectToUnlock;

    public EnumPlaceGame._enumPlace _placeEnum;

    public bool _isDeadCard;

    [Space(20)]
    public List<EnumListObject._objectList> _enumObjectConditionList;



}

#if UNITY_EDITOR
[CustomEditor(typeof(CardScriptableObject))]
public class CardScriptableObject_Editor : Editor
{
    [HideInInspector] public EnumSuccess._enumSuccess _enumSuccess;
    [HideInInspector] public EnumDirectionSwipeCard._swipeDirection _swipeDirectionObject;
    [HideInInspector] public EnumDirectionSwipeCard._swipeDirection _swipeDirectionEnd;
    [HideInInspector] public EnumListObject._objectList _enumObjectCondition;

    int _lineSize;

    public override void OnInspectorGUI()
    {
        GUIStyle myStyleBold = new GUIStyle();
        myStyleBold.fontStyle = FontStyle.Bold;

        DrawDefaultInspector();

        CardScriptableObject script = (CardScriptableObject)target;
        


        if (!script._isDeadCard) // if bool is true, show other fields
        {
            GUI.backgroundColor = script._colorInspector;
            script._canSlideUp = EditorGUILayout.Toggle("Unlock Card Slide Up", script._canSlideUp);
            GUI.backgroundColor = Color.white;

            if (script._canSlideUp)
            {
                //EditorGUILayout.SelectableLabel("If the card can Slide Up", myStyleBold);
                script._isNextCardUp = EditorGUILayout.ObjectField("Next Card By Sliding UP", script._isNextCardUp, typeof(CardScriptableObject), true) as CardScriptableObject;
                script._isSwipingUpDescription = EditorGUILayout.TextField("Description when player slide UP", script._isSwipingUpDescription);
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
                EditorGUILayout.Space(20);

            }
            EditorGUILayout.Space(10);
            //EditorGUILayout.SelectableLabel("SWIPE", myStyleBold);
            //EditorGUILayout.SelectableLabel("RIGHT", myStyleBold);

            script._isNextCardRight = EditorGUILayout.ObjectField("Next Card By Sliding RIGHT", script._isNextCardRight, typeof(CardScriptableObject), true) as CardScriptableObject;
            script._isSwipingRightDescription = EditorGUILayout.TextField("Description when player slide RIGHT", script._isSwipingRightDescription);
            EditorGUILayout.Space(10);
            //EditorGUILayout.SelectableLabel("LEFT", myStyleBold);
            

            script._isNextCardLeft = EditorGUILayout.ObjectField("Next Card By Sliding LEFT", script._isNextCardLeft, typeof(CardScriptableObject), true) as CardScriptableObject;
            script._isSwipingLeftDescription = EditorGUILayout.TextField("Description when player slide LEFT", script._isSwipingLeftDescription);

            EditorGUILayout.Space(20);

            EditorGUILayout.Space(10);
            GUI.backgroundColor = script._colorInspector;
            script._isSuccess = EditorGUILayout.Toggle("Unlock Success", script._isSuccess);
            GUI.backgroundColor = Color.white;


            if (script._isSuccess)
            {
                //EditorGUILayout.SelectableLabel("Success To Unlock", myStyleBold);
                _enumSuccess = (EnumSuccess._enumSuccess)EditorGUILayout.EnumPopup("Success to Unlock", _enumSuccess);
                script._enumSuccessString = _enumSuccess.ToString();
                EditorGUILayout.Space(20);
            }


            GUI.backgroundColor = script._colorInspector;
            script._isUnlockingObject = EditorGUILayout.Toggle("Unlock Object", script._isUnlockingObject);
            GUI.backgroundColor = Color.white;

            if (script._isUnlockingObject)
            {
                //EditorGUILayout.SelectableLabel("Object To Unlock", myStyleBold);
                _swipeDirectionObject = (EnumDirectionSwipeCard._swipeDirection)EditorGUILayout.EnumPopup("Direction to unlock Object", _swipeDirectionObject);
                script._enumDirectpionSwipeString = _enumSuccess.ToString();
                script._enumObjectToUnlock = (EnumListObject._objectList)EditorGUILayout.EnumPopup("Object to unlock", script._enumObjectToUnlock);
                EditorGUILayout.Space(20);
            }


            GUI.backgroundColor = script._colorInspector;
            script._isEndingEvent = EditorGUILayout.Toggle("This Card Finish an Event", script._isEndingEvent);
            GUI.backgroundColor = Color.white;

            if (script._isEndingEvent)
            {
                script._eventCanBePlayOne = EditorGUILayout.Toggle("This Card Can Be Play Once", script._eventCanBePlayOne);
                _swipeDirectionEnd = (EnumDirectionSwipeCard._swipeDirection)EditorGUILayout.EnumPopup("Direction end event    ", _swipeDirectionEnd);
                script._firstCardOfEvent = EditorGUILayout.ObjectField("First card of this event", script._firstCardOfEvent, typeof(CardScriptableObject), true) as CardScriptableObject;
                EditorGUILayout.Space(20);
            }

            



        }
    }
}
#endif
