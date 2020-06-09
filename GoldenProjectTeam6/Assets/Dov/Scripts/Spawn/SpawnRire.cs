using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnRire : MonoBehaviour
{
    
    void Awake()
    {
        FindObjectOfType<AudioManager>().Play("SFX_DeathMourirDeRire");
    }

    
}
