using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ListEventStockTree : MonoBehaviour
{
    public string _imageNameRef;
    [Range(0,12)] public int _id;
    public List<ImageArborescence> _image;
    [HideInInspector] public ContainAllObjectTree _parent;
    [HideInInspector] public TextMeshProUGUI _textCalcul;
    [HideInInspector] public OngletArboManager _ongletArboManager;
    public int _checker;

    void Start()
    {
        StartCoroutine(WaitToCheck());
    }

    IEnumerator WaitToCheck()
    {
        yield return new WaitForSeconds(0.5f);
        Check();
    }
    public void Check()
    {
        if (_image.Count == 0)
        {
            for (int i = 0; i < _parent._imageTreeChilds.Count; i++)
            {
                if (_parent._imageTreeChilds[i].name.ToLower().Contains(_imageNameRef.ToLower()))
                {
                    _image.Add(_parent._imageTreeChilds[i].GetComponent<ImageArborescence>());
                }
            }
        }
        if(_checker == 0) {

            for (int i = 0; i < _image.Count; i++)
            {
                if (_parent._imageTreeUnlockSinceLastTime.Contains(_image[i].name))
                {
                    _checker++;
                }
            }

            if (_checker == _image.Count)
            {
                _textCalcul.color = Color.red;

            }
            else
            {
                _textCalcul.color = Color.white;
            }
        }

        _textCalcul.text = _checker + " / " + _image.Count;
    }
}
