using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnParticle : MonoBehaviour
{
    public Animator animator;
    public Animator animator2;

    [Header("Confetti")]
    public GameObject confettiFx;

    [Header("Blood")]
    public GameObject bloodFx;
    public GameObject bloodFx2;
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

    [Header("Vomi")]
    public GameObject vomiFx;

    [Header("Knife")]
    public SpriteRenderer knife;

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
    public SpriteRenderer tusk;

    public void ClickConfetti()
    {
        GameObject ob = Instantiate(confettiFx);
        Destroy(ob, 6.0f);
    }

    public void ClickSugar()
    {
        GameObject ob = Instantiate(sugarFx);
        Destroy(ob, 6.0f);
    }

    public void ClickFootPrint()
    {
        StartCoroutine(FootPrintAppear());
    }

    public void ClickKnife()
    {
        knife.enabled = true;
        animator.SetBool("DeathKnife", true);
        StartCoroutine(KnifeAppear());
        StartCoroutine(KnifeDisappear());
    }

    public void ClickTusk()
    {
        tusk.enabled = true;
        animator2.SetBool("Elephant", true);
        StartCoroutine(TuskAppear());
        StartCoroutine(TuskDisappear());
    }

    public void ClickPopcorn()
    {
        GameObject ob = Instantiate(popcornFx);
        Destroy(ob, 7.0f);
    }

    public void ClickVomi()
    {
        GameObject ob = Instantiate(vomiFx);
        Destroy(ob, 4.0f);
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
    }

    public void ClickClaw()
    {
        spriteClaw = obClaw.GetComponent<SpriteRenderer>();
        obClaw.SetActive(true);
        clawCanAppear = true;
    }

    public void ClickBite()
    {
        spriteBite = obBite.GetComponent<SpriteRenderer>();
        obBite.SetActive(true);
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
            if (spriteClaw.color.a < 0.05)
            {
                clawCanDisappear = false;
                StartCoroutine(ClawDisappear());
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
            if (spriteBite.color.a < 0.05)
            {
                biteCanDisappear = false;
                StartCoroutine(BiteDisappear());
            }
        }
    }

    IEnumerator BloodDisapear()
    {
        yield return new WaitForSeconds(5);
        bloodCanDisapear = true;
    }

    IEnumerator KnifeDisappear()
    {
        yield return new WaitForSeconds(3);
        animator.SetBool("DeathKnife", false);
        knife.enabled = false;
    }

    IEnumerator KnifeAppear()
    {
        yield return new WaitForSeconds(1.5f);
        GameObject ob = Instantiate(bloodFx);
        Destroy(ob, 5.0f);
    }

    IEnumerator TuskAppear()
    {
        yield return new WaitForSeconds(1.0f);
        GameObject ob = Instantiate(bloodFx);
        Destroy(ob, 5.0f);
    }

    IEnumerator TuskDisappear()
    {
        yield return new WaitForSeconds(3);
        animator2.SetBool("Elephant", false);
        tusk.enabled = false;
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

    IEnumerator ClawDisappear()
    {
        yield return new WaitForSeconds(2.5f);
        obClaw.SetActive(false);
    }

    IEnumerator BiteAppear()
    {
        GameObject ob = Instantiate(bloodFx);
        Destroy(ob, 4.0f);
        yield return new WaitForSeconds(1.5f);
        biteCanDisappear = true;
    }

    IEnumerator BiteDisappear()
    {
        yield return new WaitForSeconds(2.5f);
        obBite.SetActive(false);
    }
}
