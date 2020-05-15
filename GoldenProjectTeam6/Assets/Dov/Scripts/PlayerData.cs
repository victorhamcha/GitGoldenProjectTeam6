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
    public string firstCardData;


    public PlayerData (ContainAllObjectTree objectTree, GameManager cardsAlreadyDraw, PauseMenu saveOptions, CardValuesWithScriptable cardvalue)
    {

        imageTreeData = objectTree._imageTreeChildAlreadyInTree;
        imageTreeUnlockSinceLastTimeData = objectTree._imageTreeUnlockSinceLastTime;

        savingDrawCardCardData = cardsAlreadyDraw._savingDrawCardCard;

        optionsData = saveOptions.options;


        if (cardvalue != null)
        {
            firstCardData = cardvalue._firstCardScriptable.name;
        }

    }
}