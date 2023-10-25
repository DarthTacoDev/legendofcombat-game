using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeTrapCollision : MonoBehaviour
{
    [SerializeField] private float cooldownTime = 0.5f;
    [SerializeField] private int damage = 1;
    [SerializeField] private float knockBackThrust = 1f;

    private Animator anim;
    private Knockback knockback;
    public bool inRange = false;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        knockback = GetComponent<Knockback>();
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            //only if player state isnt dashing
            if (!PlayerController.Instance.isDashing)
            {
                inRange = true;
            }
        }

        if (inRange == true)
        {
            Debug.Log("Player hit");
            StartCoroutine(ActivatedRoutine());

            PlayerHealth.Instance.playerHurt.Play();
            PlayerHealth.Instance.TakeDamage(damage, collision.transform);

            knockback.GetKnockedBack(PlayerController.Instance.transform, knockBackThrust);
        }
        else { return; }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            inRange = false;
        }
    }

    private IEnumerator ActivatedRoutine()
    {
        anim.SetBool("activated", true);

        yield return new WaitForSeconds(cooldownTime);

        anim.SetBool("activated", false);
    }
}