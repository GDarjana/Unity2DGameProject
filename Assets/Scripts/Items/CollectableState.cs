using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CollectableState {

    private int _fruitCount;
    public int FruitCount { 
        get => _fruitCount;
        set {
            _fruitCount = value;
            OnFruitCountUpdate?.Invoke(_fruitCount);
        }
    }

    public event Action<int> OnFruitCountUpdate ;
}