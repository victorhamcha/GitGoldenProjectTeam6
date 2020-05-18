using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OngletArboManager : MonoBehaviour
{
    public int _actualdId;
    [HideInInspector] public Camera _cam;

    [HideInInspector] public GameObject _positionListManager;
    public List <Transform> _positionListOnglet;

    public GameObject _goRight, _goLeft;

    void Start()
    {
        foreach (Transform positionListChild in _positionListManager.transform)
        {
            _positionListOnglet.Add(positionListChild);
        }
        _actualdId = 0;
        Actualise(_actualdId);
    }
    public void Actualise(int childID)
    {
        _actualdId = childID;
        foreach (Transform child in transform)
        {
            if(_actualdId == child.GetComponent<OngletArbo>()._id)
            {
                child.GetComponent<Image>().enabled = false;
            }
            else
            {
                child.GetComponent<Image>().enabled = true;

            }
        }

        if(_actualdId > 0)
        {
            _cam.transform.position = _positionListOnglet[_actualdId-1].transform.position;
            _cam.transform.position = new Vector3(_cam.transform.position.x, _cam.transform.position.y, - 10);
            float zoomInList = _positionListOnglet[_actualdId - 1].GetComponent<PositionChildArbo>()._zoomChild[_positionListOnglet[_actualdId - 1].GetComponent<PositionChildArbo>()._actualPos];
            ActualiseCamera(zoomInList);
        }
        else
        {
            _cam.transform.position = new Vector3(0, 0, -10);
        }
        #region Active Or Desactive LeftRight Button
        if (_actualdId == 0)
        {
            _goRight.SetActive(false);
            _goLeft.SetActive(false);
        }
        else
        {
            _goRight.SetActive(true);
            _goLeft.SetActive(true);
        }
        #endregion
    }

    public void GoRight()
    {
        if (_positionListOnglet[_actualdId-1].GetComponent<PositionChildArbo>()._actualPos < _positionListOnglet[_actualdId-1].GetComponent<PositionChildArbo>()._positionChild.Count-1)
        {
            _positionListOnglet[_actualdId-1].GetComponent<PositionChildArbo>()._actualPos++;
        }
        else
        {
            _positionListOnglet[_actualdId - 1].GetComponent<PositionChildArbo>()._actualPos = 0;
        }

        float zoomInList = _positionListOnglet[_actualdId - 1].GetComponent<PositionChildArbo>()._zoomChild[_positionListOnglet[_actualdId - 1].GetComponent<PositionChildArbo>()._actualPos];
        ActualiseCamera(zoomInList);
    }
    public void GoLeft()
    {
        if(_positionListOnglet[_actualdId - 1].GetComponent<PositionChildArbo>()._actualPos > 0)
        {
            _positionListOnglet[_actualdId - 1].GetComponent<PositionChildArbo>()._actualPos--;

        }
        else
        {
            _positionListOnglet[_actualdId - 1].GetComponent<PositionChildArbo>()._actualPos = _positionListOnglet[_actualdId - 1].GetComponent<PositionChildArbo>()._positionChild.Count-1;
    
        }
        float zoomInList = _positionListOnglet[_actualdId - 1].GetComponent<PositionChildArbo>()._zoomChild[_positionListOnglet[_actualdId - 1].GetComponent<PositionChildArbo>()._actualPos];
        ActualiseCamera(zoomInList);
    }

    void ActualiseCamera(float zoom)
    {
        _cam.transform.position = new Vector3(_positionListOnglet[_actualdId - 1].GetComponent<PositionChildArbo>()._positionChild[_positionListOnglet[_actualdId - 1].GetComponent<PositionChildArbo>()._actualPos].transform.position.x, _positionListOnglet[_actualdId - 1].transform.position.y, -10);
        _cam.orthographicSize = zoom;
    }
}
