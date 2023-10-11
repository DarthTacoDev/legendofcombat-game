using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoomProjectie : MonoBehaviour
{
    [SerializeField] private GameObject particleOnHitPrefabVFX;
    [SerializeField] private float projectileRange = 10f;
    [SerializeField] private float returnTime = 1f;

    private float moveSpeed = 22f;
    private bool returning = false;
    private bool away = false;
    Vector2 boomReturnPosX = PlayerController.Instance.playerX;
    Vector2 boomReturnPosY = PlayerController.Instance.playerY;

    private void Update()
    {
        MoveProjectile();

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        EnemyHealth enemyHealth = collision.gameObject.GetComponent<EnemyHealth>();
        Indestructible indestructible = collision.gameObject.GetComponent<Indestructible>();
        PlayerHealth player = collision.gameObject.GetComponent<PlayerHealth>();

        if (!collision.isTrigger && (enemyHealth || indestructible || player))
        {
            if ((player) || (enemyHealth))
            {
                player?.TakeDamage(1, transform);
                Instantiate(particleOnHitPrefabVFX, transform.position, transform.rotation);
                Destroy(gameObject);
            }
            else if (!collision.isTrigger && indestructible)
            {
                Instantiate(particleOnHitPrefabVFX, transform.position, transform.rotation);
                Destroy(gameObject);
            }
        }
    }

    private void MoveProjectile()
    {
        away = true;
        transform.Translate(Vector3.right * Time.deltaTime * moveSpeed);

        StartCoroutine(BoomerangRoutine());
    }

    public void UpdateProjectileRange(float projectileRange)
    {
        this.projectileRange = projectileRange;
    }

    public void UpdateMoveSpeed(float moveSpeed)
    {
        this.moveSpeed = moveSpeed;
    }

    private IEnumerator BoomerangRoutine()
    {
        float elapsedTime = 0f;
        
        if (away == true)
        {
            away = false;
            returning = true;

            while (elapsedTime < returnTime)
            {
                elapsedTime += Time.deltaTime;
                this.transform.position = Vector2.Lerp(boomReturnPosX, boomReturnPosY, elapsedTime);
            }
        }

        yield return null;

    }

}
