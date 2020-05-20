using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Diagnostics.Tracing;

public class ImageArborescence : MonoBehaviour
{
    [HideInInspector] public Image _image;
    [HideInInspector] public Image _imageBackground;
    //[HideInInspector] public TextMeshProUGUI _title;
    //[HideInInspector] public Text _titleText;
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
    [HideInInspector] public TextMeshProUGUI _textSlideRight;
    [HideInInspector] public TextMeshProUGUI _textSlideLeft;
    [HideInInspector] public TextMeshProUGUI _textSlideUp;
    [HideInInspector] public GameObject _cardZoom;
    [HideInInspector] public int _ordreList = 1;
    float _ordreInListTempo = 0.3f;

    
    public int _idInList;

     bool _alreadyInTree;
     bool _alreadyDraw;


    void Awake()
    {

        foreach (Transform child in transform)
        {
            if (child.name == "ImageBackground")
            {
                _imageBackground = child.GetComponent<Image>();
            }
        }
    }

    void Start()
    {
        CheckIfIsInTree();
        if (_alreadyInTree)
        {
            _image.material = null;
            _imageBackground.material = null;
        }
        CheckIfAlreadyDraw();

    }

    void Update()
    {
        IsSpawning();
    }

    void CheckIfIsInTree()
    {
        for (int i = 0; i < FindObjectOfType<SaveAndLoad>().unlockSinceLastTime.Count; i++)
        {
            if (FindObjectOfType<SaveAndLoad>().unlockSinceLastTime[i] == _cardID.name)
            {
                _alreadyInTree = true;
            }
        }

        for (int i = 0; i < FindObjectOfType<SaveAndLoad>().alreadyDrawCards.Count; i++)
        {
            if (FindObjectOfType<SaveAndLoad>().alreadyDrawCards[i] == _cardID.name)
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
            _imageBackground.material = null;
            //_titleText.material = null;
            Assigner();
        }
        else
        {
            _image.material.SetFloat("_Dissolve", _timeToRevealCard);
            _imageBackground.material.SetFloat("_Dissolve", _timeToRevealCard);
            //_titleText.material.SetFloat("_Dissolve", _timeToRevealCard);
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
            _lineRendererGO[i].GetComponent<LineRenderer>().SetWidth(3,3);
            _lineRendererGO[i].GetComponent<LineRenderer>().SetColors(Color.gray, Color.white);
            _lineRendererGO[i].GetComponent<LineRenderer>().SetPosition(0, this.transform.position);
            if (i == 0)
            {
                _lineRendererGO[i].GetComponent<LineRenderer>().SetPosition(1, _positionLeft.position);
                _lineRendererGO[i].GetComponent<LineRendererAnimation>().DistanceIsAttribuate(transform, _positionLeft.transform);
            }
            else if (i == 1)
            {
                _lineRendererGO[i].GetComponent<LineRenderer>().SetPosition(1, _positionRight.position);
                _lineRendererGO[i].GetComponent<LineRendererAnimation>().DistanceIsAttribuate(transform, _positionRight.transform);


            }
            else
            {
                _lineRendererGO[i].GetComponent<LineRenderer>().SetPosition(1, _positionUp.position);
                _lineRendererGO[i].GetComponent<LineRendererAnimation>().DistanceIsAttribuate(transform, _positionUp.transform);


            }

        }
    }

    void Assigner()
    {
        //_title.text = _cardID._title;
        //_titleText.text = _cardID._title;
        _image.enabled = true;
        _imageBackground.enabled = true;
        _image.sprite = _cardID._image;
        //_titleText.material = null;
    }

    void CheckIfAlreadyDraw()
    {

        // --- RECHANGER ICI --- \\
        //CHANGE NEXT LINE TO !_alreadyDraw


        if (!_alreadyDraw) // Card never draw
        {
            _image.enabled = false;
            _imageBackground.enabled = false;
            //_title.enabled = false;
            //_titleText.enabled = false;
        }
        else // Card already draw
        {
            if (_alreadyInTree) //Card already shows in tree so don't play anim
            {
                _image.enabled = true;
                _imageBackground.enabled = true;
                //_title.enabled = true;
                //_titleText.enabled = true;
                Assigner();
                DrawLineAuto();
                //_title.gameObject.SetActive(true);
                //_titleText.gameObject.SetActive(true);
            }
            else //Card never shows in tree so play animation
            {
                //_image.enabled = false;
                //_title.enabled = false;
                //_titleText.enabled = true;
                StartCoroutine(ShowUp());
            }
        }
    }

    IEnumerator ShowUp()
    {
        _image.material = _materialImg;
        _imageBackground.material = _materialImg;
        //_titleText.enabled = true;
        //_titleText.text = _cardID._title;
        //_titleText.gameObject.SetActive(true);
        _image.material.SetFloat("_Dissolve", 0);
        _imageBackground.material.SetFloat("_Dissolve", 0);
        //_titleText.material.SetFloat("_Dissolve", 0);
        _image.enabled = false;
        _imageBackground.enabled = false;
        DragCamHere();
        yield return new WaitForSeconds(_ordreInListTempo * _ordreList);
        _image.material.SetFloat("_Dissolve", 0);
        _imageBackground.material.SetFloat("_Dissolve", 0);
        //_titleText.material.SetFloat("_Dissolve", 0);
        _image.sprite = _cardID._image;
        //_image.material.SetTexture("_MainTexture", _image.sprite.texture);
        _disolve = true;
        _alreadyInTree = true;
        if (!_emptyParent.GetComponent<ContainAllObjectTree>()._imageTreeUnlockSinceLastTime.Contains(_cardID.name))
        {
            _emptyParent.GetComponent<ContainAllObjectTree>()._imageTreeUnlockSinceLastTime.Add(_cardID.name);
        }
        FindObjectOfType<SaveAndLoad>().SavePlayer();
        _image.enabled = true;
        _imageBackground.enabled = true;
        //_title.enabled = true;
        //_title.gameObject.SetActive(true);
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

    void DragCamHere()
    {
        if (FindObjectOfType<OngletArboManager>()._canMoveToPosAtStart)
        {
            FindObjectOfType<OngletArboManager>()._canMoveToPosAtStart = false;
            FindObjectOfType<OngletArboManager>().FindOngletToActive(_idInList);
        }
    }

    public void IClick()
    {
        _cardZoom.SetActive(true);
        _imageZoomCard.sprite = _cardID._image;
        //_titleZoomCard.text = _cardID._title;

        //SLIDE RIGHT DESCRIPTION

        if (_cardID._canSlideRight)
        {
            if(_cardID._isNextCardRight != null)
            {
                _textSlideRight.text = _cardID._isSwipingRightDescription;
            }
            else
            {
                _textSlideRight.text = "";
            }
        }
        else
        {
            _textSlideRight.text = "";
        }

        //SLIDE LEFT DESCRIPTION

        if (_cardID._canSlideLeft)
        {
            if (_cardID._isNextCardLeft != null)
            {
                _textSlideLeft.text = _cardID._isSwipingLeftDescription;
            }
            else
            {
                _textSlideLeft.text = "";
            }
        }
        else
        {
            _textSlideLeft.text = "";
        }

        //SLIDE UP DESCRIPTION

        if (_cardID._canSlideUp)
        {
            if (_cardID._isNextCardRight != null)
            {
                _textSlideUp.text = _cardID._isSwipingUpDescription;
            }
            else
            {
                _textSlideUp.text = "";
            }
        }
        else
        {
            _textSlideUp.text = "";
        }
    }
}
