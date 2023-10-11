using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryOpen : MonoBehaviour
{
    private bool inventoryOpened;
    private PlayerControls playerControls;

    private void Awake()
    {
        playerControls = new PlayerControls();
    }

    private void Start()
    {
        inventoryOpened = false;
        this.gameObject.SetActive(false);

        playerControls.Inventory.Open.performed += _ => Inventory();
    }

    private void Inventory()
    {
        Debug.Log("Button pressed");

        if (inventoryOpened == false)
        {
            inventoryOpened = true;
            gameObject.SetActive(true);
        }
        else if (inventoryOpened == true)
        {
            gameObject.SetActive(false);
        }
    }
    private void OnEnable()
    {
        playerControls.Enable();
    }

    private void OnDisable()
    {
        playerControls.Disable();
    }
}
