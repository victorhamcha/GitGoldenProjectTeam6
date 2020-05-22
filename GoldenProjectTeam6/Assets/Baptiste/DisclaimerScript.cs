using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DisclaimerScript : MonoBehaviour
{
    [SerializeField]
    private float Timer;

    private void Update()
    {
        Timer -= Time.deltaTime;
        if (Timer <= 0|| Input.GetMouseButtonDown(0))
            SceneTransition();
    }

    private void SceneTransition()
    {
        SceneManager.LoadScene("MenuModifVic");
    }
}
