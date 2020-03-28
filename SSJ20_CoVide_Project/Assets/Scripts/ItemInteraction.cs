using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemInteraction : MonoBehaviour
{
    public KeyCode rotateItems;
    public KeyCode interacteWithItem;
    public Transform throwPoint;

    public float maxLoadTime = 3f;
    /// <summary>
    /// The Invenctory
    /// </summary>
    public InventoryObject inventory;

    private float holdDownStartTime;
    private bool interactionStarted = false;
    private GameObject loadedGameObject;

    public void Awake()
    {
        var player = GetComponent<Player>();
        if(player != null)
        {
            inventory = player.inventory;
        }
    }

    // Update is called once per frame
    void Update()
    {   
        if (Input.GetKeyDown(rotateItems))
        {
            inventory.RotateItem();
        }

        if(inventory.inventorySlots.Count < 1)
        {
            return;
        }

        if(Input.GetKeyDown(interacteWithItem))
        {
            interactionStarted = true;
            holdDownStartTime = Time.time;
            LoadInteraction();
        }

        if (Input.GetKeyUp(interacteWithItem))
        {            
            Interact();
        }

        if(interactionStarted)
        {
            float holdDownTime = Time.time - holdDownStartTime;
            if (holdDownTime > maxLoadTime)
            {
                Debug.Log("Max load time reached.");
                Interact();
            }
        }
    }

    /// <summary>
    /// Interactes with the item
    /// </summary>
    private void Interact()
    {
        var selectedItem = GetSelectedInventorySlot();
        if (selectedItem == null)
        {
            return;
        }

        if (selectedItem.item is ResourceObject)
        {
            Destroy(loadedGameObject);

            var item = selectedItem.item.throwablePrefab;
            Instantiate(item, throwPoint.position, throwPoint.rotation);

            if(selectedItem.amount > 1)
            {
                selectedItem.amount--;
            }
            else
            {
                inventory.inventorySlots.Remove(selectedItem);
            }
        }
    }

    private void LoadInteraction()
    {
        if(!interactionStarted)
        {
            return;
        }

        interactionStarted = false;
        var selectedItem = GetSelectedInventorySlot();
        if (selectedItem == null)
        {
            return;
        }

        if (selectedItem.item is ResourceObject)
        {
            var itemPrefab = selectedItem.item.collectablePrefab;
            loadedGameObject = Instantiate(itemPrefab, gameObject.transform.position, gameObject.transform.rotation);

            var item = loadedGameObject.GetComponent<Item>();
            if(item)
            {
                item.Owner = gameObject;
            }
        }
    }

    private InventorySlot GetSelectedInventorySlot()
    {
        return inventory.inventorySlots.FirstOrDefault();
    }
}
