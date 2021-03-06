﻿using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.UI;

public class LineRendererAnimation : MonoBehaviour
{

    public Image _imageMystere;
    Image _imageMystereIns;

    public Image _imageLock;
    Image _imageLockIns;

    LineRenderer _line;

    public Color _color;

    Vector2 _startPos;
    public Vector2 _endPos;

    void Start()
    {
        _line = GetComponent<LineRenderer>();

        _startPos = _line.GetPosition(0);
        _endPos = _line.GetPosition(1);
    }
    public void SpawnImage(Transform pos)
    {
        _line = GetComponent<LineRenderer>();
        Vector2 _positionImageMystere = (_startPos + _endPos) / 2;

        _imageMystereIns = Instantiate(_imageMystere, _positionImageMystere, transform.rotation);
        _imageMystereIns.gameObject.transform.parent = gameObject.transform;
        _imageMystereIns.transform.position = _positionImageMystere;
        _imageMystereIns.rectTransform.sizeDelta = new Vector2(25, 25);
        _imageMystereIns.rectTransform.localScale = new Vector2(1, 1);


        _imageLockIns = Instantiate(_imageLock, pos.position, transform.rotation);
        _imageLockIns.gameObject.transform.parent = gameObject.transform;
        _imageLockIns.transform.position = pos.position;
        _imageLockIns.rectTransform.sizeDelta = new Vector2(50, 50);
        _imageLockIns.rectTransform.localScale = new Vector2(1, 1);
    }

    private void Update()
    {
        if (_line.startWidth == 0 || _line.endWidth == 0)
        {
            _line.SetWidth(5, 5);
        }
        if(_line.startWidth>0 || _line.endWidth > 0)
        {
            if (_endPos.y == 1)
            {
                _line.SetWidth(0, 0);
            }
        }
    }

}
