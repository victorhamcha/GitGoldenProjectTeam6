using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnConfetti : MonoBehaviour
{
    public GameObject confettiFx;

    void Awake()
    {
        GameObject ob = Instantiate(confettiFx);
        Destroy(ob, 6.0f);
        FindObjectOfType<AudioManager>().Play("SFX_DeathConfetti");
    }

}
