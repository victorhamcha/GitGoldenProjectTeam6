using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class LineRendererAnimation : MonoBehaviour
{
    LineRenderer _lineRenderer;
    float _counter;
    float _dist;

    [HideInInspector] public Transform _origin;
    [HideInInspector] public Transform _destination;

    public float _lineSpeed = 6f;
    public float _timerBeforeRestart = 6f;

    bool _startAnimate;
    void Start()
    {
        _lineRenderer = GetComponent<LineRenderer>();
    }

    void Update()
    {
        if (_startAnimate)
        {
            if (_counter<_dist)
            {
                _counter += .1f / _lineSpeed;

                float x = Mathf.Lerp(0, _dist, _counter);
                Vector3 pointA = _origin.position;
                Vector3 pointB = _destination.position;

                Vector3 pointAlongLine = x * Vector3.Normalize(pointB - pointA) + pointA;
                _lineRenderer.SetPosition(1, pointAlongLine);
            }
            else
            {
                _startAnimate = false;
                _counter = 0;
                StartCoroutine(WaitBeforeReplayAnim());
            }
        }
    }

    public void DistanceIsAttribuate(Transform origin, Transform destination)
    {
        _destination = destination;
        _origin = origin;
        _dist = Vector3.Distance(_origin.position, _destination.position);
        _startAnimate = true;
    }


    IEnumerator WaitBeforeReplayAnim()
    {
        yield return new WaitForSeconds(_timerBeforeRestart);
        _lineRenderer.SetPosition(0, _origin.position);
        _lineRenderer.SetPosition(1, _origin.position);
        DistanceIsAttribuate(_origin, _destination);
    }
}
