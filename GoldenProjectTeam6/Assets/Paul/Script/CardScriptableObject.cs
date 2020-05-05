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
    [Header("Visuel")]
    [TextArea(1, 1)] public string _title;
    public Sprite _image;
    [TextArea(5, 1)] public string _description;


    [HideInInspector] // HideInInspector makes sure the default inspector won't show other variables
    public bool _isDeadCard;


    [HideInInspector] public bool _canSlideUp;
    [HideInInspector] public CardScriptableObject _isNextCardUp;

    [HideInInspector] public CardScriptableObject _isNextCardRight;
    [HideInInspector] public CardScriptableObject _isNextCardLeft;
    [Space(10)]
    [HideInInspector] public bool _isSuccess;
    [Space(10)]
    [HideInInspector] public bool _isUnlockingObject;
    [HideInInspector] public int _findObjectInListToggle;

    [HideInInspector] public string _enumSuccessString;
    [HideInInspector] public string _enumDirectpionSwipeString;

    [HideInInspector] public int _numberLine;
    [HideInInspector] public List<int> _conditionObjetListForCardManager;

    [HideInInspector] public Color _colorInspector = Color.red;


}

#if UNITY_EDITOR
[CustomEditor(typeof(CardScriptableObject))]
public class CardScriptableObject_Editor : Editor
{
    [HideInInspector] public EnumSuccess._enumSuccess _enumSuccess;
    [HideInInspector] public EnumDirectionSwipeCard._swipeDirection _swipeDirection;

    [HideInInspector] public List <int> _conditionsObjectList = new List<int>();

    public override void OnInspectorGUI()
    {
        DrawDefaultInspector(); // for other non-HideInInspector fields

        CardScriptableObject script = (CardScriptableObject)target;
        //script._colorInspector = EditorGUILayout.ColorField("Color of the background Toggle", script._colorInspector);

        // draw checkbox for the bool
        GUI.backgroundColor = script._colorInspector;
        script._isDeadCard = EditorGUILayout.Toggle("Is Dead Card", script._isDeadCard);
        GUI.backgroundColor = Color.white;


        if (!script._isDeadCard) // if bool is true, show other fields
        {
            script._isNextCardRight = EditorGUILayout.ObjectField("Next Card By Sliding RIGHT", script._isNextCardRight, typeof(CardScriptableObject), true) as CardScriptableObject;
            script._isNextCardLeft = EditorGUILayout.ObjectField("Next Card By Sliding LEFT", script._isNextCardLeft, typeof(CardScriptableObject), true) as CardScriptableObject;

            GUI.backgroundColor = script._colorInspector;
            script._isSuccess = EditorGUILayout.Toggle("Unlock Success", script._isSuccess);
            GUI.backgroundColor = Color.white;


            if (script._isSuccess)
            {
                _enumSuccess = (EnumSuccess._enumSuccess)EditorGUILayout.EnumPopup("Success to Unlock", _enumSuccess);
                script._enumSuccessString = _enumSuccess.ToString();
            }


            GUI.backgroundColor = script._colorInspector;
            script._isUnlockingObject = EditorGUILayout.Toggle("Unlock Object", script._isUnlockingObject);
            GUI.backgroundColor = Color.white;

            if (script._isUnlockingObject)
            {
                _swipeDirection = (EnumDirectionSwipeCard._swipeDirection)EditorGUILayout.EnumPopup("Direction to unlock Object", _swipeDirection);
                script._enumDirectpionSwipeString = _enumSuccess.ToString();
                script._findObjectInListToggle = EditorGUILayout.IntField("Number In List", script._findObjectInListToggle);
            }

            GUI.backgroundColor = script._colorInspector;
            script._canSlideUp = EditorGUILayout.Toggle("Unlock Card Slide Up", script._canSlideUp);
            GUI.backgroundColor = Color.white;

            if (script._canSlideUp)
            {
                script._isNextCardUp = EditorGUILayout.ObjectField("Next Card By Sliding UP", script._isNextCardUp, typeof(CardScriptableObject), true) as CardScriptableObject;
                script._numberLine = EditorGUILayout.IntField("Conditions numbers", script._numberLine);

                if(script._numberLine != _conditionsObjectList.Count)
                {
                    if(script._numberLine < _conditionsObjectList.Count)
                    {
                        _conditionsObjectList.RemoveAt(_conditionsObjectList.Count - 1);
                    }
                    else if(script._numberLine > _conditionsObjectList.Count)
                    {
                        for (int i = 0; i < script._numberLine- _conditionsObjectList.Count; i++)
                        {
                            _conditionsObjectList.Add(0);
                        }
                    }
                }
                for (int i = 0; i < _conditionsObjectList.Count; i++)
                {
                    _conditionsObjectList[i] = EditorGUILayout.IntField("Element " + i, _conditionsObjectList[i]);
                }
                script._conditionObjetListForCardManager = _conditionsObjectList;
            }

        }
    }

    
}
#endif
