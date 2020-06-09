using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBlood : MonoBehaviour
{
    public GameObject bloodFx;
    public GameObject bloodFx2;
    public GameObject obBlood;
    private SpriteRenderer spriteBlood;
    private bool bloodCanAppear;
    private bool bloodCanDisapear;
    [Range(0, 0.1f)] public float speed;

    
    void Awake()
    {
        GameObject ob = Instantiate(bloodFx);
        Destroy(ob, 4.0f);
        Vector3 pos1 = new Vector3(0.5f, 0);
        Vector3 pos2 = new Vector3(-1.3f, 0);
        GameObject ob2 = Instantiate(bloodFx2, pos1, Quaternion.identity);
        Destroy(ob2, 6.0f);
        GameObject ob3 = Instantiate(bloodFx2, pos2, Quaternion.identity);
        Destroy(ob3, 6.0f);
        GameObject ob4 = Instantiate(obBlood);
        Destroy(ob4, 6.0f);
        FindObjectOfType<AudioManager>().Play("SFX_DeathBlood");
        spriteBlood = ob4.GetComponent<SpriteRenderer>();
        bloodCanAppear = true;
    }

    
    void Update()
    {
        if (bloodCanAppear)
        {
            spriteBlood.color = new Vector4(spriteBlood.color.r, spriteBlood.color.g, spriteBlood.color.b, spriteBlood.color.a + speed);
            if (spriteBlood.color.a > 0.95)
            {
                bloodCanAppear = false;
                StartCoroutine(BloodAppear());
            }
        }

        if (bloodCanDisapear)
        {
            spriteBlood.color = new Vector4(spriteBlood.color.r, spriteBlood.color.g, spriteBlood.color.b, spriteBlood.color.a - speed);
            if (spriteBlood.color.a < 0.02)
            {
                bloodCanDisapear = false;
            }
        }
    }

    IEnumerator BloodAppear()
    {
        yield return new WaitForSeconds(4f);
        bloodCanDisapear = true;
    }
}
