using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnKnife : MonoBehaviour
{
    public GameObject obKnife;
    public GameObject bloodFx;

    void Awake()
    {
        GameObject ob = Instantiate(obKnife);
        Destroy(ob, 8);
        FindObjectOfType<AudioManager>().Play("SFX_DeathCouteau");
        StartCoroutine(KnifeAppear());
    }

    IEnumerator KnifeAppear()
    {
        yield return new WaitForSeconds(1.5f);
        GameObject ob = Instantiate(bloodFx);
        Destroy(ob, 5.0f);
    }
}
