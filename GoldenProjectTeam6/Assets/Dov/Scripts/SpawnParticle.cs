using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnParticle : MonoBehaviour
{
    public GameObject confettiFx;

    public GameObject bloodFx;
    public GameObject bloodImage;

    
    public void ClickConfetti()
    {
        GameObject ob = Instantiate(confettiFx);
        Destroy(ob, 6.0f);
    }

    public void ClickBlood()
    {
        GameObject ob = Instantiate(bloodFx);
        Destroy(ob, 4.0f);
        bloodImage.SetActive(true);
    }
}
