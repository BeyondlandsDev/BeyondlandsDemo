using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class StatusEffect
{
    public string Description;
    public Stat Stat;
    public float Value;

    public void Apply()
    {
        Stat.ChangeValue(Value);
    }
}
