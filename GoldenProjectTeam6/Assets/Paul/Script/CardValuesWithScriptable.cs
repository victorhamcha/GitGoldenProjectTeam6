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
    public TextMeshProUGUI _titleCard, _descriptionCard, _descriptionLeftSwipe, _descriptionRightSwipe, _descriptionUpSwipe;

    CardScriptableObject _nextCardLeft, _nextCardRight, _nextCardUp;

    bool _isUnlockingSuccessRight;
    bool _isUnlockingSuccessLeft;
    bool _isUnlockingSuccessUp;
    

    bool _isADeadCard;
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

    void Update()
    {
    }
    


    // When player swipes left
    public void GoLeft()
    {
        if (_firstCardScriptable._canSlideLeft)
        {
            if(_firstCardScriptable._enumObjectToUnlockLeft.ToString() != "none")
            {
                UnlockObject(_firstCardScriptable._enumObjectToUnlockLeft);
            }
            if(_firstCardScriptable._enumSuccessLeft.ToString() != "none")
            {
                UnlockSuccess(_firstCardScriptable._enumSuccessLeft);
            }
        }
        _firstCardScriptable = _nextCardLeft;


        //if (_isUnlockingObjectRight)
        {
            if (_enumDirectionOfSwipeToUnlockObject == "_swipeLeft" || _enumDirectionOfSwipeToUnlockObject == "_wathever")
            {
                VerifyIfCanSlideUp();
            }
        }
        if (!_isADeadCard)
            LoadValueFromScriptableObject();
        else
        {
            Death();
        }
    }


    // When player swipes right
    public void GoRight()
    {
        _firstCardScriptable = _nextCardRight;
        //if (_isUnlockingObjectRight)
        {
            if (_enumDirectionOfSwipeToUnlockObject == "_swipeRight" || _enumDirectionOfSwipeToUnlockObject == "_wathever")
            {
                VerifyIfCanSlideUp();
            }
        }
        if (!_isADeadCard)
            LoadValueFromScriptableObject();
        else
        {
            Death();
        }
    }


    // When player swipes up
    public void GoUp()
    {
        //_firstCardScriptable = _nextCardUp; if (_isUnlockingObjectRight)
        {
            if (_enumDirectionOfSwipeToUnlockObject == "_swipeUp" || _enumDirectionOfSwipeToUnlockObject == "_wathever")
            {
                VerifyIfCanSlideUp();
            }
        }
        if(!_isADeadCard)
            LoadValueFromScriptableObject();
        else
        {
            Death();
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
        if(_unlockSlideUpInt == _enumConditionListObject.Count)
        {
            ICanSlideUp();
        }
        
    }

    void ICanSlideUp()
    {
        Debug.Log("Je slide Up");
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
        foreach (SingletonInventory singletonInventory in FindObjectOfType<InventoryList>()._inventory)
        {
            if (singletonInventory._objectList.ToString() == _successToUnlock.ToString())
            {
                singletonInventory._hasThisObject = true;
            }
        }
    }

    void Death()
    {
        Debug.Log("Death go to achievement");
    }
}
