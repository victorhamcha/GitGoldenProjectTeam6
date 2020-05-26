//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using TMPro;

//public class TextControl : MonoBehaviour
//{
//    private TextMeshPro _textMeshPro;

//    private void Start()
//    {
//        StartCoroutine(TextReveal());
//    }


//    IEnumerator TextReveal()
//    {
//        _textMeshPro = gameObject.GetComponent<TextMeshPro>();

//        int totalVisibleCharacters = _textMeshPro.textInfo.characterCount;
//        int counter = 0;

//        while (true)
//        {
//            int visibleCount = counter % (totalVisibleCharacters + 1);
//            _textMeshPro.maxVisibleCharacters = visibleCount;

//            if (visibleCount >= totalVisibleCharacters)
//            {
//                yield return new WaitForSeconds(1.0f);
//            }

//            counter += 1;

//            yield return new WaitForSeconds(0.05f);
//        }
//    }

//}
