using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerExit : MonoBehaviour
{
    [SerializeField] private GameObject exitIndicator;
    private Rigidbody2D _body2D;
    

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            exitIndicator.SetActive(true);
            Player.Instance.State.IsActive = false;
        }
    }

}
