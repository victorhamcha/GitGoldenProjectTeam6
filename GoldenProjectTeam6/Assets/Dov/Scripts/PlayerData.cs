using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[System.Serializable]
public class PlayerData
{
    public List<string> imageTreeData;
    public List<string> imageTreeUnlockSinceLastTimeData;
    public List<string> savingDrawCardCardData;
    public List<bool> optionsData;
    public List<string> apparationOrderData;
    


    public PlayerData (ContainAllObjectTree objectTree, GameManager cardsAlreadyDraw, PauseMenu saveOptions)
    {

        imageTreeData = objectTree._imageTreeChildAlreadyInTree;
        imageTreeUnlockSinceLastTimeData = objectTree._imageTreeUnlockSinceLastTime;

        savingDrawCardCardData = cardsAlreadyDraw._savingDrawCardCard;
        apparationOrderData = cardsAlreadyDraw._apparitionOrder;

        optionsData = saveOptions.options;
    }

}


[System.Serializable]
public class CardsData
{
    public string firstCardData;
    public List<bool> allSuccesData = new List<bool>();

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

[System.Serializable] 
public class PassportData
{
    public string nameData;
    public string countryData;
    public int materialIndexData;

    public PassportData(ContratsPanel contrat)
    {
        if (contrat != null)
        {
            nameData = contrat.nameTXT.text;
            countryData = contrat.CountryTXT.text;
            materialIndexData = contrat.changeMat;
        }
    }
}