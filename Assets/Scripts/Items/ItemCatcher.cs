using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ItemCatcher : MonoBehaviour
{
    private static readonly string ItemTag = "FruitItem";
    private void OnTriggerEnter2D(Collider2D item) {
        if (!item.CompareTag(ItemTag)) return;
        CollectableState state = Player.Instance.CollectState;
        TrophyCage cage = TrophyCage.Instance;
        var fruitComponent = item.GetComponent<Fruit>();
        if (fruitComponent.TryCollect(out int collectedCount))
        {
            state.FruitCount += collectedCount;

            cage.TryOpen(state.FruitCount);
        }
    }
}
