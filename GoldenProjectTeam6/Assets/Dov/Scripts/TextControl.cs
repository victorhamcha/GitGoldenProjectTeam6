using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextControl : MonoBehaviour
{
    private TextMeshProUGUI _textMeshPro;
    public List<char> list;

    private void Start()
    {
        _textMeshPro = GetComponent<TextMeshProUGUI>();
    }

    public void ChangeFont()
    {
        char test = _textMeshPro.text[0];


        for (int i = 0; i < _textMeshPro.text.Length; i++)
        {
            list.Add(_textMeshPro.text[i]);
        }

        list.RemoveAt(0);
        _textMeshPro.text = "<b>" + test + "</b>" ;

        for (int i = 0; i < list.Count; i++)
        {
            _textMeshPro.text += list[i];
        }

    }


}
