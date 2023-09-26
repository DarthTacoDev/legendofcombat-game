using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public bool FacingLeft { get { return facingLeft; } set { facingLeft = value; } }
    public static PlayerController Instance;

    [SerializeField] private float moveSpeed = 1f;
    [SerializeField] private float rollSpeed = 4;

    private PlayerControls playerControls;
    private Vector2 movement;
    private Rigidbody2D rb;
    private Animator animator;
    private SpriteRenderer spriteRenderer;

    private bool facingLeft = false;
    private bool isRolling = false;

    private void Start()
    {
        playerControls.Combat.Roll.performed += _ => Roll();
    }

    private void Awake()
    {
        Instance = this;
        playerControls = new PlayerControls();
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnEnable()
    {
        playerControls.Enable();
    }

    private void Update()
    {
        PlayerInput();
    }

    private void FixedUpdate()
    {
        AdjustPlayerFacingDirection();
        Move();
    }

    private void PlayerInput()
    {
        movement = playerControls.Movement.Move.ReadValue<Vector2>();

        animator.SetFloat("moveX", movement.x);
        animator.SetFloat("moveY", movement.y);
    }

    private void Move()
    {
        rb.MovePosition(rb.position + movement.normalized * (moveSpeed * Time.fixedDeltaTime)); 
    }

    private void AdjustPlayerFacingDirection()
    {
        Vector3 mousePos = Input.mousePosition;
        Vector3 playerScreenPoint = Camera.main.WorldToScreenPoint(transform.position);

        if (mousePos.x < playerScreenPoint.x)
        {
            spriteRenderer.flipX = true;
            FacingLeft = true;
        }
        else
        {
            spriteRenderer.flipX = false;
            FacingLeft = false;
        }
    }

    private void Roll()
    {
        if (!isRolling)
        {
            isRolling = true;
            animator.SetTrigger("roll");
            moveSpeed *= rollSpeed;
            StartCoroutine(EndRollRoutine());
        }
    }

    private IEnumerator EndRollRoutine()
    {
        float rollTime = .2f;
        float rollCD = .25f;
        yield return new WaitForSeconds(rollTime);
        moveSpeed /= rollSpeed;
        yield return new WaitForSeconds(rollCD);
        isRolling = false;
    }
}
