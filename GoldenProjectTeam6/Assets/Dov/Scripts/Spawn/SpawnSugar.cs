using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnSugar : MonoBehaviour
{
    public GameObject sugarFx;

    void Awake()
    {
        GameObject ob = Instantiate(sugarFx);
        Destroy(ob, 6.0f);
    }

}
