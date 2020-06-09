using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnElectric : MonoBehaviour
{

    void Awake()
    {
        Destroy(gameObject, 6.0f);
        FindObjectOfType<AudioManager>().Play("SFX_DeathEclair");
    }

}
