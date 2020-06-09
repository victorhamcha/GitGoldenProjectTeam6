using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnFire : MonoBehaviour
{
    public GameObject fireFx;

    void Awake()
    {
        GameObject ob = Instantiate(fireFx);
        Destroy(ob, 6.0f);
        FindObjectOfType<AudioManager>().Play("SFX_DeathFire");
    }

    
}
