using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnParticle : MonoBehaviour
{

    [Header("Confetti")]
    public GameObject confettiFx;

    [Header("Blood")]
    public GameObject bloodFx;
    public GameObject bloodFx2;
    public GameObject obBlood;
    private SpriteRenderer spriteBlood;
    private bool bloodCanAppear;
    private bool bloodCanDisapear;
    [Range(0, 0.1f)] public float speed;

    [Header("Sugar")]
    public GameObject sugarFx;

    [Header("Electric")]
    public GameObject electricFx;

    [Header("Popcorn")]
    public GameObject popcornFx;

    [Header("Vomi")]
    public GameObject vomiFx;

    [Header("Fire")]
    public GameObject fireFx;

    [Header("Knife")]
    public GameObject obKnife;

    [Header("FootPrint")]
    public SpriteRenderer footPrint;
    public GameObject SmokeFx;

    [Header("Canon Smoke")]
    public GameObject canonSmokeFx;

    [Header("Claw")]
    public GameObject obClaw;
    private SpriteRenderer spriteClaw;
    private bool clawCanAppear;
    private bool clawCanDisappear;

    [Header("Bite")]
    public GameObject obBite;
    private SpriteRenderer spriteBite;
    private bool biteCanAppear;
    private bool biteCanDisappear;

    [Header("Elephant Tusk")]
    public GameObject obTusk;
    private SpriteRenderer spriteTusk;
    private bool tuskCanDisappear;

    [Header("Magician Baguette")]
    public GameObject obBaguette;
    public GameObject baguetteSmokeFx;
    private SpriteRenderer spriteBaguette;
    private bool baguetteCanAppear;
    private bool baguetteCanDisappear;

    public void ClickConfetti()
    {
        GameObject ob = Instantiate(confettiFx);
        Destroy(ob, 6.0f);
        FindObjectOfType<AudioManager>().Play("SFX_DeathConfetti");
    }

    public void ClickSugar()
    {
        GameObject ob = Instantiate(sugarFx);
        Destroy(ob, 6.0f);
    }

    public void ClickFire()
    {
        GameObject ob = Instantiate(fireFx);
        Destroy(ob, 6.0f);
        FindObjectOfType<AudioManager>().Play("SFX_DeathFire");
    }

    public void ClickFootPrint()
    {
        FindObjectOfType<AudioManager>().Play("SFX_DeathFoulePasContente");
        StartCoroutine(FootPrintAppear());
    }

    public void ClickKnife()
    {
        GameObject ob = Instantiate(obKnife);
        Destroy(ob, 8);
        FindObjectOfType<AudioManager>().Play("SFX_DeathCouteau");
        StartCoroutine(KnifeAppear());
    }

    public void ClickTusk()
    {
        GameObject ob = Instantiate(obTusk);
        Destroy(ob, 6);
        spriteTusk = ob.GetComponent<SpriteRenderer>();
        StartCoroutine(TuskAppear());
    }

    public void ClickBaguette()
    {
        GameObject ob = Instantiate(obBaguette);
        Destroy(ob, 6);
        FindObjectOfType<AudioManager>().Play("SFX_DeathBaguette");
        spriteBaguette = ob.GetComponent<SpriteRenderer>();
        baguetteCanAppear = true;
    }

    public void ClickPopcorn()
    {
        GameObject ob = Instantiate(popcornFx);
        Destroy(ob, 7.0f);
        FindObjectOfType<AudioManager>().Play("SFX_DeathPopCorn");
    }

    public void ClickVomi()
    {
        GameObject ob = Instantiate(vomiFx);
        Destroy(ob, 4.0f);
        FindObjectOfType<AudioManager>().Play("SFX_DeathVomit");
    }

    public void ClickCanonSmoke()
    {
        GameObject ob = Instantiate(canonSmokeFx);
        Destroy(ob, 6.0f);
    }

    public void ClickElectric()
    {
        GameObject ob = Instantiate(electricFx);
        Destroy(ob, 4.0f);
        FindObjectOfType<AudioManager>().Play("SFX_DeathEclair");
    }

    public void ClickClaw()
    {
        GameObject ob2 = Instantiate(obClaw);
        Destroy(ob2, 6);
        spriteClaw = ob2.GetComponent<SpriteRenderer>();
        clawCanAppear = true;
    }

    public void ClickBite()
    {
        GameObject ob2 = Instantiate(obBite);
        Destroy(ob2, 6);
        spriteBite = ob2.GetComponent<SpriteRenderer>();
        biteCanAppear = true;
    }

    public void ClickBlood()
    {
        GameObject ob = Instantiate(bloodFx);
        Destroy(ob, 4.0f);
        Vector3 pos1 = new Vector3(0.5f, 0);
        Vector3 pos2 = new Vector3(-1.3f, 0);
        GameObject ob2 = Instantiate(bloodFx2, pos1, Quaternion.identity);
        Destroy(ob2, 6.0f);
        GameObject ob3 = Instantiate(bloodFx2, pos2, Quaternion.identity);
        Destroy(ob3, 6.0f);
        GameObject ob4 = Instantiate(obBlood);
        Destroy(ob4, 6.0f);
        FindObjectOfType<AudioManager>().Play("SFX_DeathBlood");
        spriteBlood = ob4.GetComponent<SpriteRenderer>();
        bloodCanAppear = true;
    }

    public void ClickRire()
    {
        FindObjectOfType<AudioManager>().Play("SFX_DeathMourirDeRire");
    }

    private void Update()
    {
        if (bloodCanAppear)
        {
            spriteBlood.color = new Vector4(spriteBlood.color.r, spriteBlood.color.g, spriteBlood.color.b, spriteBlood.color.a + speed);
            if (spriteBlood.color.a > 0.95)
            {
                bloodCanAppear = false;
                StartCoroutine(BloodAppear());
            }
        }

        if (bloodCanDisapear)
        {
            spriteBlood.color = new Vector4(spriteBlood.color.r, spriteBlood.color.g, spriteBlood.color.b, spriteBlood.color.a - speed);
            if (spriteBlood.color.a < 0.02)
            {
                bloodCanDisapear = false;
            }
        }

        if (clawCanAppear)
        {
            spriteClaw.color = new Vector4(spriteClaw.color.r, spriteClaw.color.g, spriteClaw.color.b, spriteClaw.color.a + speed);
            if (spriteClaw.color.a > 0.95)
            {
                clawCanAppear = false;
                StartCoroutine(ClawAppear());
            }
        }

        if (clawCanDisappear)
        {
            spriteClaw.color = new Vector4(spriteClaw.color.r, spriteClaw.color.g, spriteClaw.color.b, spriteClaw.color.a - speed);
            if (spriteClaw.color.a < 0.02)
            {
                clawCanDisappear = false;
            }
        }

        if (biteCanAppear)
        {
            spriteBite.color = new Vector4(spriteBite.color.r, spriteBite.color.g, spriteBite.color.b, spriteBite.color.a + speed);
            if (spriteBite.color.a > 0.95)
            {
                biteCanAppear = false;
                StartCoroutine(BiteAppear());
            }
        }

        if (biteCanDisappear)
        {
            spriteBite.color = new Vector4(spriteBite.color.r, spriteBite.color.g, spriteBite.color.b, spriteBite.color.a - speed);
            if (spriteBite.color.a < 0.02)
            {
                biteCanDisappear = false;
            }
        }

        if (baguetteCanAppear)
        {
            spriteBaguette.color = new Vector4(spriteBaguette.color.r, spriteBaguette.color.g, spriteBaguette.color.b, spriteBaguette.color.a + speed);
            if (spriteBaguette.color.a > 0.95)
            {
                baguetteCanAppear = false;
                StartCoroutine(BaguetteAppear());
            }
        }

        if (baguetteCanDisappear)
        {
            spriteBaguette.color = new Vector4(spriteBaguette.color.r, spriteBaguette.color.g, spriteBaguette.color.b, spriteBaguette.color.a - speed);
            if (spriteBaguette.color.a < 0.02)
            {
                baguetteCanDisappear = false;
            }
        }

        if (tuskCanDisappear)
        {
            spriteTusk.color = new Vector4(spriteTusk.color.r, spriteTusk.color.g, spriteTusk.color.b, spriteTusk.color.a - speed);
            if (spriteTusk.color.a < 0.02)
            {
                tuskCanDisappear = false;
            }
        }
    }

    IEnumerator BloodAppear()
    {
        yield return new WaitForSeconds(4f);
        bloodCanDisapear = true;
    }

    IEnumerator KnifeAppear()
    {
        yield return new WaitForSeconds(1.5f);
        GameObject ob = Instantiate(bloodFx);
        Destroy(ob, 5.0f);
    }

    IEnumerator TuskAppear()
    {
        yield return new WaitForSeconds(1.2f);
        GameObject ob = Instantiate(bloodFx);
        Destroy(ob, 5.0f);
        tuskCanDisappear = true;
    }

    IEnumerator BaguetteAppear()
    {
        yield return new WaitForSeconds(1.2f);
        GameObject ob = Instantiate(baguetteSmokeFx);
        Destroy(ob, 5.0f);
        baguetteCanDisappear = true;
    }

    IEnumerator FootPrintAppear()
    {
        float time = 0;
        for (int i = 0; i < 20; i++)
        {
            Quaternion footPrintRotation = new Quaternion(Random.Range(-1.7f, 1.7f), Random.Range(-2f, 2f), 0, 0);
            Vector3 footPrintPosition = new Vector3(Random.Range(-2f, 2f), Random.Range(-4f, 3f), 0);
            SpriteRenderer foot = Instantiate(footPrint, footPrintPosition, footPrintRotation);
            Vector3 obPosition = new Vector3(foot.transform.position.x, foot.transform.position.y, -0.1f);
            GameObject ob = Instantiate(SmokeFx, obPosition, footPrintRotation);
            Destroy(ob, 3);
            Destroy(foot, 5.0f - time);
            yield return new WaitForSeconds(0.1f);
            time += 0.106f;
        }
    }

    IEnumerator ClawAppear()
    {
        GameObject ob = Instantiate(bloodFx);
        Destroy(ob, 4.0f);
        yield return new WaitForSeconds(1.5f);
        clawCanDisappear = true;
    }

    IEnumerator BiteAppear()
    {
        GameObject ob = Instantiate(bloodFx);
        Destroy(ob, 4.0f);
        yield return new WaitForSeconds(1.5f);
        biteCanDisappear = true;
    }

}
