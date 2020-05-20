using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class OngletArbo : MonoBehaviour
{
    [Range(0,4)] public int _id;

    public void ClickOnThisButton()
    {
        GetComponentInParent<OngletArboManager>().Actualise(_id);
    }
}
