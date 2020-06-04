using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnParticle : MonoBehaviour
{
    [Header ("Confetti")]
    public GameObject confettiFx;

    [Header("Blood")]
    public GameObject bloodFx;
    public GameObject bloodImage;
    private bool bloodCanDisapear;
    [Range(0, 0.1f)] public float speed;
    private Image im;

    [Header("Sugar")]
    public GameObject sugarFx;

    [Header("Electric")]
    public GameObject electricFx;

    [Header("Popcorn")]
    public GameObject popcornFx;

    public void ClickConfetti()
    {
        GameObject ob = Instantiate(confettiFx);
        Destroy(ob, 6.0f);
    }
    public void ClickSugar()
    {
        GameObject ob = Instantiate(sugarFx);
        Destroy(ob, 5.0f);
    }

    public void ClickPopcorn()
    {
        GameObject ob = Instantiate(popcornFx);
        Destroy(ob, 5.0f);
    }

    public void ClickElectric()
    {
        GameObject ob = Instantiate(electricFx);
        Destroy(ob, 4.0f);
    }

    public void ClickBlood()
    {
        GameObject ob = Instantiate(bloodFx);
        Destroy(ob, 4.0f);
        bloodImage.SetActive(true);
        im = bloodImage.GetComponentInChildren<Image>();
        StartCoroutine(BloodDisapear());

    }

    private void Update()
    {
        if (bloodCanDisapear)
        {
            im.color = new Vector4(im.color.r, im.color.g, im.color.b, im.color.a - speed);
            if (im.color.a < 0.05)
            {
                im.color = new Vector4(im.color.r, im.color.g, im.color.b, 1);
                bloodImage.SetActive(false);
                bloodCanDisapear = false;
            }
        }
    }

    IEnumerator BloodDisapear()
    {
        yield return new WaitForSeconds(1);
        bloodCanDisapear = true;
    }


}
