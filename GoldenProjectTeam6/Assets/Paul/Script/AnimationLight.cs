using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationLight : MonoBehaviour
{
    public UnityEngine.Experimental.Rendering.Universal.Light2D _light;

    float _maxIntensity;
    [Range(0,3)] public float _minIntensity;
    bool _goDown = true;
    float _speed;
    [Range(0, 1)] public float _speedMin, _speedMax;

    void Start()
    {
        _maxIntensity = _light.intensity;
        _speed = Random.Range(_speedMin, _speedMax);
    }

    void Update()
    {
        //if (_goDown)
        //{
        //    if (_light.intensity > _minIntensity)
        //    {
        //        _light.intensity -= _speed;
        //    }
        //    else
        //    {
        //        _goDown = false;
        //    }
        //}
        //else
        //{
        //    if (_light.intensity < _maxIntensity)
        //    {
        //        _light.intensity += _speed;
        //    }
        //    else
        //    {
        //        _goDown = true;
        //    }
        //}
    }
}
