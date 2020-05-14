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

    bool _isUnlockingSuccessRight;
    
    [HideInInspector] public bool canSlideUp, _isADeadCard, _unlockSlideUp, _isAContrat;
    [HideInInspector] public string _enumSuccess, _enumDirectionOfSwipeToUnlockObject,_enumPlace, _enumObjectToUnlock;


    [HideInInspector] public List<int> _conditionNumberList;

    int _unlockSlideUpInt;

    [HideInInspector] public List<EnumListObject._objectList> _enumConditionListObject;

    EventManager eventManager;
    

    void Start()
    {
        eventManager = FindObjectOfType<EventManager>();
        LoadValueFromScriptableObject();
    }

    void LoadValueFromScriptableObject()
    {
        _unlockSlideUpInt = 0;
        _imageCard.sprite = _firstCardScriptable._image;
        

        //SAVE


        if (_firstCardScriptable._canSlideLeft)
            _descriptionLeftSwipe.text = _firstCardScriptable._isSwipingLeftDescription;

        if (_firstCardScriptable._canSlideLeft)
            _descriptionRightSwipe.text = _firstCardScriptable._isSwipingRightDescription;

        if (_firstCardScriptable._canSlideUp)
            _descriptionUpSwipe.text = _firstCardScriptable._isSwipingUpDescription;

        _isAContrat = _firstCardScriptable._isContratCard;

        if (!_isAContrat)
        {
            _titleCard.text = _firstCardScriptable._title;
            _descriptionCard.text = _firstCardScriptable._description;

            if (!FindObjectOfType<GameManager>()._savingDrawCardCard.Contains(_firstCardScriptable._title))
            {
                FindObjectOfType<GameManager>()._savingDrawCardCard.Add(_firstCardScriptable._title);
                FindObjectOfType<SaveAndLoad>().SavePlayer();
            }

            _isADeadCard = _firstCardScriptable._isDeadCard;

            _enumPlace = _firstCardScriptable._enumPlaceString;

            if (!_isADeadCard)
            {
                _nextCardLeft = _firstCardScriptable._isNextCardLeft;
                _nextCardRight = _firstCardScriptable._isNextCardRight;
                _nextCardUp = _firstCardScriptable._isNextCardUp;

                _isUnlockingSuccessRight = _firstCardScriptable._isSuccess;

                if (_isUnlockingSuccessRight)
                {
                    _enumSuccess = _firstCardScriptable._enumSuccessString;
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
    }
    


    // When player swipes left
    public void GoLeft()
    {
        if (!_isAContrat)
        {
            if (_firstCardScriptable._canSlideLeft)
            {
                if (_firstCardScriptable._enumObjectToUnlockLeft.ToString() != "none")
                {
                    UnlockObject(_firstCardScriptable._enumObjectToUnlockLeft);
                }
                if (_firstCardScriptable._enumSuccessLeft.ToString() != "none")
                {
                    UnlockSuccess(_firstCardScriptable._enumSuccessLeft);
                }
            }
            Debug.Log(_firstCardScriptable._isEndingEvent);
            Debug.Log(_firstCardScriptable._enumDirectpionSwipeString);


            if (_firstCardScriptable._isEndingEvent)// && (_firstCardScriptable._enumDirectpionSwipeString == "_swipeLeft"|| _firstCardScriptable._enumDirectpionSwipeString == ""))
            {
                //Debug.Log("enterTheWay");
                if (_firstCardScriptable._eventCanBePlayOne)
                {
                    eventManager.RemoveCard(_firstCardScriptable, _firstCardScriptable._placeEnum.ToString());
                }
                _nextCardLeft = eventManager.LoadNewEvent(_firstCardScriptable._placeEnum.ToString());
                //Debug.Log(_firstCardScriptable._placeEnum.ToString());
            }

            _firstCardScriptable = _nextCardLeft;
            if (!_isADeadCard)
                LoadValueFromScriptableObject();

            else
            {
                Death();
            }

            canSlideUp = false;
        }
        else
        {
            AfterContrat();
        }
        

    }


    // When player swipes right
    public void GoRight()
    {
        if (!_isAContrat)
        {
            if (_firstCardScriptable._canSlideLeft)
            {
                if (_firstCardScriptable._enumObjectToUnlockRight.ToString() != "none")
                {
                    UnlockObject(_firstCardScriptable._enumObjectToUnlockRight);
                }
                if (_firstCardScriptable._enumSuccessRight.ToString() != "none")
                {
                    UnlockSuccess(_firstCardScriptable._enumSuccessRight);
                }
            }


            // Debug.Log(_isADeadCard);
            if (_firstCardScriptable._isEndingEvent) //&& (_firstCardScriptable._enumDirectpionSwipeString == "_swipeRight" || _firstCardScriptable._enumDirectpionSwipeString == ""))
            {

                if (_firstCardScriptable._eventCanBePlayOne)
                {
                    eventManager.RemoveCard(_firstCardScriptable, _firstCardScriptable._placeEnum.ToString());
                }
                _nextCardRight = eventManager.LoadNewEvent("_balade");
            }

            _firstCardScriptable = _nextCardRight;

            if (!_isADeadCard)
            {
                LoadValueFromScriptableObject();
                // Debug.Log("gotRight");
            }
            else
            {
                Death();
            }

            canSlideUp = false;
        }
        else
        {
            AfterContrat();
        }
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
        if (_unlockSlideUpInt == _enumConditionListObject.Count)
        {
            canSlideUp = true;
            
        }
        

    }

    public void GoUp()
    {
        if (!_isAContrat)
        {

            if (!_firstCardScriptable._isEndingEvent)
            {
                if (_firstCardScriptable._canSlideUp)
                {
                    if (_firstCardScriptable._enumObjectToUnlockUp.ToString() != "none")
                    {
                        UnlockObject(_firstCardScriptable._enumObjectToUnlockUp);
                    }
                    if (_firstCardScriptable._enumSuccessUp.ToString() != "none")
                    {
                        UnlockSuccess(_firstCardScriptable._enumSuccessUp);
                    }
                }





                _firstCardScriptable = _nextCardUp;

                if (!_isADeadCard)
                    LoadValueFromScriptableObject();

                else
                {
                    if (_firstCardScriptable._enumSuccessDeath.ToString() != "none")
                    {
                        UnlockSuccess(_firstCardScriptable._enumSuccessUp);
                    }
                    Death();
                }
                canSlideUp = false;
            }
        }
        else
        {
            AfterContrat();
        }
    }

    void AfterContrat()
    {
        Debug.Log("After Contrat");
    }

    void UnlockObject(EnumListObject._objectList _objectToUnlock)
    {
            foreach (SingletonInventory singletonInventory in FindObjectOfType<InventoryList>()._inventory)
            {
                if (singletonInventory._objectList.ToString() == _objectToUnlock.ToString())
                {
                    singletonInventory._hasThisObject = true;
                }
            }
    }

    void UnlockSuccess(EnumSuccess._enumSuccess _successToUnlock)
    {
        if(_successToUnlock.ToString() != "none")
        {

        }
    }

    void Death()
    {
        Debug.Log("Death go to achievement");
    }
}
