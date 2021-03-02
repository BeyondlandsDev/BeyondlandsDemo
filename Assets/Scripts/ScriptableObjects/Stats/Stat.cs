using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

//[CreateAssetMenu(fileName = "STAT_newStat", menuName = "Stats/Stat")]
public class Stat : ScriptableObject
{
    //public StatType Type;
    public string Name;
    //public FloatReference Reference;
    public float MaxValue;
    public float CurrentValue;

    private void OnEnable()
    {
        CurrentValue = MaxValue;
        //CurrentValue = Reference.Value;
    }

    public virtual void DoUpdate() { }

    public float GetMax()
    {
        return MaxValue;
        //return Reference.Variable.DefaultValue;
    }

    public void ChangeValue(float value)
    {
        CurrentValue += value;
    }

    public void ResetValue()
    {
        CurrentValue = MaxValue;
        //CurrentValue = Reference.Value;
    }
}
