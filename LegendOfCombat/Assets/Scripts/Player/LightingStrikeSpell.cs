using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightingStrikeSpell : MonoBehaviour
{
    [SerializeField] private GameObject lightningStrikePrefab;
    [SerializeField] private float spellCooldown = 0.5f;

    private Vector3 enemyPos;
    private CircleCollider2D circleCollider;
    private PlayerControls playerControls;
    private bool LightningStrike = false;
    private GameObject instanceLightning;
    private bool ButtonPressed = false;
    private Vector3 offset = new Vector3(0f, .3f, 0f);
    private EnemyAI enemyAI;

    private void Awake()
    {
        circleCollider = GetComponent<CircleCollider2D>();
        playerControls = new PlayerControls();
        enemyAI = new EnemyAI();
    }
    
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            ButtonPressed = true;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            enemyPos = collision.transform.position;
            if (ButtonPressed == true)
            {
                Debug.Log("Spell Pressed");
                ButtonPressed = false;
                if (LightningStrike == false)
                {
                    Debug.Log("Lightning Strike initiated");
                    LightningStrikeInstance(enemyPos);
                }
            }
        }
    }

    private void OnEnable()
    {
        playerControls.Enable();
    }

    private void LightningStrikeInstance(Vector3 enemyPosition)
    {
        LightningStrike = true;
        instanceLightning = Instantiate(lightningStrikePrefab, enemyPosition + offset, Quaternion.identity);
        Debug.Log("SPAWNED");

        StartCoroutine(LStrikeRoutine(3f));
    }

    private IEnumerator LStrikeRoutine(float waitTime)
    {
        LightningStrike = false;
        yield return new WaitForSeconds(waitTime);
        Destroy(instanceLightning);
        Debug.Log("DESTROYED");
    }
}
