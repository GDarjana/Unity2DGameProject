using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FruitUIPrinter : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI textbox;

    private void OnEnable()
    {
        CollectableState state = Player.Instance.CollectState;
        state.OnFruitCountUpdate += OnFruitCountUpdate;
    }

    private void OnDisable()
    {
        CollectableState state = Player.Instance.CollectState;
        state.OnFruitCountUpdate += OnFruitCountUpdate;
    }

    private void OnFruitCountUpdate(int fruitCount)
    {
        textbox.text = fruitCount.ToString();
    }
}
