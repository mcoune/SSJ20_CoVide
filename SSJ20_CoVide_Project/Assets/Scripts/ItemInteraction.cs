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
        if (player != null)
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

        if (inventory.inventorySlots.Count < 1)
        {
            return;
        }

        if (Input.GetKeyDown(interacteWithItem))
        {
            interactionStarted = true;
            holdDownStartTime = Time.time;
            LoadInteraction();
            ShowTrajectory(true);
        }

        if (Input.GetKeyUp(interacteWithItem))
        {
            Interact();
        }

        if (interactionStarted)
        {
            float holdDownTime = Time.time - holdDownStartTime;
            Debug.Log("HoldTime: " + holdDownTime);

            if (holdDownTime > maxLoadTime)
            {
                Debug.Log("Max load time reached.");
                Interact();
            }
        }

        if (loadedGameObject)
        {
            loadedGameObject.transform.rotation = throwPoint.rotation;
            loadedGameObject.transform.position = throwPoint.position;
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

            if (loadedGameObject != null)
            {
                var item = selectedItem.item.throwablePrefab;
                var throwable = Instantiate(item, throwPoint.position, throwPoint.rotation);
                ShowHand(false);
                FindObjectOfType<AudioManager>().Play("ThrowItem");

                var t = throwable.GetComponent<Throwable>();
                t.owner = gameObject;
            }

            if (selectedItem.amount > 1)
            {
                selectedItem.amount--;
            }
            else
            {
                inventory.inventorySlots.Remove(selectedItem);
            }
        }

        ShowTrajectory(false);
    }

    private void LoadInteraction()
    {
        if (!interactionStarted)
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
            loadedGameObject = Instantiate(itemPrefab, throwPoint.position, throwPoint.rotation);
            ShowHand(true);

            var item = loadedGameObject.GetComponent<Item>();
            if (item)
            {
                item.Owner = gameObject;
            }
        }
    }

    private InventorySlot GetSelectedInventorySlot()
    {
        return inventory.inventorySlots.FirstOrDefault();
    }

    public void ShowTrajectory(bool setActive)
    {
        var child = throwPoint.transform.GetChild(0);
        if (child == null)
        {
            return;
        }

        child.gameObject.SetActive(setActive);
    }

    public void ShowHand(bool showHand)
    {
        var renderers = throwPoint.GetComponentsInChildren<SpriteRenderer>();
        foreach (var renderer in renderers)
        {
            if(renderer.tag == "Hand")
            {
                renderer.enabled = showHand;
                break;
            }
        }
    }
}
