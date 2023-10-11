using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoomerangProjectile : MonoBehaviour
{
    [SerializeField] private GameObject particleOnHitPrefabVFX;
    [SerializeField] private float projectileRange = 10f;
    [SerializeField] private float returnTime = 1f;

    private float moveSpeed = 22f;
    private Vector3 startPosition;
    private float state = 1; //if state is 1, then it is away from player, if the state is 2, then it is coming back to player
    private Vector2 currentPosition;

    private void Start()
    {
        startPosition = transform.position;
    }

    private void Update()
    {
        MoveProjectile();
        DetectSwitchState();
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

    private void DetectSwitchState()
    {
        if (Vector3.Distance(transform.position, startPosition) > projectileRange)
        {
            state = 2;
        }
    }

    private void MoveProjectile()
    {
        if (state == 1)
        {
            transform.Translate(Vector3.right * Time.deltaTime * moveSpeed);
        }

        currentPosition = transform.position;

        if (state == 2)
        {
            StartCoroutine(BoomerangStateRoutine());
        }
    }

    public void UpdateProjectileRange(float projectileRange)
    {
        this.projectileRange = projectileRange;
    }

    public void UpdateMoveSpeed(float moveSpeed)
    {
        this.moveSpeed = moveSpeed;
    }

    private IEnumerator BoomerangStateRoutine()
    {
        //if state is 1, do nothing
        //but if state is 2, lerp back to start position and destroy the gameobject

            float elapsedTime = 0f;
            Vector3 initialPosition = transform.position;
            Debug.Log(state);

            while (elapsedTime < returnTime)
            {
                transform.position = Vector3.Lerp(initialPosition, startPosition, elapsedTime / returnTime);
                elapsedTime += Time.deltaTime;

            }

            if (transform.position == startPosition)
            {
                state = 1;
            }

            yield return null;
            Destroy(gameObject);
    }

}

