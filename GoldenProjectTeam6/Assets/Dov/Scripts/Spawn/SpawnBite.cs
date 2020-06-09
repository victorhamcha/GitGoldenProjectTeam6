using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBite : MonoBehaviour
{
    public GameObject bloodFx;
    public GameObject obBite;
    private SpriteRenderer spriteBite;
    private bool biteCanAppear;
    private bool biteCanDisappear;
    [Range(0, 0.1f)] public float speed;


    void Awake()
    {
        GameObject ob2 = Instantiate(obBite);
        Destroy(ob2, 6);
        spriteBite = ob2.GetComponent<SpriteRenderer>();
        biteCanAppear = true;
    }


    void Update()
    {
        if (biteCanAppear)
        {
            spriteBite.color = new Vector4(spriteBite.color.r, spriteBite.color.g, spriteBite.color.b, spriteBite.color.a + speed);
            if (spriteBite.color.a > 0.95)
            {
                biteCanAppear = false;
                StartCoroutine(BiteAppear());
            }
        }

        if (biteCanDisappear)
        {
            spriteBite.color = new Vector4(spriteBite.color.r, spriteBite.color.g, spriteBite.color.b, spriteBite.color.a - speed);
            if (spriteBite.color.a < 0.02)
            {
                biteCanDisappear = false;
            }
        }
    }

    IEnumerator BiteAppear()
    {
        GameObject ob = Instantiate(bloodFx);
        Destroy(ob, 4.0f);
        yield return new WaitForSeconds(1.5f);
        biteCanDisappear = true;
    }
}
