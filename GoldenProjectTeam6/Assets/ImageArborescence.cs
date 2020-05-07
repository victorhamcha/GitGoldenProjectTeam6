using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ImageArborescence : MonoBehaviour
{
    [HideInInspector] public Image _image;
    [HideInInspector] public TextMeshProUGUI _title;
    public List<GameObject> _objectToLink;
    [HideInInspector] public List<GameObject> _lineRendererGO;
    [HideInInspector] public GameObject _lineRendererShowNext;
    public Color _lineColor;

    public CardScriptableObject _cardID;
    


    void Start()
    {
        foreach (GameObject objectLink in _objectToLink)
        {
            _lineRendererGO.Add(Instantiate(_lineRendererShowNext, this.transform.position, this.transform.rotation));
        }
        DrawLine();
        Assigner();
    }

    void DrawLine()
    {
        for (int i = 0; i < _objectToLink.Count; i++)
        {
            _lineRendererGO[i].gameObject.transform.parent = this.gameObject.transform;
            _lineRendererGO[i].GetComponent<LineRenderer>().useWorldSpace = true;
            _lineRendererGO[i].GetComponent<LineRenderer>().SetPosition(0, this.transform.position);
            _lineRendererGO[i].GetComponent<LineRenderer>().SetPosition(1, _objectToLink[i].transform.position);
            //_lineRendererGO[i].GetComponent<LineRenderer>().SetColors(Color.red, Color.red);

        }

    }

    void Assigner()
    {
        _title.text = _cardID._title;
        _image.sprite = _cardID._image;
    }
}
