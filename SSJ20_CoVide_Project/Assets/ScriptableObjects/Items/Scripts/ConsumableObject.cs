using UnityEngine;

/// <summary>
/// The <see cref="ConsumableObject"/> class.
/// </summary>
[CreateAssetMenu(fileName = "New Consumable Item", menuName = "Inventory System/Items/Consumable")]
public class ConsumableObject : ItemObject
{
    /// <summary>
    /// Initiates the <see cref="ConsumableObject"/> class.
    /// </summary>
    public void Awake()
    {
        type = ItemType.Consumable;
    }
}
