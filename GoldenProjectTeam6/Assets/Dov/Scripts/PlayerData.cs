using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData
{
    public int scoreData;
    public float[] position;

    public PlayerData (ScoreSystem score)
    {
        scoreData = score.score;

        position = new float[3];
        position[0] = score.transform.position.x;
        position[1] = score.transform.position.y;
        position[2] = score.transform.position.z;
    }
}
