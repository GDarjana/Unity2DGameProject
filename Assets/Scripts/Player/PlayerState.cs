using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerState
{
    private bool _jumping;
    private bool _grounded;

    public bool IsActive
    {
        get => _grounded;
        set
        {
            bool changed = (_grounded != value );
            _grounded = value;
            if (changed) OnIsGroundUpdate?.Invoke(value);
        }
    }

    public bool IsGrounded { get; set; }
    public bool IsStagger { get; set; }
    public bool IsJumping
    {
        get => _jumping;
        set
        {
            _jumping = value;
            if (_jumping)
            {
                OnJumping?.Invoke();
            }
        }
    }

    #region EVENTS
    public event Action OnJumping;
    public event Action<bool> OnIsGroundUpdate;

    #endregion
}
