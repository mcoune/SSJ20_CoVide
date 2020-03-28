using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// The <see cref="InventoryDisplay"/> class.
/// </summary>
public class InventoryDisplay : MonoBehaviour
{
    public InventoryObject inventory;
    public Sprite defaultSprite;

    public Image selectedItem;
    public Image nextItem;
    public Image nextNextItem;
    public Text amountText;

    void Start()
    {
        selectedItem.sprite = defaultSprite;
        nextItem.sprite = defaultSprite;
        nextNextItem.sprite = defaultSprite;
        amountText.text = "0";

    }
    // Update is called once per frame
    void Update()
    {
        if(inventory.inventorySlots.Count < 1)
        {
            
            
            return;
        }

        SetImage(0, selectedItem);
        SetAmount(0);
        SetImage(1, nextItem);
        SetImage(2, nextNextItem);
    }

    /// <summary>
    /// Sets the sprite of the specific image
    /// </summary>
    /// <param name="_index"></param>
    /// <param name="_image"></param>
    private void SetImage(int _index, Image _image)
    {
        if (inventory.inventorySlots.Count >= _index + 1)
        {
            _image.sprite = inventory.inventorySlots[_index].item.sprite;
            return;
        }

        _image.sprite = defaultSprite;        
    }

    /// <summary>
    /// Sets the amount text in the selectable image
    /// </summary>
    /// <param name="_amount"></param>
    private void SetAmount(int _index)
    {
        if (inventory.inventorySlots.Count >= _index + 1)
        {
            amountText.text = inventory.inventorySlots[_index].amount.ToString();
        }
    }
}
