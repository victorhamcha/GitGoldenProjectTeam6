using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPopCorn : MonoBehaviour
{
    public GameObject popcornFx;

    void Awake()
    {
        GameObject ob = Instantiate(popcornFx);
        Destroy(ob, 7.0f);
        FindObjectOfType<AudioManager>().Play("SFX_DeathPopCorn");
    }
}
