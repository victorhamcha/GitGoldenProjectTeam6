using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData
{

    public List<bool> imageTreeData;
    public List<bool> savingDrawCardBoolData;
    public List<string> savingDrawCardCardData;


    public float[] position;
    public float[] position2;

    public PlayerData (ContainAllObjectTree objectTree, GameManager cardsAlreadyDraw)
    {
        
        imageTreeData = objectTree._imageTreeChildAlreadyInTree;

        savingDrawCardCardData = cardsAlreadyDraw._savingDrawCardCard;
        savingDrawCardBoolData = cardsAlreadyDraw._savingDrawCardBool;

        position = new float[3];
        position[0] = objectTree.transform.position.x;
        position[1] = objectTree.transform.position.y;
        position[2] = objectTree.transform.position.z;

        position2 = new float[3];
        position2[0] = cardsAlreadyDraw.transform.position.x;
        position2[1] = cardsAlreadyDraw.transform.position.y;
        position2[2] = cardsAlreadyDraw.transform.position.z;
    }
}
