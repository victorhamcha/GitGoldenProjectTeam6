using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class CameraFollowMouse : MonoBehaviour
{
    Camera _cam;


    [HideInInspector] public GameObject _positionPositiv, _positionNegativ;

    Vector2 StartPosition;
    Vector2 DragStartPosition;
    Vector2 DragNewPosition;
    Vector2 Finger0Position;
    float DistanceBetweenFingers;
    bool isZooming;

    [Header("Card Small")][Range(0, 1000)] public float _minZoom = 100;
    [Header("Card Grow")] [Range(0, 1000)] public float _maxZoom = 100;
    float _sizeCamAtStart;

    [Range(1,100)] public int _boucinessByTouchingBorder = 10;


    Vector2 _positivValue;
    Vector2 _negativValue;

    [HideInInspector] public LineRenderer _line;

    void Start()
    {
        _cam = GetComponent<Camera>();
        _sizeCamAtStart = _cam.orthographicSize;
        _positivValue = _positionPositiv.transform.position;
        foreach (Transform child in _positionPositiv.transform)
        {
            child.GetComponent<SpriteRenderer>().enabled = false;
        }
        _negativValue = _positionNegativ.transform.position;
        foreach (Transform child in _positionNegativ.transform)
        {
            child.GetComponent<SpriteRenderer>().enabled = false;
        }
        DrawLine();
    }

    void DrawLine()
    {
        _line.SetWidth(3, 3);
        _line.SetPosition(0, new Vector2(_positivValue.x, _positivValue.y));
        _line.SetPosition(1, new Vector2(_positivValue.x, _negativValue.y));
        _line.SetPosition(2, new Vector2(_negativValue.x, _negativValue.y));
        _line.SetPosition(3, new Vector2(_negativValue.x, _positivValue.y));
        _line.SetPosition(4, new Vector2(_positivValue.x, _positivValue.y));

    }

    void Update()
    {
        if (Input.touchCount == 0 && isZooming)
        {
            isZooming = false;
        }
        #region Drag
        //if (Input.touchCount == 1)
        //{
        //    if (!isZooming)
        //    {
        //        #region NE PAS REGARDER (VRAIMENT)
        //        if (transform.position.x > _negativValue.x)
        //        {
        //            if (transform.position.x < _positivValue.x)
        //            {
        //                if(transform.position.y > _negativValue.y)
        //                {
        //                    if(transform.position.y < _positivValue.y)
        //                    {
        //                        if (Input.GetTouch(0).phase == TouchPhase.Moved)
        //                        {
        //                            Vector2 NewPosition = GetWorldPosition();
        //                            Vector2 PositionDifference = NewPosition - StartPosition;
        //                            _cam.transform.Translate(-PositionDifference);
        //                        }
        //                        StartPosition = GetWorldPosition();
        //                    }
        //                    else
        //                    {
        //                        transform.position = new Vector3(transform.position.x, transform.position.y - _boucinessByTouchingBorder, -10);
        //                    }
        //                }
        //                else
        //                {
        //                    transform.position = new Vector3(transform.position.x, transform.position.y + _boucinessByTouchingBorder,-10);
        //                }
        //            }
        //            else
        //            {
        //                transform.position = new Vector3(transform.position.x - _boucinessByTouchingBorder, transform.position.y,-10);
        //            }
        //        }
        //        else
        //        {
        //            transform.position = new Vector3(transform.position.x + _boucinessByTouchingBorder, transform.position.y, -10);
        //        }
        //        #endregion
        //    }
        //}
        #endregion
        #region Zoom
        else if (Input.touchCount == 2)
        {
            if (Input.GetTouch(1).phase == TouchPhase.Moved)
            {
                isZooming = true;

                DragNewPosition = GetWorldPositionOfFinger(1);
                Vector2 PositionDifference = DragNewPosition - DragStartPosition;

                if (_cam.orthographicSize <_sizeCamAtStart + _minZoom)
                {
                    if (Vector2.Distance(DragNewPosition, Finger0Position) < DistanceBetweenFingers)
                        _cam.GetComponent<Camera>().orthographicSize += (PositionDifference.magnitude);
                }
                if (_cam.orthographicSize > _sizeCamAtStart - _maxZoom)
                {
                    if (Vector2.Distance(DragNewPosition, Finger0Position) >= DistanceBetweenFingers)
                        _cam.GetComponent<Camera>().orthographicSize -= (PositionDifference.magnitude);
                }


                DistanceBetweenFingers = Vector2.Distance(DragNewPosition, Finger0Position);
            }
            DragStartPosition = GetWorldPositionOfFinger(1);
            Finger0Position = GetWorldPositionOfFinger(0);
        }
        #endregion
    }

    Vector2 GetWorldPosition()
    {
        return _cam.GetComponent<Camera>().ScreenToWorldPoint(Input.mousePosition);
    }

    Vector2 GetWorldPositionOfFinger(int FingerIndex)
    {
        return _cam.GetComponent<Camera>().ScreenToWorldPoint(Input.GetTouch(FingerIndex).position);
    }

}
