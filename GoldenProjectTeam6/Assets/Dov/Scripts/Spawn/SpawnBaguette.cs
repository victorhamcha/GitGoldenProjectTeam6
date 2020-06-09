using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBaguette : MonoBehaviour
{
    public GameObject obBaguette;
    public GameObject baguetteSmokeFx;
    private SpriteRenderer spriteBaguette;
    private bool baguetteCanAppear;
    private bool baguetteCanDisappear;
    [Range(0, 0.1f)] public float speed;

    void Awake()
    {
        GameObject ob = Instantiate(obBaguette);
        Destroy(ob, 6);
        FindObjectOfType<AudioManager>().Play("SFX_DeathBaguette");
        spriteBaguette = ob.GetComponent<SpriteRenderer>();
        baguetteCanAppear = true;
    }

    
    void Update()
    {
        if (baguetteCanAppear)
        {
            spriteBaguette.color = new Vector4(spriteBaguette.color.r, spriteBaguette.color.g, spriteBaguette.color.b, spriteBaguette.color.a + speed);
            if (spriteBaguette.color.a > 0.95)
            {
                baguetteCanAppear = false;
                StartCoroutine(BaguetteAppear());
            }
        }

        if (baguetteCanDisappear)
        {
            spriteBaguette.color = new Vector4(spriteBaguette.color.r, spriteBaguette.color.g, spriteBaguette.color.b, spriteBaguette.color.a - speed);
            if (spriteBaguette.color.a < 0.02)
            {
                baguetteCanDisappear = false;
            }
        }
    }

    IEnumerator BaguetteAppear()
    {
        yield return new WaitForSeconds(1.2f);
        GameObject ob = Instantiate(baguetteSmokeFx);
        Destroy(ob, 5.0f);
        baguetteCanDisappear = true;
    }
}
