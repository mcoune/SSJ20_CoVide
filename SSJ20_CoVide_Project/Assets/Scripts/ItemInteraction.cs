using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemInteraction : MonoBehaviour
{
    public KeyCode rotateItems;
    public KeyCode interacteWithItem;

    /// <summary>
    /// The Invenctory
    /// </summary>
    public InventoryObject inventory;

    public void Awake()
    {
        var player = GetComponent<Player>();
        if(player != null)
        {
            inventory = player.inventory;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {   
        if (Input.GetKeyDown(rotateItems))
        {
            inventory.RotateItem();
        }

        if(Input.GetKeyDown(interacteWithItem))
        {

        }
    }
}
