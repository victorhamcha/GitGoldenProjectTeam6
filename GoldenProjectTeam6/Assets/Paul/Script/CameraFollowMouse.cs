using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowMouse : MonoBehaviour
{
    Camera _cam;

    [HideInInspector] public GameObject _positivLim, _negativLim;

    Vector2 StartPosition;
    Vector2 DragStartPosition;
    Vector2 DragNewPosition;
    Vector2 Finger0Position;
    float DistanceBetweenFingers;
    bool isZooming;

    [Header("Card Small")][Range(0, 10000)] public float _minZoom = 100;
    [Header("Card Grow")] [Range(0, 10000)] public float _maxZoom = 100;
    float _sizeCamAtStart;

    [Range(1,100)] public int _boucinessByTouchingBorder = 10;


    Vector2 _positivValue;
    Vector2 _negativValue;

    [HideInInspector] public LineRenderer _line;


    [HideInInspector] public List<GameObject> _positionLim;
    [HideInInspector] public GameObject _positionLimMaster;

    void Start()
    {
        foreach (Transform child in _positionLimMaster.transform)
        {
            _positionLim.Add(child.gameObject);
        }
        _cam = GetComponent<Camera>();
        CalculateNewCamera();
        DrawLine();
    }

    public void CalculateNewCamera()
    {
        _sizeCamAtStart = _cam.orthographicSize;
        StartPosition = transform.position;
        //_positivValue = _positivLim.transform.position;
        //foreach (Transform child in _positivLim.transform)
        //{
        //    child.GetComponent<SpriteRenderer>().enabled = false;
        //}
        //_negativValue = _negativLim.transform.position;

        //foreach (Transform child in _negativLim.transform)
        //{
        //    child.GetComponent<SpriteRenderer>().enabled = false;

        //}




        //foreach (Transform child in _positionLim[numberArray].transform)
        //{
        //    if (child.name == "PostitivValueZoom")
        //    {
        //        _positivValue = child.transform.position;
        //    }
        //    else
        //    {
        //        _negativValue = child.transform.position;
        //    }
        //}
        //foreach (Transform child in _positionLim[numberArray].transform)
        //{
        //    foreach (Transform childOfChild in child)
        //    {
        //        childOfChild.GetComponent<SpriteRenderer>().enabled = false;
        //    }
        //}
    }

    void DrawLine()
    {
        _line.SetWidth(5, 5);
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
        if (Input.touchCount == 1)
        {
            if (!isZooming)
            {
                if (Input.GetTouch(0).phase == TouchPhase.Moved)
                {
                    Vector2 NewPosition = GetWorldPosition();
                    Vector2 PositionDifference = NewPosition - StartPosition;
                    _cam.transform.Translate(-PositionDifference);
                }
                StartPosition = GetWorldPosition();

                //#region NE PAS REGARDER (VRAIMENT)
                //if (transform.position.x > _negativValue.x)
                //{
                //    if (transform.position.x < _positivValue.x)
                //    {
                //        if (transform.position.y > _negativValue.y)
                //        {
                //            if (transform.position.y < _positivValue.y)
                //            {
                //            }
                //            else
                //            {
                //                transform.position = new Vector3(transform.position.x, transform.position.y - _boucinessByTouchingBorder, -10);
                //            }
                //        }
                //        else
                //        {
                //            transform.position = new Vector3(transform.position.x, transform.position.y + _boucinessByTouchingBorder, -10);
                //        }
                //    }
                //    else
                //    {
                //        transform.position = new Vector3(transform.position.x - _boucinessByTouchingBorder, transform.position.y, -10);
                //    }
                //}
                //else
                //{
                //    transform.position = new Vector3(transform.position.x + _boucinessByTouchingBorder, transform.position.y, -10);
                //}
                //#endregion
            }
        }
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
