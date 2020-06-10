using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnClaw : MonoBehaviour
{
    private SpriteRenderer spriteClaw;
    public GameObject bloodFx;
    private bool clawCanAppear;
    private bool clawCanDisappear;
    [Range(0, 0.1f)] public float speed;


    void Awake()
    {
        Destroy(gameObject, 6);
        spriteClaw = gameObject.GetComponent<SpriteRenderer>();
        clawCanAppear = true;
    }

    
    void Update()
    {
        if (clawCanAppear)
        {
            spriteClaw.color = new Vector4(spriteClaw.color.r, spriteClaw.color.g, spriteClaw.color.b, spriteClaw.color.a + speed);
            if (spriteClaw.color.a > 0.95)
            {
                clawCanAppear = false;
                StartCoroutine(ClawAppear());
            }
        }

        if (clawCanDisappear)
        {
            spriteClaw.color = new Vector4(spriteClaw.color.r, spriteClaw.color.g, spriteClaw.color.b, spriteClaw.color.a - speed);
            if (spriteClaw.color.a < 0.02)
            {
                clawCanDisappear = false;
            }
        }
    }

    IEnumerator ClawAppear()
    {
        GameObject ob = Instantiate(bloodFx);
        Destroy(ob, 4.0f);
        yield return new WaitForSeconds(1.5f);
        clawCanDisappear = true;
    }
}
