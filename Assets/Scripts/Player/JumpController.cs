using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Animator), typeof(Rigidbody2D))]
public partial class JumpController : MonoBehaviour
{
    private Animator _animator;
    private Rigidbody2D _body2D;

    [SerializeField] private float jumpMaxSpeed = 15;

    [SerializeField] private float jumpSpeed = 15;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _body2D = GetComponent<Rigidbody2D>();
    }

    private void Jump()
    {
        // Is grounded
        // Not getting hit
        bool isGround = Player.Instance.State.IsGrounded;
        bool canJump = !Player.Instance.State.IsJumping;
        bool isNotStagger = !Player.Instance.State.IsStagger;

        if (isGround && canJump && isNotStagger)
        {
            _animator.Play("MyHeroJump", -1, 0.0f);
            _body2D.AddForce(new Vector2(0, jumpSpeed), ForceMode2D.Impulse);
        }
    }

    private void Update()
    {
        PlayerState state = Player.Instance.State;
        if (Input.GetKeyDown(KeyCode.Space) && state.IsActive)
        {
            Jump();
        }
    }

    private void FixedUpdate()
    {
        Vector2 vel = _body2D.velocity;
        _body2D.velocity = new Vector2(vel.x, Mathf.Clamp(vel.y, -jumpMaxSpeed, jumpMaxSpeed));
    }
}


