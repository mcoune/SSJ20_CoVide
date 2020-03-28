using System.Collections.Generic;
using System.Linq;
using UnityEngine;

/// <summary>
/// The <see cref="InventoryObject"/> class.
/// </summary>
[CreateAssetMenu(fileName = "New Inventory", menuName = "Inventory System/Inventory")]
public class InventoryObject : ScriptableObject
{
    /// <summary>
    /// List of all inventory slots
    /// </summary>
    public List<InventorySlot> inventorySlots = new List<InventorySlot>();

    /// <summary>
    /// Adds item to the inventory
    /// </summary>
    /// <param name="item">Item to add</param>
    /// <param name="amount">Amount of items to add</param>
    public void AddItem(ItemObject _item, int _amount)
    {
        if (inventorySlots.Any(x => x.item == _item))
        {
            inventorySlots.FirstOrDefault(x => x.item == _item).AddAmount(_amount);
            return;
        }

        inventorySlots.Add(new InventorySlot(_item, _amount));
    }

    public void RemoveItem(ItemObject _item, int _amount)
    {

    }
}
