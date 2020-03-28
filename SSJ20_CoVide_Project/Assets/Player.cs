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
    public InventoryObject Inventory;

    /// <summary>
    /// Called on trigger enter
    /// </summary>
    /// <param name="_other"></param>
    public void OnTriggerEnter2D(Collider2D _other)
    {
        var item = _other.GetComponent<Item>();
        if(item)
        {
            Inventory.AddItem(item.item, 1);
            Destroy(_other.gameObject);
        }
    }

    /// <summary>
    /// Called on application quit
    /// </summary>
    private void OnApplicationQuit()
    {
        Inventory.inventorySlots.Clear();
    }
}
