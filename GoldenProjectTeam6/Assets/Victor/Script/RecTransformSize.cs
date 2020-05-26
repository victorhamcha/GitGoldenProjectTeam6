using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecTransformSize : MonoBehaviour
{
    public RectTransform succes;
    public RectTransform movingPanelLock;
    public RectTransform movingPanelUnlock;
    private ContratsPanel panel;
    public bool lockSucces;
    void Start()
    {
        panel = FindObjectOfType<ContratsPanel>();
        
        StartCoroutine(waitForLoading());
      

    }

    // Update is called once per frame
    void Update()
    {

    }
    IEnumerator waitForLoading()
    {
        yield return new WaitForSeconds(0.012f);
      ////////LOCK////
            float height = panel.lockSucces.Count * (succes.rect.height + panel.space - succes.rect.height)+400;
           
            movingPanelLock.sizeDelta = new Vector2(100, height);
            movingPanelLock.anchoredPosition = new Vector2(0, -height/2f);

        /////UNLOCK////
            float height2 = panel.unlockSucces.Count * (succes.rect.height + panel.space - succes.rect.height)+400;
            
            movingPanelUnlock.sizeDelta = new Vector2(100, height2);
            movingPanelUnlock.anchoredPosition = new Vector2(0, -height2 / 2f);

    }
}
