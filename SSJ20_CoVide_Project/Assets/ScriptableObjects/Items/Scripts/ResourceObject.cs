using UnityEngine;

/// <summary>
/// The <see cref="ResourceObject"/> class.
/// </summary>
[CreateAssetMenu(fileName = "New Default Item", menuName ="Inventory System/Items/Resource")]
public class ResourceObject : ItemObject
{
    /// <summary>
    /// Initiates the <see cref="ResourceObject"/> class.
    /// </summary>
    public void Awake()
    {
        type = ItemType.Resource;
    }
}
