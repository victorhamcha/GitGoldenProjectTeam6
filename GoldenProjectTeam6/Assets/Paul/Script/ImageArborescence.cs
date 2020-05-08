using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ImageArborescence : MonoBehaviour
{
    [HideInInspector] public Image _image;
    [HideInInspector] public TextMeshProUGUI _title;
    [HideInInspector] public List<GameObject> _lineRendererGO;
    [HideInInspector] public GameObject _lineRendererShowNext;
    [HideInInspector] public GameObject _emptyParent;

    //EFFECT
    Material _material;
    public float _timeToRevealCard = 1f;
    public bool _disolve = false;
    public bool _alreadyInTree;

    Transform _positionLeft, _positionRight, _positionUp;

    public CardScriptableObject _cardID;
    
    


    void Start()
    {
        _material = GetComponent<Image>().material;
        _material.SetFloat("_Disolve", 0);
        _image.enabled = false;
        CheckIfAlreadyDraw();
    }

    private void Update()
    {
        IsSpawning();
    }


    void IsSpawning()
    {
        if (_disolve)
        {
            
            //_image.gameObject.SetActive(true);
            _timeToRevealCard -= Time.deltaTime * 2;
            Debug.Log(_timeToRevealCard);

            if (_timeToRevealCard <= 0f)
            {
                _timeToRevealCard = 1f;
                //_image.gameObject.SetActive(false);

                _disolve = false;
            }
            _material.SetFloat("_Disolve", _timeToRevealCard);

        }
    }


    void DrawLineAuto()
    {
        if(_cardID._isNextCardLeft != null)
        {
            _lineRendererGO.Add(Instantiate(_lineRendererShowNext, this.transform.position, this.transform.rotation));

            foreach (Transform child in _emptyParent.transform)
            {
                if (child.GetComponent<ImageArborescence>()._cardID == _cardID._isNextCardLeft)
                {
                    _positionLeft = child.transform;
                }
            }
        }
        if (_cardID._isNextCardRight != null)
        {
            _lineRendererGO.Add(Instantiate(_lineRendererShowNext, this.transform.position, this.transform.rotation));

            foreach (Transform child in _emptyParent.transform)
            {
                if (child.GetComponent<ImageArborescence>()._cardID == _cardID._isNextCardRight)
                {
                    _positionRight = child.transform;
                }
            }
        }
        if (_cardID._isNextCardUp != null)
        {
            _lineRendererGO.Add(Instantiate(_lineRendererShowNext, this.transform.position, this.transform.rotation));

            foreach (Transform child in _emptyParent.transform)
            {
                if (child.GetComponent<ImageArborescence>()._cardID == _cardID._isNextCardUp)
                {
                    _positionUp = child.transform;
                }
            }
        }


        for (int i = 0; i < _lineRendererGO.Count; i++)
        {
            _lineRendererGO[i].gameObject.transform.parent = this.gameObject.transform;
            _lineRendererGO[i].GetComponent<LineRenderer>().useWorldSpace = true;
            _lineRendererGO[i].GetComponent<LineRenderer>().SetPosition(0, this.transform.position);
            if(i == 0)
                _lineRendererGO[i].GetComponent<LineRenderer>().SetPosition(1, _positionLeft.position);
            else if (i == 1)
                _lineRendererGO[i].GetComponent<LineRenderer>().SetPosition(1, _positionRight.position);
            else
                _lineRendererGO[i].GetComponent<LineRenderer>().SetPosition(1, _positionUp.position);

        }
    }

    void Assigner()
    {
        _title.text = _cardID._title;
        _image.enabled = true;
        _image.sprite = _cardID._image;
    }

    void CheckIfAlreadyDraw()
    {
        //CHANGE NECT LINE TO !_cardID._cardAlreadyDraw
        
        if (!_cardID._cardAlreadyDraw) // Card never draw
        {
            _image.enabled = false;
            _title.enabled = false;
        }
        else // Card already draw
        {
            if (_alreadyInTree) //Card already shows in tree so don't play anim
            {
                _image.enabled = true;
                _title.enabled = true;
                Assigner();
                DrawLineAuto();
                _title.gameObject.SetActive(true);
            }
            else //Card never shows in tree so play animation
            {
                //_image.enabled = false;
                _title.enabled = false;
                StartCoroutine(ShowUp());
            }
        }
    }

    IEnumerator ShowUp()
    {
        yield return new WaitForSeconds(1);
        _disolve = true;
        _alreadyInTree = true;
        CheckIfAlreadyDraw();
    }
}
