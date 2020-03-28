using System.Collections.Generic;
using System.Linq;
using UnityEngine;

/// <summary>
/// The <see cref="InventoryObject"/> class.
/// </summary>
[CreateAssetMenu(fileName = "New Inventory", menuName = "Inventory System/Inventory")]
public class InventoryObject : ScriptableObject
{
    public bool clearListOnExitApplication;

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
            var inventorySlot = inventorySlots.FirstOrDefault(x => x.item == _item);
            if(inventorySlot != null)
            {
                inventorySlot.AddAmount(_amount);
            }

            return;
        }

        inventorySlots.Add(new InventorySlot(_item, _amount));
    }

    /// <summary>
    /// Rotates the items
    /// </summary>
    public void RotateItem()
    {
        if(inventorySlots.Count < 1)
        {
            return;
        }

        var tempSlot = inventorySlots.First();
        inventorySlots.RemoveAt(0);
        inventorySlots.Add(tempSlot);
        Debug.Log($"Selected Item is: {inventorySlots.First().item.name}");
    }

    /// <summary>
    /// Called on application quit
    /// </summary>
    private void OnApplicationQuit()
    {
        if(clearListOnExitApplication)
        {
            inventorySlots.Clear();
        }
    }
}
