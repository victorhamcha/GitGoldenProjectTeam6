using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData
{
    public List<string> imageTreeData;
    public List<string> imageTreeUnlockSinceLastTimeData;
    public List<string> savingDrawCardCardData;
    public List<bool> optionsData;
    


    public PlayerData (ContainAllObjectTree objectTree, GameManager cardsAlreadyDraw, PauseMenu saveOptions)
    {

        imageTreeData = objectTree._imageTreeChildAlreadyInTree;
        imageTreeUnlockSinceLastTimeData = objectTree._imageTreeUnlockSinceLastTime;

        savingDrawCardCardData = cardsAlreadyDraw._savingDrawCardCard;

        optionsData = saveOptions.options;
    }

}


[System.Serializable]
public class CardsData
{
    public string firstCardData;
    public List<bool> allSuccesData;

    public CardsData(CardValuesWithScriptable cardvalue, SuccesManager allSucces)
    {

        if (cardvalue != null)
        {
            firstCardData = cardvalue._firstCardScriptable.name;
        }


        if (allSucces != null)
        {
           allSuccesData = allSucces.lockInfo;
        }

    }
}