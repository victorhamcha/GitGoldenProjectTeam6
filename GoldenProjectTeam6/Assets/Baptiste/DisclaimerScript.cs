using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisclaimerScript : MonoBehaviour
{
    [SerializeField]
    private float Timer;

    private void Update()
    {
        Timer -= Time.deltaTime;
        if (Timer <= 0/* || Fais le truc ou le mec touche l'écran*/)
            SceneTransition();
    }

    private void SceneTransition()
    {
        // Fais le truc magique ou la scene change
    }
}
