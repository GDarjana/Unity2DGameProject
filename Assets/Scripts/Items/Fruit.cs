using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class Fruit : MonoBehaviour
{
    [SerializeField] private int count;
    [SerializeField] private float animationDurationInSeconds;

    private Animator _animator;
    private bool _collected;
    public int Count => count;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    public bool TryCollect(out int collectedCount)
    {
        collectedCount = -1;
        if (_collected) return false;

        collectedCount = Count;
        OnCollected();
        return (_collected = true);

        
    }
    private void OnCollected()
    {
        _animator.Play("FruitCollected", -1, .0f);
        StartCoroutine(WaitingEndsOfAnimationCoroutine());
    }
    private IEnumerator WaitingEndsOfAnimationCoroutine()
    {
        yield return new WaitForSeconds(animationDurationInSeconds);
        GetComponent<SpriteRenderer>().enabled = false;
        Destroy(gameObject);
    }
}
