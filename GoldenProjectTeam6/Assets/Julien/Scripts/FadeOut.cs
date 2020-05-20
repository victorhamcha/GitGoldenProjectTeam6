using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class FadeOut : MonoBehaviour
{

    Image rend;

    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<Image>();
       
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine("FadeOutCoroutine");
    }

    IEnumerator FadeOutCoroutine()
    {
        for(float f = 1f; f >= -0.05f; f-= 0.05f)
        {
            Color c = rend.material.color;
            c.a = f;
            rend.material.color = c;
            yield return new WaitForSeconds(0.05f);
        }
    }




}
