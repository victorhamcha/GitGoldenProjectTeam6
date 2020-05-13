using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextAdaptive : MonoBehaviour
{
    private TextMeshProUGUI text;

    private void Start()
    {
        text = GetComponent<TextMeshProUGUI>();
    }

    private void Update()
    {
        
        if (GetComponent<RectTransform>().rect.height < 700)
        {
            GetComponent<RectTransform>().pivot = new Vector2(0.5f, 0.5f);
        }
        else
        {
            GetComponent<RectTransform>().pivot = new Vector2(0.5f, 1f);
        }
    }
}
