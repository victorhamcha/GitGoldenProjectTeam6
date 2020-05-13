using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowMouse : MonoBehaviour
{
    Camera _cam;
    Vector2 StartPosition;
    Vector2 DragStartPosition;
    Vector2 DragNewPosition;
    Vector2 Finger0Position;
    float DistanceBetweenFingers;

    void Start()
    {
        _cam = GetComponent<Camera>();
    }

    void Update()
    {

        if (Input.touchCount == 1)
        {
                if (Input.GetTouch(0).phase == TouchPhase.Moved)
                {
                    Vector2 NewPosition = GetWorldPosition();
                    Vector2 PositionDifference = NewPosition - StartPosition;
                    _cam.transform.Translate(-PositionDifference);
                }
                StartPosition = GetWorldPosition();
        }
    }

    Vector2 GetWorldPosition()
    {
        return _cam.GetComponent<Camera>().ScreenToWorldPoint(Input.mousePosition);
    }

}
