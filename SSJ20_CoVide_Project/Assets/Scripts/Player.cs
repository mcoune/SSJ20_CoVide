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

            inventory.AddItem(item.item, 1);
            item.Owner = gameObject;
            Destroy(_other.gameObject);
            return;
        }    
    }
}
