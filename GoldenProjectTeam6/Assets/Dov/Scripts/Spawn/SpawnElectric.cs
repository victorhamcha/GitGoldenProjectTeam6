using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnElectric : MonoBehaviour
{
    public GameObject electricFx;

    void Awake()
    {
        GameObject ob = Instantiate(electricFx);
        Destroy(ob, 6.0f);
        FindObjectOfType<AudioManager>().Play("SFX_DeathEclair");
    }

}
