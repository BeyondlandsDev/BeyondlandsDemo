using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SurvivalStat : Stat
{
    [SerializeField]
    private float baseDrain;
    public float BaseDrain { get => baseDrain; set => baseDrain = value; }

    [SerializeField]
    private float baseRegen;
    public float BaseRegen { get => baseRegen; set => baseRegen = value; }

    [SerializeField]
    private float drainModifier;
    public float DrainModifier { get => drainModifier; set => drainModifier = value; }

    [SerializeField]
    private float regenModifier;
    public float RegenModifier { get => regenModifier; set => regenModifier = value; }

    //
    // [SerializeField]
    // private float drain;
    // public float Drain { get => drain; set => drain = value; }

    // [SerializeField]
    // private float regen;
    // public float Regen { get => regen; set => regen = value; }

    public float GetDrain()
    {
        return baseDrain * drainModifier;
    }

    public float GetRegen()
    {
        return baseRegen * regenModifier;
    }
}
