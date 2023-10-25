using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SawBlade : MonoBehaviour
{
    [SerializeField] private int damage = 1;
    [SerializeField] private float knockBackThrust = 8f;

    private Knockback knockback;

    private void Awake()
    {
        knockback = GetComponent<Knockback>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PlayerHealth.Instance.TakeDamage(damage, collision.transform);
            knockback.GetKnockedBack(PlayerController.Instance.transform, knockBackThrust);
            PlayerHealth.Instance.playerHurt.Play();

        }
    }
}
