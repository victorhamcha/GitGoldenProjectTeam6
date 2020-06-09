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
    public List <Transform> _positionListOnglet;

    public List<string> _listEvents;
    public List<ImageArborescence> _listEventsFirstCardEvent;

    [HideInInspector] public GameObject _goRight, _goLeft;

    [HideInInspector] public TextMeshProUGUI _text;

    float _zoomGeneral;
    Vector3 _cameraAtStart;

    [HideInInspector] public bool _canMoveToPosAtStart;

    public Color _buttonColor;

    bool _activeOnlyOne = true;

    int _addition;

    int _soustraction;
    int _actualPos;

    public GameObject _cardZoom;

    public GameObject _listManager;

    void Start()
    {
        _canMoveToPosAtStart = true;
        _zoomGeneral = _cam.orthographicSize;
        _cameraAtStart = _cam.transform.position;
        foreach (Transform positionListChild in _positionListManager.transform)
        {
            _positionListOnglet.Add(positionListChild);
        }

        ContainAllObjectTree _parent = FindObjectOfType<ContainAllObjectTree>();

        if (_parent._imageTreeUnlockSinceLastTime.Count > 0)
        {            
            foreach (Transform child in _listManager.transform)
            {
                if (_parent._imageTreeUnlockSinceLastTime[_parent._imageTreeUnlockSinceLastTime.Count - 1].Contains(child.GetComponent<ListEventStockTree>()._imageNameRef))
                {
                    _addition = child.GetComponent<ListEventStockTree>()._id;

                    if (_addition >= 10)
                    {
                        _actualdId = 4;
                        if (_addition == 12)
                            _positionListOnglet[_actualdId - 1].GetComponent<PositionChildArbo>()._actualPos = 2;
                        else if (_addition == 11)
                            _positionListOnglet[_actualdId - 1].GetComponent<PositionChildArbo>()._actualPos = 1;
                        else
                            _positionListOnglet[_actualdId - 1].GetComponent<PositionChildArbo>()._actualPos = 0;

                    }
                    else if (_addition >= 7)
                    {
                        _actualdId = 3;
                        if (_addition == 9)
                            _positionListOnglet[_actualdId - 1].GetComponent<PositionChildArbo>()._actualPos = 2;
                        else if (_addition == 8)
                            _positionListOnglet[_actualdId - 1].GetComponent<PositionChildArbo>()._actualPos = 1;
                        else
                            _positionListOnglet[_actualdId - 1].GetComponent<PositionChildArbo>()._actualPos = 0;
                    }
                    else if (_addition >= 3)
                    {
                        _actualdId = 2;
                        if (_addition == 6)
                            _positionListOnglet[_actualdId - 1].GetComponent<PositionChildArbo>()._actualPos = 3;
                        else if (_addition == 5)
                            _positionListOnglet[_actualdId - 1].GetComponent<PositionChildArbo>()._actualPos = 2;
                        else if (_addition == 4)
                            _positionListOnglet[_actualdId - 1].GetComponent<PositionChildArbo>()._actualPos = 1;
                        else
                            _positionListOnglet[_actualdId - 1].GetComponent<PositionChildArbo>()._actualPos = 0;
                    }
                    else
                    {
                        _actualdId = 1;
                        if (_addition == 2)
                            _positionListOnglet[_actualdId - 1].GetComponent<PositionChildArbo>()._actualPos = 2;
                        else if (_addition == 1)
                            _positionListOnglet[_actualdId - 1].GetComponent<PositionChildArbo>()._actualPos = 1;
                        else
                            _positionListOnglet[_actualdId - 1].GetComponent<PositionChildArbo>()._actualPos = 0;
                    }
                }
            }
        }
        else
        {
            _actualdId = 1;
        }
        
        Actualise(_actualdId);

        StartCoroutine(DeleteList());
    }


    public void Actualise(int childID)
    {
        _actualdId = childID;
        foreach (Transform child in transform)
        {
            if (_actualdId == child.GetComponent<OngletArbo>()._id)
            {
                var colors = child.GetComponent<Button>().colors;
                colors.normalColor = _buttonColor;
                child.GetComponent<Button>().colors = colors;
                child.GetComponent<Button>().enabled = false;
                child.GetComponent<Button>().enabled = true;
                child.GetComponent<OngletArbo>().ChangeBackground();
            }
            else
            {
                var colors = child.GetComponent<Button>().colors;
                colors.normalColor = new Vector4(255, 255, 255, 1);
                child.GetComponent<Button>().colors = colors;
                child.GetComponent<Button>().enabled = false;
                child.GetComponent<Button>().enabled = true;
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
        _actualPos = _positionListOnglet[_actualdId - 1].GetComponent<PositionChildArbo>()._actualPos;
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
        _actualPos = _positionListOnglet[_actualdId - 1].GetComponent<PositionChildArbo>()._actualPos;

        float zoomInList = _positionListOnglet[_actualdId - 1].GetComponent<PositionChildArbo>()._zoomChild[_positionListOnglet[_actualdId - 1].GetComponent<PositionChildArbo>()._actualPos];
        ActualiseCamera(zoomInList);
    }

    void ActualiseCamera(float zoom)
    {
        if(_actualdId != 2)
        {
            _cam.transform.position = new Vector3(_positionListOnglet[_actualdId - 1].GetComponent<PositionChildArbo>()._positionChild[_positionListOnglet[_actualdId - 1].GetComponent<PositionChildArbo>()._actualPos].transform.position.x, _positionListOnglet[_actualdId - 1].transform.position.y, -10);
            _cam.orthographicSize = zoom;
        }
        else
        {
            _cam.transform.position = new Vector3(_positionListOnglet[1].GetComponent<PositionChildArbo>()._positionChild[_positionListOnglet[1].GetComponent<PositionChildArbo>()._actualPos].transform.position.x, _positionListOnglet[1].transform.position.y, -10);

            _cam.orthographicSize = zoom;

        }

        if (_activeOnlyOne)
        {
            _activeOnlyOne = false;
            _addition++;

            Debug.Log(_addition);
            _text.text = _listEvents[_addition-1];


        }
        else
        {
            if (_actualdId == 1)
            {
                _addition = 0;
            }
            else if (_actualdId == 2)
            {
                _addition = 3;
            }
            else if (_actualdId == 3)
            {
                _addition = 7;
            }
            else
            {
                _addition = 10;
            }
            _text.text = _listEvents[_addition + _positionListOnglet[_actualdId - 1].GetComponent<PositionChildArbo>()._actualPos];
            Debug.Log(_addition);

        }
        Debug.Log("addition : " + _addition);
        StartCoroutine(WaiToCheck());

        FindObjectOfType<CameraFollowMouse>().CalculateNewCamera();
        FindObjectOfType<ContainAllObjectTree>().LoadChild(this);
    }

    IEnumerator WaiToCheck()
    {
        yield return new WaitForSeconds(0.3f);
        for (int i = 0; i < _listEvents.Count; i++)
        {
            if (_text.text == _listEvents[i])
            {
                foreach (Transform child in _listManager.transform)
                {
                    if (child.GetComponent<ListEventStockTree>()._id == i)
                    {
                        Debug.Log("child name : " + child.name);
                        child.GetComponent<ListEventStockTree>().Check();
                    }
                }
                ImageArborescence image = _listEventsFirstCardEvent[i];
                ContainAllObjectTree parent = FindObjectOfType<ContainAllObjectTree>();
                if (parent._imageTreeUnlockSinceLastTime.Contains(image.name))
                {
                    image.IClick();
                }
                else
                {
                    _cardZoom.SetActive(false);
                }
            }
        }
    }

    public void FindOngletToActive(int i)
    {

        //if (i > 9)
        //{
        //    _soustraction = 4;
        //}
        //else if(i > 6 && i<10)
        //{
        //    _soustraction = 3;
        //}
        //else if (i>2 && i<7)
        //{
        //    _soustraction = 2;
        //}
        //else
        //{
        //    _soustraction = 1;
        //}

        #region Switch

        int _posOfTheObject;

        switch (i)
        {
            case 12: _soustraction = 4;
                _posOfTheObject = 2;
                break;
            case 11:
                _soustraction = 4;
                _posOfTheObject = 1;
                break;
            case 10:
                _soustraction = 4;
                _posOfTheObject = 0;
                break;
            case 9:
                _soustraction = 3;
                _posOfTheObject = 2;
                break;
            case 8:
                _soustraction = 3;
                _posOfTheObject = 1;
                break;
            case 7:
                _soustraction = 3;
                _posOfTheObject = 0;
                break;
            case 6:
                _soustraction = 2;
                _posOfTheObject = 3;
                break;
            case 5:
                _soustraction = 2;
                _posOfTheObject = 2;
                break;
            case 4:
                _soustraction = 2;
                _posOfTheObject = 1;
                break;
            case 3:
                _soustraction = 2;
                _posOfTheObject = 0;
                break;
            case 2:
                _soustraction = 1;
                _posOfTheObject = 2;
                break;
            case 1:
                _soustraction = 1;
                _posOfTheObject = 1;
                break;
            case 0:
                _soustraction = 1;
                _posOfTheObject = 0;
                break;
            default:
                _soustraction = 1;
                _posOfTheObject = 0;
                break;
        }


        _positionListOnglet[_soustraction-1].GetComponent<PositionChildArbo>()._actualPos = _posOfTheObject;

        #endregion

        Debug.Log("soust = " + _soustraction);
        Debug.Log("i = " + i);

        _actualdId = _soustraction;

        foreach (Transform child in transform)
        {
            if (_soustraction == child.GetComponent<OngletArbo>()._id)
            {
                child.GetComponent<Button>().onClick.Invoke();
            }
        }

        Debug.Log(" actual pos = " + _positionListOnglet[_soustraction - 1].GetComponent<PositionChildArbo>()._actualPos);
        //#region RegardeQuelEstActualPos
        //if (i == 12 || i == 9 || i == 6 || i == 2)
        //    _positionListOnglet[_soustraction].GetComponent<PositionChildArbo>()._actualPos = 2;
        //else if (i == 11 || i == 8 || i == 5 || i == 1)
        //    _positionListOnglet[_soustraction].GetComponent<PositionChildArbo>()._actualPos = 1;
        //else if (i == 10 || i == 7 || i == 4 || i == 0)
        //    _positionListOnglet[_soustraction].GetComponent<PositionChildArbo>()._actualPos = 0;
        //else
        //    _positionListOnglet[_soustraction].GetComponent<PositionChildArbo>()._actualPos = 3;

        //#endregion

        float zoomInList = _positionListOnglet[_actualdId - 1].GetComponent<PositionChildArbo>()._zoomChild[_positionListOnglet[_actualdId - 1].GetComponent<PositionChildArbo>()._actualPos];
        ActualiseCamera(zoomInList);

        //GoRight();

    }

    IEnumerator DeleteList()
    {
        yield return new WaitForSeconds(15);
        FindObjectOfType<GameManager>()._apparitionOrder.Clear();
    }
}
