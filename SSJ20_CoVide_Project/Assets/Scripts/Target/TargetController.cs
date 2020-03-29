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
    private bool isEnabled;

    // Start is called before the first frame update
    void Awake()
    {
        System.Random r = new System.Random();
        requestedResource = resourcesContainer.resourceContainer[r.Next(resourcesContainer.resourceContainer.Count)];

        targetAreas = transform.GetComponentsInChildren<TargetArea>().ToList();
        SetResource();
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
    public void EnableScoreing(bool _isEnable)
    {
        isEnabled = _isEnable;
        targetAreas.ForEach(x => x.scoreIsEnabled = _isEnable);
        if(_isEnable)
        {
            SetItemRenderer();
        }
    }

    public void OnDestroy()
    {
        if (isEnabled)
        {
            Debug.Log("OnDestroy");
            var scoreControllers = FindObjectsOfType<ScoreController>();
            if (scoreControllers == null)
            {
                return;
            }

            var sc = scoreControllers.FirstOrDefault(x => x.gameObject.tag == "MainCamera");
            if (sc == null)
            {
                return;
            }

            Debug.Log("Found Main Camera");
            if (targetAreas.Any(x => !x.resourceDelivered))
            {
                Debug.Log("Strike");
                sc.AddStrike(1);
            }
        }
    }
}
