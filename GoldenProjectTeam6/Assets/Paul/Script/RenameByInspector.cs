using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[ExecuteInEditMode]
public class RenameByInspector : MonoBehaviour
{
    CardScriptableObject _cardID;
    string objectName;
    public bool _actualisate;
    void Start()
    {
        objectName = gameObject.name;
    }

    void OnValidate()
    {
        _cardID = GetComponent<ImageArborescence>()._cardID;
        objectName = _cardID.name;
        gameObject.name = objectName;
    }
}
