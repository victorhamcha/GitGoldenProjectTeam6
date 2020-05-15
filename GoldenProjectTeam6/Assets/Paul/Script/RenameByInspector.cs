using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

[ExecuteInEditMode]
public class RenameByInspector : MonoBehaviour
{
    CardScriptableObject _cardID;
    TextMeshProUGUI _tmpText;
    string objectName;
    public bool _actualisate;
    void Start()
    {
        objectName = gameObject.name;
    }

    void OnValidate()
    {
        if (GetComponent<ImageArborescence>())
        {
            _cardID = GetComponent<ImageArborescence>()._cardID;
            objectName = _cardID.name;
        }
        else if (GetComponent<TextMeshProUGUI>())
        {
            objectName = "Groupe : " + GetComponent<TextMeshProUGUI>().text;
        }
        gameObject.name = objectName;
    }
}
