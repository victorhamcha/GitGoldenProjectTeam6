﻿using System.Collections;
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
    public TextMeshProUGUI _titleCard, _descriptionCard, _descriptionLeftSwipe, _descriptionRightSwipe, _descriptionUpSwipe;

    CardScriptableObject _nextCardLeft, _nextCardRight, _nextCardUp;
    
    bool _isUnlockingSuccess, _isUnlockingObject, _isADeadCard;
    [HideInInspector]public bool _unlockSlideUp;
    [HideInInspector] public string _enumSuccess, _enumDirectionOfSwipeToUnlockObject,_enumPlace, _enumObjectToUnlock;

    string _descriptionBySlidingLeft, _descriptionBySlidingRight, _descriptionBySlidingUp;

    int _numberInList;

    [HideInInspector] public List<int> _conditionNumberList;

    int _unlockSlideUpInt;

    [HideInInspector] public List<EnumListObject._objectList> _enumConditionListObject;

    void Start()
    {
        LoadValueFromScriptableObject();
        UnlockObject();
    }

    void LoadValueFromScriptableObject()
    {
        _unlockSlideUpInt = 0;
        _imageCard.sprite = _firstCardScriptable._image;
        _titleCard.text = _firstCardScriptable._title;
        _descriptionCard.text = _firstCardScriptable._description;
        _descriptionLeftSwipe.text = _firstCardScriptable._isSwipingLeftDescription;
        _descriptionRightSwipe.text = _firstCardScriptable._isSwipingRightDescription;


        _isADeadCard = _firstCardScriptable._isDeadCard;

        _enumPlace = _firstCardScriptable._enumPlaceString;

        //if it's a death card, the script stop here
        if (!_isADeadCard)
        {
            _nextCardLeft = _firstCardScriptable._isNextCardLeft;
            _nextCardRight = _firstCardScriptable._isNextCardRight;
            _nextCardUp = _firstCardScriptable._isNextCardUp;

            _isUnlockingSuccess = _firstCardScriptable._isSuccess;

            if (_isUnlockingSuccess)
            {
                _enumSuccess = _firstCardScriptable._enumSuccessString;
            }

            _isUnlockingObject = _firstCardScriptable._isUnlockingObject;

            if (_isUnlockingObject)
            {
                _enumDirectionOfSwipeToUnlockObject = _firstCardScriptable._enumDirectpionSwipeString;
                _numberInList = _firstCardScriptable._findObjectInListToggle;
                _enumObjectToUnlock = _firstCardScriptable._enumObjectToUnlock.ToString();
            }
            
            _unlockSlideUp = _firstCardScriptable._canSlideUp;

            if (_unlockSlideUp)
            {
                _nextCardUp = _firstCardScriptable._isNextCardUp;
                _descriptionUpSwipe.text = _firstCardScriptable._isSwipingUpDescription;
                _enumConditionListObject = _firstCardScriptable._enumObjectConditionList;
                VerifyIfCanSlideUp();
            }
        }
        else
        {
            _descriptionUpSwipe.text = _firstCardScriptable._isSwipingUpDescription;
        }
    }

    void Update()
    {
    }

    public void IsSwiping()
    {
        if (_isADeadCard)
        {
            Death();
        }
    }


    // When player swipes left
    public void GoLeft()
    {
        _firstCardScriptable = _nextCardLeft;
        if (_isUnlockingObject)
        {
            if (_enumDirectionOfSwipeToUnlockObject == "_swipeLeft" || _enumDirectionOfSwipeToUnlockObject == "_wathever")
            {
                VerifyIfCanSlideUp();
            }
        }
        if (!_isADeadCard)
            LoadValueFromScriptableObject();
    }


    // When player swipes right
    public void GoRight()
    {
        _firstCardScriptable = _nextCardRight; if (_isUnlockingObject)
        {
            if (_enumDirectionOfSwipeToUnlockObject == "_swipeRight" || _enumDirectionOfSwipeToUnlockObject == "_wathever")
            {
                VerifyIfCanSlideUp();
            }
        }
        if (!_isADeadCard)
            LoadValueFromScriptableObject();
    }


    // When player swipes up
    public void GoUp()
    {
        _firstCardScriptable = _nextCardUp; if (_isUnlockingObject)
        {
            if (_enumDirectionOfSwipeToUnlockObject == "_swipeUp" || _enumDirectionOfSwipeToUnlockObject == "_wathever")
            {
                VerifyIfCanSlideUp();
            }
        }
        if(!_isADeadCard)
            LoadValueFromScriptableObject();
    }

    
    public void VerifyIfCanSlideUp()
    {
        foreach (EnumListObject._objectList objectToVerify in _enumConditionListObject)
        {
            for (int i = 0; i < FindObjectOfType<InventoryList>()._inventory.Count; i++)
            {
                if (FindObjectOfType<InventoryList>()._inventory[i]._objectList == objectToVerify)
                {
                    if (FindObjectOfType<InventoryList>()._inventory[i]._hasThisObject)
                    {
                        _unlockSlideUpInt++;
                    }
                }
            }
        }
        if(_unlockSlideUpInt == _enumConditionListObject.Count)
        {
            ICanSlideUp();
        }
        
    }

    void ICanSlideUp()
    {
        Debug.Log("Je slide Up");
    }

    void UnlockObject()
    {
        if (_isUnlockingObject)
        {
            foreach (SingletonInventory singletonInventory in FindObjectOfType<InventoryList>()._inventory)
            {
                if (singletonInventory._objectList.ToString() == _enumObjectToUnlock)
                {
                    singletonInventory._hasThisObject = true;
                }
            }
        }
    }

    void Death()
    {

    }
}
