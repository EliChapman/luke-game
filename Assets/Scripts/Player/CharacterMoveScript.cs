using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.EventSystems;
using System;

public class CharacterMoveScript : MonoBehaviour
{
    public float speed = 5f;
    public float jumpSpeed = 5f;
    private Vector2 moveDir;
    private Boolean canJump;

    private Rigidbody2D rb;
    public PlayerInput playerControls;
    private InputAction move;
    private InputAction jump;

    Vector2 moveVal = Vector2.zero;

    private CapsuleCollider2D jumpCheck;

    // Start is called before the first frame update
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = Vector3.zero;
        playerControls = new PlayerInput();
        jumpCheck = GetComponent<CapsuleCollider2D>();
    }

    private void OnEnable()
    {
        move = playerControls.Player.Move;
        move.Enable();
        jump = playerControls.Player.Jump;
        jump.Enable();
    }

    private void OnDisable()
    {
        jump.Disable();
        move.Disable();
    }

    private void Update()
    {
        if (jump.triggered && canJump)
        {
            rb.velocity = Vector2.up * jumpSpeed;
        }
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        moveVal = move.ReadValue<Vector2>();

        playerMove();
    }

    private void playerMove()
    {
        Console.WriteLine(moveVal);

        moveDir = new Vector2(moveVal.x, moveVal.y).normalized;

        rb.velocity = new Vector2(moveDir.x * speed, rb.velocity.y);
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        canJump = true;
    }
    public void OnCollisionExit2D(Collision2D collision)
    {
        canJump = false;
    }
}
