using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetArea : MonoBehaviour
{
    public ResourcesContainerObject resourcesContainer;
    public int ScoreMultiplier;
    private ItemObject requestResource;

    public void Awake()
    {
        System.Random r = new System.Random();
        requestResource = resourcesContainer.resourceContainer[r.Next(resourcesContainer.resourceContainer.Count)];
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag != "Projectile")
        {
            return;
        }

        var throwable = other.GetComponent<Throwable>();
        if (throwable == null || throwable.owner == null)
        {
            return;
        }

        var scoreController = throwable.owner.GetComponent<ScoreController>();
        if (scoreController == null)
        {
            return;
        }

        if (throwable.item == requestResource)
        {
            scoreController.AddDelivery(1);
            scoreController.AddScore(requestResource.points + ScoreMultiplier);
        }
        else
        {
            scoreController.AddScore(-requestResource.penaltiy);
        }


        Destroy(other.gameObject);
    }
}