using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnElephantTusk : MonoBehaviour
{
    private SpriteRenderer spriteTusk;
    private bool tuskCanDisappear;
    public GameObject bloodFx;
    [Range(0, 0.1f)] public float speed;

    
    void Awake()
    {
        Destroy(gameObject, 6);
        spriteTusk = gameObject.GetComponent<SpriteRenderer>();
        StartCoroutine(TuskAppear());
    }

    
    void Update()
    {
        if (tuskCanDisappear)
        {
            spriteTusk.color = new Vector4(spriteTusk.color.r, spriteTusk.color.g, spriteTusk.color.b, spriteTusk.color.a - speed);
            if (spriteTusk.color.a < 0.02)
            {
                tuskCanDisappear = false;
            }
        }
    }

    IEnumerator TuskAppear()
    {
        yield return new WaitForSeconds(1.2f);
        GameObject ob = Instantiate(bloodFx);
        Destroy(ob, 5.0f);
        tuskCanDisappear = true;
    }
}
