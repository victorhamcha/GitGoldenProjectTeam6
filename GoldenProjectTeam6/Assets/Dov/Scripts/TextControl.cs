using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Text.RegularExpressions;

public class TextControl : MonoBehaviour
{
    private TextMeshProUGUI _textMeshPro;
    public List<char> list;

    private void Start()
    {
        _textMeshPro = GetComponent<TextMeshProUGUI>();
    }

    public void ChangeFont(CardScriptableObject card)
    {

        for (int i = 0; i < card._description.Length; i++)
        {
            char test = card._description[i];

            Debug.Log(char.IsLetter(test));
            if (char.IsLetter(test))
            {
                Checkpoint(card, test, i);
                break;
            }
            else
            {
                continue;
            }
            
        }
    }

    void Checkpoint(CardScriptableObject card, char test, int number)
    {
        for (int i = 0; i < card._description.Length; i++)
        {
            list.Add(card._description[i]);
        }

        list[number] = test;
        _textMeshPro.text = "";


        for (int i = 0; i < list.Count; i++)
        {
            if (i != number)
            {
                _textMeshPro.text += list[i];
            }
            else
            {
                _textMeshPro.text += "<font=\"gothic_ultra_ot_SDF\">" + "<size=200%>" + "<b>" + test + "</b>" + "</size>" + "</font>";
            }
        }
        list.Clear();
    }

}
