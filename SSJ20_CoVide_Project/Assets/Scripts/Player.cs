using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// The <see cref="Player"/> class.
/// </summary>
public class Player : MonoBehaviour
{
    /// <summary>
    /// The Invenctory
    /// </summary>
    public InventoryObject inventory;
    public SpriteRenderer backpackRenderer;

    public Sprite backpackEmpty;
    public Sprite backpackMedium;
    public Sprite backpackFull;

    public void Awake()
    {
        SetBackpack();
    }

    /// <summary>
    /// Called on trigger enter
    /// </summary>
    /// <param name="_other"></param>
    public void OnTriggerEnter2D(Collider2D _other)
    {
        var item = _other.GetComponent<Item>();
        if(item == null || item.Owner == gameObject)
        {
            return;
        }

        if(item.Owner == null || item.Owner != gameObject)
        {
            FindObjectOfType<AudioManager>().Play("Pickup");

            SetBackpack();
            inventory.AddItem(item.item, 1);
            item.Owner = gameObject;
            Destroy(_other.gameObject);
            return;
        }    
    }

    private void SetBackpack()
    {
        int itemCount = GetInventoryItemCount();
        if(itemCount > 10)
        {            
            backpackRenderer.sprite = backpackFull;
            return;
        }

        if (itemCount > 5)
        {
            backpackRenderer.sprite = backpackMedium;
            return;
        }

        backpackRenderer.sprite = backpackEmpty;
    }

    private int GetInventoryItemCount()
    {
        int itemCount = 0;
        foreach (var item in inventory.inventorySlots)
        {
            itemCount += item.amount;
        }

        return itemCount;
    }
}
