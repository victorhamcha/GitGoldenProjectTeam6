using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnVomi : MonoBehaviour
{
    public GameObject vomiFx;

    void Awake()
    {
        GameObject ob = Instantiate(vomiFx);
        Destroy(ob, 4.0f);
        FindObjectOfType<AudioManager>().Play("SFX_DeathVomit");
    }
}
