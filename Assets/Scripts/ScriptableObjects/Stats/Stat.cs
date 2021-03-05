using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Stat : ScriptableObject
{
    public string Name;

    [Tooltip("CurrentValue/MaxValue = percent. MaxValue is 100. See derived classes for specific stat values like walk speed.")]
    public float MaxValue;
    public float CurrentValue;

    private void OnEnable()
    {
        CurrentValue = MaxValue;
    }

    public virtual void DoUpdate() 
    {
        StatCleanUp();
    }

    public void StatCleanUp()
    {
        if (CurrentValue > MaxValue)
            ResetValue();
        if (CurrentValue < 0)
            CurrentValue = 0;
    }

    public float GetValue()
    {
        return CurrentValue;
    }

    public float GetMax()
    {
        return MaxValue;
    }

    public void ChangeValue(float value)
    {
        CurrentValue += value;
    }

    public void ResetValue()
    {
        CurrentValue = MaxValue;
    }
}
