using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Diagnostics.Tracing;
//using System.Security.Policy;

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
    [HideInInspector] public TextMeshProUGUI _textDeathCard;
    [HideInInspector] public GameObject _cardZoom;
    [HideInInspector] public int _ordreList = 1;
    float _ordreInListTempo = 0.3f;

    [HideInInspector] public Material _lineMove;

    [HideInInspector] public GameObject _lightDeadCard;


    public int _idInList;
    bool _alreadyInTree;
    [HideInInspector] public bool _alreadyDraw;

    Button _button;
    float _lineSize = 5;

    [HideInInspector] public bool _canSpawn;

    bool _spawnLight=true;



    void Awake()
    {

    }

    void Start()
    {
        LoadCard();
    }

    public void LoadCard()
    {
        if (FindObjectOfType<OngletArboManager>()._listEvents[_idInList] == _titleZoomCard.text)
        {
            foreach (Transform child in transform)
            {
                if (child.name == "ImageBackground")
                {
                    _imageBackground = child.GetComponent<Image>();
                }
                if (child.GetComponent<Button>())
                {
                    _button = child.GetComponent<Button>();
                }
            }

            GetComponent<Image>().color = new Vector4(0, 0, 0, 0);
            CheckIfIsInTree();
            if (_alreadyInTree)
            {
                _image.material = null;
                _imageBackground.material = null;
            }
            CheckIfAlreadyDraw();
            _canSpawn = true;
        }
    }

    void Update()
    {
        if(_canSpawn)
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
            Color _color = _lineRendererGO[i].GetComponent<LineRendererAnimation>()._color;
            _lineRendererGO[i].gameObject.transform.parent = this.gameObject.transform;
            _lineRendererGO[i].GetComponent<LineRenderer>().useWorldSpace = true;
            _lineRendererGO[i].GetComponent<LineRenderer>().SetWidth(_lineSize, _lineSize);
            _lineRendererGO[i].GetComponent<LineRenderer>().SetColors(_color, _color);
            _lineRendererGO[i].GetComponent<LineRenderer>().material = _lineMove;
            _lineRendererGO[i].GetComponent<LineRenderer>().SetPosition(0, this.transform.position);
            _lineRendererGO[i].GetComponent<LineRenderer>().sortingOrder = -1;
            _lineRendererGO[i].GetComponent<LineRenderer>().sortingLayerName = "Card";
            if (i == 0)
            {
                _lineRendererGO[i].GetComponent<LineRenderer>().SetPosition(1, _positionLeft.position);
            }
            else if (i == 1)
            {
                _lineRendererGO[i].GetComponent<LineRenderer>().SetPosition(1, _positionRight.position);
            }
            else
            {
                if(_positionUp != null)
                {
                    _lineRendererGO[i].GetComponent<LineRenderer>().SetPosition(1, _positionUp.position);
                    
                }
            }

            Vector2 _positionStart = _lineRendererGO[i].GetComponent<LineRenderer>().GetPosition(0);
            Vector2 _positionEnd = _lineRendererGO[i].GetComponent<LineRenderer>().GetPosition(1);


            if (_positionEnd.x == 0 || _positionEnd.y == 0)
            {
                _lineRendererGO[i].GetComponent<LineRenderer>().SetWidth(0, 0);
            }

            StartCoroutine(DrawCardOnLine());
        }
    }

    void Assigner()
    {
        //_title.text = _cardID._title;
        //_titleText.text = _cardID._title;
        _image.enabled = true;
        _imageBackground.enabled = true;
        _button.enabled = true;
        _image.sprite = _cardID._image;
        if (_cardID._isDeadCard)
        {
            if (_spawnLight)
            {
                GameObject light = Instantiate(_lightDeadCard, transform.position, transform.rotation);
                light.gameObject.transform.parent = gameObject.transform;
                _spawnLight = false;
            }
        }

        for (int i = 0; i < _lineRendererGO.Count; i++)
        {
            _lineRendererGO[i].GetComponent<LineRenderer>().SetColors(Color.white, Color.white);
        }
        //_titleText.material = null;

    }

    void CheckIfAlreadyDraw()
    {

        // --- RECHANGER ICI --- \\
        //CHANGE NEXT LINE TO !_alreadyDraw


        if (_alreadyDraw) // Card never draw
        {
            _image.enabled = false;
            _imageBackground.enabled = false;
            _button.enabled = false;
            //_title.enabled = false;
            //_titleText.enabled = false;
        }
        else // Card already draw
        {
            if (_alreadyInTree) //Card already shows in tree so don't play anim
            {
                _image.enabled = true;
                _imageBackground.enabled = true;
                _button.enabled = true;
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

    IEnumerator DrawCardOnLine()
    {
        yield return new WaitForSeconds(_ordreInListTempo /*_ordreList*/);
        for (int i = 0; i < _lineRendererGO.Count; i++)
        {
            CardOnLine(i);
        }


    }

    void CardOnLine(int i)
    {
        Vector2 _positionStart = _lineRendererGO[i].GetComponent<LineRenderer>().GetPosition(0);
        Vector2 _positionEnd = _lineRendererGO[i].GetComponent<LineRenderer>().GetPosition(1);

        if (_positionEnd.x != 0 && _positionEnd.y != 0)
        {
            if (_positionLeft != null)
            {
                if (i == 0 && !_positionLeft.gameObject.GetComponent<ImageArborescence>()._alreadyDraw)
                {
                    _lineRendererGO[i].GetComponent<LineRendererAnimation>().SpawnImage(_positionLeft.transform);
                }
            }
            if (_positionRight != null)
            {
                if (i == 1 && !_positionRight.gameObject.GetComponent<ImageArborescence>()._alreadyDraw)
                {
                    _lineRendererGO[i].GetComponent<LineRendererAnimation>().SpawnImage(_positionRight.transform);
                }
            }
            if (_positionUp != null)
            {
                if (i == 2 && !_positionUp.gameObject.GetComponent<ImageArborescence>()._alreadyDraw)
                {
                    _lineRendererGO[i].GetComponent<LineRendererAnimation>().SpawnImage(_positionUp.transform);
                }
            }
        }

    }

    IEnumerator ShowUp()
    {
        //_image.material = _materialImg;
        //_imageBackground.material = _materialImg;
        //_titleText.enabled = true;
        //_titleText.text = _cardID._title;
        //_titleText.gameObject.SetActive(true);
        //_titleText.material.SetFloat("_Dissolve", 0);
        DragCamHere();
        yield return new WaitForSeconds(_ordreInListTempo /*_ordreList*/);

        _image.enabled = true;
        _imageBackground.enabled = true;
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
        _button.enabled = true;
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

        _imageBackground.material = _materialLine;
        _image.material = _materialLine;
        StartCoroutine(LineMove());
    }

    IEnumerator LineMove()
    {
        yield return new WaitForSeconds(1);
        for (int i = 0; i < _lineRendererGO.Count; i++)
        {
            _lineRendererGO[i].GetComponent<LineRenderer>().material = _lineMove;
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


        if (!_cardID._isDeadCard && !_cardID._isEndingEvent)
        {
            _textDeathCard.text = "";

            //SLIDE RIGHT DESCRIPTION
            if (_cardID._canSlideRight)
            {
                if (_cardID._isNextCardRight != null)
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
        else
        {
            _textDeathCard.text = _cardID._description;
            _textSlideRight.text = "";
            _textSlideLeft.text = "";
            _textSlideUp.text = "";
        }
    }
}
