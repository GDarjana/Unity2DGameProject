using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


public class Player : MonoBehaviour
{    
    private static readonly string WalkableSurfaceTag = "GroundSurface";
    
    private PlayerState _state;
    private CollectableState _collectState;
    public static Player Instance { get; private set; }
    public PlayerState State => _state;
    public CollectableState CollectState => _collectState;
    private void Awake()
    {
        Instance = this;
        _collectState = new CollectableState();
        _state = new PlayerState()
        {
            IsGrounded = true,
            IsJumping = false,
            IsStagger = false
        };
#if UNITY_EDITOR
        _state.OnIsGroundUpdate += val => Debug.Log($"Debug : {val}");
#endif
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (!other.gameObject.CompareTag(WalkableSurfaceTag))
        {
            return;
        }

        State.IsGrounded = true;
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (!other.gameObject.CompareTag(WalkableSurfaceTag))
        {
            return;
        }
        State.IsGrounded = false;

    }

    private static Collider2D[] colliders = new Collider2D[32];
    private void Update()
    {
    
        int layer = LayerMask.GetMask("Ground");

        int i = Physics2D.OverlapCircleNonAlloc(Vector2.zero, 1f, colliders);

    }
    
}