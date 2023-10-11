using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BigChest : Interactable
{
    public Item contents;
    public Inventory playerInventory;
    public bool isOpen;
    public bool raiseItem;
    public GameObject dialogBox;
    public TextMeshProUGUI dialogText;
    
    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && PlayerInRange) 
        {
            if (!isOpen)
            {
                //open chest
                OpenChest();
            }
            else
            {
                //chest already open
                ChestOpenAlready();
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            dialogBox.SetActive(false);
        }
    }

    public void OpenChest()
    {
        dialogBox.SetActive(true);

        dialogText.text = contents.itemDescription;
        playerInventory.AddItem(contents);
        playerInventory.currentItem = contents;
        animator.SetBool("opened", true);
    }

    public void ChestOpenAlready()
    {
        if (!isOpen)
        {            
            dialogBox.SetActive(false);
            playerInventory.currentItem = null;
        
            isOpen = true;
        }
    }
}
