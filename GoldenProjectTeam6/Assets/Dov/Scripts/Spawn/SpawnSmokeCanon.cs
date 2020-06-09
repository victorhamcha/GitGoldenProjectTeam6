using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnSmokeCanon : MonoBehaviour
{
    public GameObject canonSmokeFx;

    void Awake()
    {
        GameObject ob = Instantiate(canonSmokeFx);
        Destroy(ob, 6.0f);
    }
}
