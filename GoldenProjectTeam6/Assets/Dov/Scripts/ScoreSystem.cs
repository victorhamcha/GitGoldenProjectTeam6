using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreSystem : MonoBehaviour
{
    public int score = 0;
    public Text scoreText;
    private bool successTest = false;
    private Touch touch;

    void Update()
    {
        scoreText.text = score.ToString();
        score += Mathf.RoundToInt(Time.deltaTime);

        if (score == 10)
        {
            successTest = true;
            Debug.Log(successTest);
        }
        if (score == 20)
        {
            successTest = false;
            Debug.Log(successTest);
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

        Vector3 position;
        position.x = data.position[0];
        position.y = data.position[1];
        position.z = data.position[2];
        transform.position = position;
    }
}
