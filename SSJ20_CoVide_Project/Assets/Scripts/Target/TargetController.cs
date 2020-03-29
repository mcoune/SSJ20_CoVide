using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetController : MonoBehaviour
{
    public ResourcesContainerObject resourcesContainer;

    // Start is called before the first frame update
    void Awake()
    {
        System.Random r = new System.Random();
        var requestResource = resourcesContainer.resourceContainer[r.Next(resourcesContainer.resourceContainer.Count)];

        var childs = transform.GetComponentsInChildren<TargetArea>().ToList();
        childs.ForEach(x => x.requestResource = requestResource);
    }
}
