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
        if(item)
        {            
            inventory.AddItem(item.item, 1);
            Destroy(_other.gameObject);
        }
    }

    /// <summary>
    /// Called on application quit
    /// </summary>
    private void OnApplicationQuit()
    {
        inventory.inventorySlots.Clear();
    }
}
