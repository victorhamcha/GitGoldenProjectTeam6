using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContainAllObjectTree : MonoBehaviour
{
    public List<GameObject> _imageTreeChilds;
    public List<bool> _imageTreeChildAlreadyInTree;

    void Start()
    {
        foreach (Transform child in transform)
        {
            _imageTreeChilds.Add(child.gameObject);
        }
        foreach (Transform child in transform)
        {
            _imageTreeChildAlreadyInTree.Add(child.gameObject.GetComponent<ImageArborescence>()._alreadyInTree);
        }

    }
}
