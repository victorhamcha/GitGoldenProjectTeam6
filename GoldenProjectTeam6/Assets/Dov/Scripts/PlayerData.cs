using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData
{
    public int scoreData;
    public bool[] sucessData;
    public float[] position;

    public PlayerData (ScoreSystem score)
    {
        scoreData = score.score;
        sucessData = score.sucess;

        position = new float[3];
        position[0] = score.transform.position.x;
        position[1] = score.transform.position.y;
        position[2] = score.transform.position.z;
    }
}
