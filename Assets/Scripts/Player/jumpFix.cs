using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class jumpFix : MonoBehaviour
{
    public PlayerInput playerControls;
    private InputAction jump;

    private Rigidbody2D rb;

    public float fallMultiplier;
    public float lowJumpMultiplier;
    
    public void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnEnable()
    {
        jump = playerControls.Player.Jump;
        jump.Enable();
    }

    private void OnDisable()
    {
        jump.Disable();
    }

    private void Update()
    {
        if (rb.velocity.y < 0)
        {
            rb.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
        }
        else if (rb.velocity.y > 0 && !jump.triggered)
        {
            rb.velocity += Vector2.up * Physics2D.gravity.y * (lowJumpMultiplier - 1) * Time.deltaTime;
        }
    }

}
