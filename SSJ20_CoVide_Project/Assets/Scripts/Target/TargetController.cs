using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetController : MonoBehaviour
{
    public ResourcesContainerObject resourcesContainer;
    public SpriteRenderer itemRenderer;

    // Start is called before the first frame update
    void Awake()
    {
        System.Random r = new System.Random();
        var requestResource = resourcesContainer.resourceContainer[r.Next(resourcesContainer.resourceContainer.Count)];

        var childs = transform.GetComponentsInChildren<TargetArea>().ToList();
        childs.ForEach(x =>
        {
            x.requestResource = requestResource;
            x.itemRenderer = itemRenderer;
        });

        var collectablePrefab = requestResource.collectablePrefab;
        var prefabRenderer = collectablePrefab.GetComponent<SpriteRenderer>();
        itemRenderer.sprite = prefabRenderer.sprite;
    }
}
