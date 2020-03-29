using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetArea : MonoBehaviour
{    
    public int ScoreMultiplier;

    [HideInInspector]
    public ItemObject requestResource;
    public SpriteRenderer itemRenderer;

    private bool resourceDelivered = false;

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

        if(!resourceDelivered)
        {
            if (throwable.item == requestResource)
            {
                scoreController.AddDelivery(1);
                scoreController.AddScore(requestResource.points + ScoreMultiplier);
            }
            else
            {
                scoreController.AddScore(-requestResource.penalty);
            }
        }

        itemRenderer.enabled = false;
        resourceDelivered = true;
        Destroy(other.gameObject);
    }
}