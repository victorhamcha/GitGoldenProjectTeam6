using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPopCorn : MonoBehaviour
{

    void Awake()
    {
        Destroy(gameObject, 7.0f);
        FindObjectOfType<AudioManager>().Play("SFX_DeathPopCorn");
    }
}
