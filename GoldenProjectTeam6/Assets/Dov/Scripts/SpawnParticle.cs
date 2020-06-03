using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnParticle : MonoBehaviour
{
    public GameObject confettiFx;

    public void ClickConfetti()
    {
        GameObject ob = Instantiate(confettiFx);
    }
}
