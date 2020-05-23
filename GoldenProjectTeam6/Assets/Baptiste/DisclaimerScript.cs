using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DisclaimerScript : MonoBehaviour
{
    [SerializeField]
    private float Timer;
    private bool loadingScene = false;

    private void Update()
    {
        Timer -= Time.deltaTime;
        if (Timer <= 0|| Input.GetMouseButtonDown(0))
            SceneTransition();
    }

    private void SceneTransition()
    {
        if (!loadingScene)
            StartCoroutine(LoadYourAsyncScene("MenuModifVic"));
    }

    IEnumerator LoadYourAsyncScene(string scene)
    {
        loadingScene = true;
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(scene);

        // Wait until the asynchronous scene fully loads
        while (!asyncLoad.isDone)
        {
            yield return null;
        }
    }
}
