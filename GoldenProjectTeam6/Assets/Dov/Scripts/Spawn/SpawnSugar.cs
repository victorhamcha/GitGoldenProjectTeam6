using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnSugar : MonoBehaviour
{
    

    void Awake()
    {
        Destroy(gameObject, 6.0f);
    }

}
