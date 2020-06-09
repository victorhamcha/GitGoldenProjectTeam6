using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnVomi : MonoBehaviour
{
    void Awake()
    {
        Destroy(gameObject, 4.0f);
        FindObjectOfType<AudioManager>().Play("SFX_DeathVomit");
    }
}
