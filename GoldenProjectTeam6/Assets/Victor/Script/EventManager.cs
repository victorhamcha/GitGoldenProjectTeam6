using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    //to know wish place we are in;
    public CardValuesWithScriptable card;
    public enum place { LOL,BOB};
    //only the fist car of ish event taht are on this places//////////////////////////
    public List<CardScriptableObject> cirqueEvents = new List<CardScriptableObject>();
    public List<CardScriptableObject> baladeEvents = new List<CardScriptableObject>();
    public List<CardScriptableObject> restaurantEvents = new List<CardScriptableObject>();
    public List<CardScriptableObject> animalerieEvents = new List<CardScriptableObject>();
    place _place;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
           
    }


    public List<CardScriptableObject>EventPlace(string place)
    {
        List<CardScriptableObject> eventPlace =cirqueEvents; 
        if (place=="_circus")
        {
            eventPlace = cirqueEvents;
        }
        else if (place == "_balade")
        {
            eventPlace = baladeEvents;
        }
        else if (place == "_restaurant")
        {
            eventPlace = restaurantEvents;
        }
        else if (place == "_animalerie")
        {
            eventPlace = animalerieEvents;
        }
        return eventPlace;
    }

    public CardScriptableObject LoadNewEvent(string place)
    {
      
        List<CardScriptableObject> placeEvents=EventPlace(place);
        CardScriptableObject theNextCard=null;
        int x = Random.Range(0, placeEvents.Count);
        theNextCard = placeEvents[x];
        Debug.Log(placeEvents.Count);
        Debug.Log(place);
        Debug.Log(theNextCard.name);
        Debug.Log(card._firstCardScriptable._firstCardOfEvent.name);
        while (theNextCard==card._firstCardScriptable._firstCardOfEvent&&placeEvents.Count>1)
        {
            
            x = Random.Range(0, placeEvents.Count);
            theNextCard = placeEvents[x];
        }    
        return theNextCard;
    }

    public void RemoveCard(CardScriptableObject card,string place)
    {
        
        List<CardScriptableObject> placeEvents = EventPlace(place);
        CardScriptableObject removedCard;
        for (int i=0;i<placeEvents.Count;i++)
        {
            if(card._firstCardOfEvent==placeEvents[i])
            {
               
                removedCard = placeEvents[i];
                if (place == "_circus")
                {
                    cirqueEvents.Remove(removedCard);
                   
                }
                else if (place == "_balade")
                {
                    baladeEvents.Remove(removedCard);
                }
                else if (place == "_restaurant")
                {
                    restaurantEvents.Remove(removedCard);
                }
                else if (place == "_animalerie")
                {
                    animalerieEvents.Remove(removedCard);
                }
               
                break;
            }
        }
      
    }
}
