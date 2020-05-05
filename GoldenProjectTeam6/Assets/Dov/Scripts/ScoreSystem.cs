using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreSystem : MonoBehaviour
{
    public int score = 0;
    public bool[] sucess;
    public Text scoreText;

    void Update()
    {
        scoreText.text = score.ToString();

        if (score == 10)
        {
            sucess[0] = true;
        }
        if (score == 20)
        {
            sucess[1] = true;
        }
    }

    public void SavePlayer()
    {
        SaveSystem.SaveScore(this);
    }

    public void LoadPlayer()
    {
        PlayerData data = SaveSystem.LoadPlayer();
        score = data.scoreData;
        sucess = data.sucessData;

        Vector3 position;
        position.x = data.position[0];
        position.y = data.position[1];
        position.z = data.position[2];
        transform.position = position;
    }
}
