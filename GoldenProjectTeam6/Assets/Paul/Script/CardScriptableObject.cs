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



    [HideInInspector] public CardScriptableObject _isNextCardRight;
    [HideInInspector] public CardScriptableObject _isNextCardLeft;
    [Space(10)]
    [HideInInspector] public bool _isSuccess;
    [Space(10)]
    [HideInInspector] public bool _isUnlockingObject;
    [HideInInspector] public EnumSuccess _successEnum;
    [HideInInspector] public int _findObjectInListToggle;
    
}

#if UNITY_EDITOR
[CustomEditor(typeof(CardScriptableObject))]
public class CardScriptableObject_Editor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector(); // for other non-HideInInspector fields

        CardScriptableObject script = (CardScriptableObject)target;

        // draw checkbox for the bool
        script._isDeadCard = EditorGUILayout.Toggle("Is Dead Card", script._isDeadCard);
        if (!script._isDeadCard) // if bool is true, show other fields
        {
            script._isNextCardRight = EditorGUILayout.ObjectField("Next Card By Sliding RIGHT", script._isNextCardRight, typeof(CardScriptableObject), true) as CardScriptableObject;
            script._isNextCardLeft = EditorGUILayout.ObjectField("Next Card By Sliding LEFT", script._isNextCardLeft, typeof(CardScriptableObject), true) as CardScriptableObject;

            script._isSuccess = EditorGUILayout.Toggle("Unlock Success", script._isSuccess);

            if (script._isSuccess)
            {

            }

            script._isUnlockingObject = EditorGUILayout.Toggle("Unlock Object", script._isUnlockingObject);
            if (script._isUnlockingObject)
            {
                script._findObjectInListToggle = EditorGUILayout.IntField("Which number In List", script._findObjectInListToggle);
            }

        }
    }
}
#endif
