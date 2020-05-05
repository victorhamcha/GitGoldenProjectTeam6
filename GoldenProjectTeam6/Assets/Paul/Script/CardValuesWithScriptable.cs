using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class CardValuesWithScriptable : MonoBehaviour
{
    [Header("First Card To Play")]
    public CardScriptableObject _firstCardScriptable;
    [Header("Value to change")]
    public Image _imageCard;
    public TextMeshProUGUI _titleCard, _descriptionCard;

    CardScriptableObject _nextCardLeft, _nextCardRight, _nextCardUp;
    
    bool _isUnlockingSuccess, _canSlideUp, _isUnlockingObject, _isADeadCard;

    [HideInInspector]public string _enumSuccess, _enumDirectionOfSwipeToUnlockObject;

    string _descriptionBySlidingLeft, _descriptionBySlidingRight, _descriptionBySlidingUp;

    int _numberInList;

    [HideInInspector] public List<int> _conditionNumberList;

    void Start()
    {
        LoadValueFromScriptableObject();
    }

    void LoadValueFromScriptableObject()
    {
        _imageCard.sprite = _firstCardScriptable._image;
        _titleCard.text = _firstCardScriptable._title;
        _descriptionCard.text = _firstCardScriptable._description;


        _isADeadCard = _firstCardScriptable._isDeadCard;
        

        //if it's a death card, the script stop here
        if (!_isADeadCard)
        {
            Debug.Log(_firstCardScriptable._isSwipingRightDescription);
            _nextCardLeft = _firstCardScriptable._isNextCardLeft;
            _nextCardRight = _firstCardScriptable._isNextCardRight;
            _nextCardUp = _firstCardScriptable._isNextCardUp;

            _isUnlockingSuccess = _firstCardScriptable._isSuccess;
            _isUnlockingObject = _firstCardScriptable._isUnlockingObject;
            _canSlideUp = _firstCardScriptable._canSlideUp;

            if (_isUnlockingSuccess)
            {
                _enumSuccess = _firstCardScriptable._enumSuccessString;
            }
            if (_isUnlockingObject)
            {
                _enumDirectionOfSwipeToUnlockObject = _firstCardScriptable._enumDirectpionSwipeString;
                _numberInList = _firstCardScriptable._findObjectInListToggle;
            }
            if (_canSlideUp)
            {
                _nextCardUp = _firstCardScriptable._isNextCardUp;
                _conditionNumberList = _firstCardScriptable._conditionObjetListForCardManager;
                Debug.Log(_conditionNumberList.Count);
                Debug.Log(_conditionNumberList[_conditionNumberList.Count - 1]);
            }
        }
    }

    public void IsSwiping()
    {

    }


    // When player swipes left
    public void GoLeft()
    {
        _firstCardScriptable = _nextCardLeft;
        LoadValueFromScriptableObject();
    }


    // When player swipes right
    public void GoRight()
    {
        _firstCardScriptable = _nextCardRight;
        LoadValueFromScriptableObject();
    }


    // When player swipes up
    public void GoUp()
    {
        _firstCardScriptable = _nextCardUp;
        LoadValueFromScriptableObject();
    }


    // If player unlocks object
    public void UnlockObject()
    {
        Debug.Log("I unlock " + _numberInList);
    }

}
