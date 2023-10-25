using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private int startingHealth = 3;
    [SerializeField] private GameObject deathVFXPrefab;
    [SerializeField] private float knockBackThrust = 15f;
    [SerializeField] private AudioSource enemyHurt;
    [SerializeField] private ParticleSystem enemyHitPS;
    [SerializeField] private GameObject enemyHitObject;

    private int currentHealth;
    private Knockback knockback;
    private Flash flash;

    private void Awake()
    {
        knockback = GetComponent<Knockback>();
        flash = GetComponent<Flash>();
        enemyHurt = GetComponent<AudioSource>();
    }

    private void Start()
    {
        currentHealth = startingHealth;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        knockback.GetKnockedBack(PlayerController.Instance.transform, knockBackThrust);
        ScreenShakeManager.Instance.ShakeScreen();
        
        enemyHurt.Play();
        
        if (PlayerController.Instance.FacingLeft == true)
        {
            enemyHitObject.transform.rotation = Quaternion.Euler(15, -90, 0);
            enemyHitPS.Play();
        }
        else
        {
            enemyHitObject.transform.rotation = Quaternion.Euler(15, 90, 0);
            enemyHitPS.Play();
        }

        StartCoroutine(flash.FlashRoutine());
        StartCoroutine(CheckDetectDeathRoutine());
    }

    private IEnumerator CheckDetectDeathRoutine()
    {
        yield return new WaitForSeconds(flash.GetRestoreMatTime());
        DetectDeath();
    }

    private void DetectDeath()
    {
        if (currentHealth <= 0)
        {
            Instantiate(deathVFXPrefab, transform.position, Quaternion.identity);
            GetComponent<PickUpSpawner>().DropItems();
            Destroy(gameObject);
        }
    }
}
