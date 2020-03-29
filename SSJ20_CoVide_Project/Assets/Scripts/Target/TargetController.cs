using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetController : MonoBehaviour
{
    public ResourcesContainerObject resourcesContainer;
    public SpriteRenderer itemRenderer;

    private List<TargetArea> targetAreas;
    private ItemObject requestedResource;

    // Start is called before the first frame update
    void Awake()
    {
        System.Random r = new System.Random();
        requestedResource = resourcesContainer.resourceContainer[r.Next(resourcesContainer.resourceContainer.Count)];

        targetAreas = transform.GetComponentsInChildren<TargetArea>().ToList();
    }    

    /// <summary>
    /// Sets the requested resource
    /// </summary>
    private void SetResource()
    {
        targetAreas.ForEach(x => x.requestResource = requestedResource);
    }

    /// <summary>
    /// Sets the item renderer and allocates sprite
    /// </summary>
    private void SetItemRenderer()
    {
        targetAreas.ForEach(x => x.itemRenderer = itemRenderer);
        var collectablePrefab = requestedResource.collectablePrefab;
        var prefabRenderer = collectablePrefab.GetComponent<SpriteRenderer>();
        itemRenderer.sprite = prefabRenderer.sprite;

    }

    /// <summary>
    /// Enables the score for all target areas
    /// </summary>
    /// <param name="isEnable"></param>
    public void EnableScoreing(bool isEnable)
    {
        targetAreas.ForEach(x => x.scoreIsEnabled = isEnable);
    }
}
