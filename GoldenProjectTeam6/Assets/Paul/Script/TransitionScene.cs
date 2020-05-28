using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransitionScene : MonoBehaviour
{
    public Animator _animator;
    [Range(0, 1)] public float _animTime;
    void Start()
    {
        StartAnim();
    }

    public void StartAnim()
    {
        Debug.Log("I start");
        _animator.gameObject.SetActive(true);
        _animator.enabled = true;
        _animator.SetBool("IStartAnim", true);
        StartCoroutine(WaitForMask());
    }

    IEnumerator WaitForMask()
    {
        yield return new WaitForSeconds(_animTime);
        _animator.gameObject.SetActive(false);
    }

    public void EndAnim()
    {
        Debug.Log("I end");

        _animator.gameObject.SetActive(true);
        _animator.SetBool("IStartAnim", false);
    }
}
