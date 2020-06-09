using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnFootPrint : MonoBehaviour
{
    public SpriteRenderer footPrint;
    public GameObject SmokeFx;

    
    void Awake()
    {
        FindObjectOfType<AudioManager>().Play("SFX_DeathFoulePasContente");
        StartCoroutine(FootPrintAppear());
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
}
