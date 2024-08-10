using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEvent : MonoBehaviour
{
    [HideInInspector]
    public static GameEvent Instance { get; private set; }
    public event Action OnSpinTriggered;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public void TriggerSpin()
    {
        OnSpinTriggered?.Invoke();
    }
}
