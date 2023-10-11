using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmallChest : MonoBehaviour
{
    private Animator animator;
    private bool opened = false;
    private bool canOpen = false;
    private PlayerControls playerControls;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        opened = false;
        canOpen = false;
        animator.SetBool("Open", false);
        playerControls = new PlayerControls();
    }

    private void Start()
    {
        playerControls.Interact.ItemInteract.performed += _ => OpenChest();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            canOpen = true;
            Debug.Log(canOpen);

            Debug.Log("Player in bounds");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            canOpen = false;
            Debug.Log("Player out of bounds");
        }
    }

    private void OpenChest()
    {
        Debug.Log("Interact button pressed");

        if (opened)
        {
            Debug.Log("Already opened!");
        } 
        else
        {
            if (canOpen)
            {
                opened = true;
                //chest stuff
                animator.SetTrigger("Opening");
                StartCoroutine(waitRoutine(1f));
                Debug.Log("Opening chest");
            }
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

    IEnumerator waitRoutine(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);

        animator.SetBool("Open", true);
    }

}
