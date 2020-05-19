using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class OngletArboManager : MonoBehaviour
{
    [HideInInspector] public int _actualdId;
    [HideInInspector] public Camera _cam;

    [HideInInspector] public GameObject _positionListManager;
    [HideInInspector] public List <Transform> _positionListOnglet;

    public List<string> _listEvents;

    [HideInInspector] public GameObject _goRight, _goLeft;

    [HideInInspector] public TextMeshProUGUI _text;

    float _zoomGeneral;
    Vector3 _cameraAtStart;

    [HideInInspector] public bool _canMoveToPosAtStart;

    void Start()
    {
        _canMoveToPosAtStart = true;
        _zoomGeneral = _cam.orthographicSize;
        _cameraAtStart = _cam.transform.position;
        foreach (Transform positionListChild in _positionListManager.transform)
        {
            _positionListOnglet.Add(positionListChild);
        }
        _actualdId = 1;
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

        if (_actualdId > 0)
        {
            _cam.transform.position = _positionListOnglet[_actualdId - 1].transform.position;
            _cam.transform.position = new Vector3(_cam.transform.position.x, _cam.transform.position.y, -10);
            float zoomInList = _positionListOnglet[_actualdId - 1].GetComponent<PositionChildArbo>()._zoomChild[_positionListOnglet[_actualdId - 1].GetComponent<PositionChildArbo>()._actualPos];
            ActualiseCamera(zoomInList);
        }
        else
        {
            _cam.orthographicSize = _zoomGeneral;
            _cam.transform.position = _cameraAtStart;
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
        int _addition;
        if (_actualdId == 1)
        {
            _addition = 1;
        }
        else if(_actualdId == 2)
        {
            _addition = 4;
        }
        else if (_actualdId == 3)
        {
            _addition = 8;
        }
        else
        {
            _addition = 11;
        }
        _text.text = _listEvents[_addition-1 + _positionListOnglet[_actualdId - 1].GetComponent<PositionChildArbo>()._actualPos];
    }

    public void FindOngletToActive(int i)
    {
        int _soustraction;

        if (i > 11)
        {
            _soustraction = 4;
        }
        else if(i > 8)
        {
            _soustraction = 3;
        }
        else if (i>4)
        {
            _soustraction = 2;
        }
        else
        {
            _soustraction = 1;
        }

        Debug.Log("------------------------------------------------------------------------------------------------- " + _soustraction);

        foreach (Transform child in transform)
        {
            if (_soustraction == child.GetComponent<OngletArbo>()._id)
            {
                child.GetComponent<Button>().onClick.Invoke();
            }
        }

        #region RegardeQuelEstActualPos
        if(i == 13 || i == 10 || i== 7 || i == 3)
            _positionListOnglet[_actualdId - 1].GetComponent<PositionChildArbo>()._actualPos = 2;
        else  if (i == 12 || i == 9 || i == 6 || i == 2)
            _positionListOnglet[_actualdId - 1].GetComponent<PositionChildArbo>()._actualPos = 1;
        else if (i == 11 || i == 8 || i == 5 || i == 1)
            _positionListOnglet[_actualdId - 1].GetComponent<PositionChildArbo>()._actualPos = 0;
        else
            _positionListOnglet[_actualdId - 1].GetComponent<PositionChildArbo>()._actualPos = 3;

        #endregion


    }
}
