using System.Collections;
using System.Collections.Generic;

using UnityEngine;

[RequireComponent(typeof(Animator), typeof(Rigidbody2D), typeof(SpriteRenderer))]
public class RunController : MonoBehaviour
{
    private Animator _animator;
    private Rigidbody2D _body2D;
    private SpriteRenderer _sprite;

    private static readonly int Running = Animator.StringToHash("IsRunning");

    [SerializeField] private float maxSpeed;
    [SerializeField] private float speed;
    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _body2D = GetComponent<Rigidbody2D>();
        _sprite = GetComponent<SpriteRenderer>();
    }
    
    private void Update()
    {
        PlayerState state = Player.Instance.State;

        if (state.IsActive)
        {
            Move();
        }
        else
        {
            _animator.SetBool(Running, false);
            // When the player reach the end , we stop him
            _body2D.velocity = new Vector2(0, _body2D.velocity.y);
        }
    }

    public void Move()
    {
        _animator.SetBool(Running, Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.Q));
        if (Input.GetKey(KeyCode.D))
        {
            _sprite.flipX = false;
            _body2D.AddForce(new Vector2(speed, 0), ForceMode2D.Force);
        }
        if (Input.GetKey(KeyCode.Q))
        {
            _sprite.flipX = true;
            _body2D.AddForce(new Vector2(-speed, 0), ForceMode2D.Force);
        }
        if (!Input.GetKey(KeyCode.D) && !Input.GetKey(KeyCode.Q)) {
            _body2D.velocity = new Vector2(0, _body2D.velocity.y);
        }
    }

    private void FixedUpdate()
    {
        Vector2 vel = _body2D.velocity;
        _body2D.velocity = new Vector2(Mathf.Clamp(vel.x, -maxSpeed, maxSpeed), vel.y);
    }
}