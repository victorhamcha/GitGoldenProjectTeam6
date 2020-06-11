using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AllCardUnlockNumber : MonoBehaviour
{
    TextMeshProUGUI _text;

    public ContainAllObjectTree _parent;
    public int _numberCardMax;
    public int _numberCardActual;
    void Start()
    {
        _text = GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {
        _numberCardMax = _parent._imageTreeChilds.Count;
        _numberCardActual = _parent._imageTreeUnlockSinceLastTime.Count;
        _text.text = _numberCardActual + " / " + _numberCardMax;
    }
}
