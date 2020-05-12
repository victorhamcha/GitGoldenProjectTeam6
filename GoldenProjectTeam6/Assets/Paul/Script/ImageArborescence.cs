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
    [HideInInspector] public Material _materialImg;
    [HideInInspector] public Material _materialLine;


    [HideInInspector] public float _timeToRevealCard = 0f;
    [HideInInspector] public bool _disolve = false;

    Transform _positionLeft, _positionRight, _positionUp;

    [Header("The scriptable object of the card")]
    public CardScriptableObject _cardID;


    [HideInInspector] public int _idInParent;

    [HideInInspector] public Sprite _lineRendererTexture;

    [HideInInspector] public Image _imageZoomCard;
    [HideInInspector] public TextMeshProUGUI _titleZoomCard;
    [HideInInspector] public TextMeshProUGUI _descriptionZoomCard;
    [HideInInspector] public GameObject _cardZoom;

    [SerializeField] bool _alreadyInTree;
    [SerializeField] bool _alreadyDraw;



    void Start()
    {
        CheckIfIsInTree();
        if (_alreadyInTree)
        {
            _image.material = null;
        }
        CheckIfAlreadyDraw();
    }

    private void Update()
    {

        IsSpawning();
    }

    void CheckIfIsInTree()
    {
        for (int i = 0; i < FindObjectOfType<SaveAndLoad>().unlockSinceLastTime.Count; i++)
        {
            if (FindObjectOfType<SaveAndLoad>().unlockSinceLastTime[i] == _cardID._title)
            {
                _alreadyInTree = true;
            }
        }

        for (int i = 0; i < FindObjectOfType<SaveAndLoad>().alreadyDrawCards.Count; i++)
        {
            if (FindObjectOfType<SaveAndLoad>().alreadyDrawCards[i] == _cardID._title)
            {
                _alreadyDraw = true;
            }
        }
    }

    void IsSpawning()
    {
        if (_disolve)
        {
            _timeToRevealCard += Time.deltaTime;
        }

        if (_timeToRevealCard >= 1f)
        {
            _timeToRevealCard = 1f;

            _disolve = false;
            Assigner();
            _image.material = null;
            Assigner();
        }
        else
        {
            _image.material.SetFloat("_Dissolve", _timeToRevealCard);
            for (int i = 0; i < _lineRendererGO.Count; i++)
            {
                _lineRendererGO[i].GetComponent<LineRenderer>().material.SetFloat("_Dissolve", _timeToRevealCard);
            }

        }
    }


    void DrawLineAuto()
    {
        if (_cardID._canSlideLeft)
        {
            if (_cardID._isNextCardLeft != null)
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
        }

        if (_cardID._canSlideRight)
        {
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
        }
        if (_cardID._canSlideUp)
        {
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
        }




        for (int i = 0; i < _lineRendererGO.Count; i++)
        {
            _lineRendererGO[i].gameObject.transform.parent = this.gameObject.transform;
            _lineRendererGO[i].GetComponent<LineRenderer>().useWorldSpace = true;
            _lineRendererGO[i].GetComponent<LineRenderer>().SetPosition(0, this.transform.position);
            if (i == 0)
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
        //CHANGE NEXT LINE TO !_alreadyDraw

        if (!_alreadyDraw) // Card never draw
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
        _image.material = _materialImg;
        _image.material.SetFloat("_Dissolve", 0);
        _image.enabled = false;
        yield return new WaitForSeconds(0.3f);
        _image.material.SetFloat("_Dissolve", 0);
        _image.sprite = _cardID._image;
        //_image.material.SetTexture("_MainTexture", _image.sprite.texture);
        _disolve = true;
        _alreadyInTree = true;
        if (!_emptyParent.GetComponent<ContainAllObjectTree>()._imageTreeUnlockSinceLastTime.Contains(_cardID._title))
        {
            _emptyParent.GetComponent<ContainAllObjectTree>()._imageTreeUnlockSinceLastTime.Add(_cardID._title);
        }
        FindObjectOfType<SaveAndLoad>().SavePlayer();
        _image.enabled = true;
        _title.enabled = true;
        _title.gameObject.SetActive(true);
        DrawLineAuto();
        ChangeLineMaterial();
    }

    void ChangeLineMaterial()
    {
        for (int i = 0; i < _lineRendererGO.Count; i++)
        {
            _lineRendererGO[i].GetComponent<LineRenderer>().material = _materialLine;
        }
    }

    public void IClick()
    {
        _cardZoom.SetActive(true);
        _imageZoomCard.sprite = _cardID._image;
        _titleZoomCard.text = _cardID._title;
        _descriptionZoomCard.text = _cardID._description;
    }
}
