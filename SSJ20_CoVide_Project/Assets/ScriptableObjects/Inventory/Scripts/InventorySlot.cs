/// <summary>
/// The <see cref="InventorySlot"/> class.
/// </summary>
[System.Serializable]
public class InventorySlot
{
    /// <summary>
    /// The Item
    /// </summary>
    public ItemObject item;

    /// <summary>
    /// the amount of items
    /// </summary>
    public int amount;

    /// <summary>
    /// Initiates the <see cref="InventorySlot"/> class.
    /// </summary>
    public InventorySlot(ItemObject _item, int _amount)
    {
        item = _item;
        amount = _amount;
    }

    /// <summary>
    /// Adds more items to this item slot
    /// </summary>
    /// <param name="_value">amount of items to add</param>
    public void AddAmount(int _value)
    {
        amount += _value;
    }
}
