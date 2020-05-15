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


    public float[] position;
    public float[] position2;
    public float[] position3;
    public float[] position4;

    public PlayerData (ContainAllObjectTree objectTree, GameManager cardsAlreadyDraw, PauseMenu saveOptions, CardValuesWithScriptable cardvalue)
    {

        imageTreeData = objectTree._imageTreeChildAlreadyInTree;
        imageTreeUnlockSinceLastTimeData = objectTree._imageTreeUnlockSinceLastTime;

        savingDrawCardCardData = cardsAlreadyDraw._savingDrawCardCard;

        optionsData = saveOptions.options;

        firstCardData = cardvalue._firstCardScriptable.name;

        position = new float[3];
        position[0] = objectTree.transform.position.x;
        position[1] = objectTree.transform.position.y;
        position[2] = objectTree.transform.position.z;

        position2 = new float[3];
        position2[0] = cardsAlreadyDraw.transform.position.x;
        position2[1] = cardsAlreadyDraw.transform.position.y;
        position2[2] = cardsAlreadyDraw.transform.position.z;

        position3 = new float[3];
        position3[0] = saveOptions.transform.position.x;
        position3[1] = saveOptions.transform.position.y;
        position3[2] = saveOptions.transform.position.z;

        position4 = new float[3];
        position4[0] = saveOptions.transform.position.x;
        position4[1] = saveOptions.transform.position.y;
        position4[2] = saveOptions.transform.position.z;
    }
}
