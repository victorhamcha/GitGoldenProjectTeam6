using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContainAllObjectTree : MonoBehaviour
{
    [HideInInspector] public List<GameObject> _imageTreeChilds;
    //Save the following variable (_imageTreeChildAlreadyInTree)
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

        for (int i = 0; i < _imageTreeChilds.Count; i++)
        {
            _imageTreeChilds[i].GetComponent<ImageArborescence>()._idInParent = i;
        }

    }
}
