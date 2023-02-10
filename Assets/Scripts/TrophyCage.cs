using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Object = System.Object;

public class TrophyCage : MonoBehaviour
{
    public static TrophyCage Instance { get; private set; }
    
    [SerializeField] private int _fruitsNumberToOpen ;
    public int FruitsNumberToOpen => _fruitsNumberToOpen;
    [SerializeField] private GameObject _cageUI;


    private void Awake()
    {
        Instance = this;
    }
    
    public void TryOpen(int collectedCount)
    {
        Debug.Log("Collected : " + collectedCount);
        Debug.Log("_fruitsToOpen : " + _fruitsNumberToOpen);
        if (collectedCount == _fruitsNumberToOpen)
        {
            Destroy(_cageUI);
            Destroy(gameObject);
        }
    }

}
