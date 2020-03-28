using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// The <see cref="Item"/> class.
/// </summary>
public class Item : MonoBehaviour
{
    /// <summary>
    /// The Item:
    /// </summary>
    public ItemObject item;

    private SpriteRenderer spriteRenderer;

    public void Awake()
    {
        if(item)
        {
            spriteRenderer = GetComponent<SpriteRenderer>();

            if(spriteRenderer)
            {
                spriteRenderer.sprite = item.sprite;
            }
        }
    }
}
