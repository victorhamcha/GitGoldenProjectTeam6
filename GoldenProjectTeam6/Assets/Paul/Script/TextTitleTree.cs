using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextTitleTree : MonoBehaviour
{
    TextMeshProUGUI _text;
    void Start()
    {
        _text = GetComponent <TextMeshProUGUI>();
    }

    void Update()
    {
        if(_text.text.ToLower() == "title")
        {
            _text.text = "Choose a section";
        }
    }
}
