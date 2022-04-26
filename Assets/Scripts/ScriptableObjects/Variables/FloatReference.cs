using System;
using UnityEngine;

[CreateAssetMenu(fileName = "REF_newFloatReference", menuName = "References/Float Reference")]
public class FloatReference : ScriptableObject
{
    public bool UseConstant = true;
    public float ConstantValue;
    public FloatVariable Variable;

    public FloatReference() { }

    public FloatReference(float value)
    {
        UseConstant = true;
        ConstantValue = value;
    }

    public float Value
    {
        get { return UseConstant ? ConstantValue : Variable.DefaultValue; }
    }

    public static implicit operator float(FloatReference reference)
    {
        return reference.Value;
    }
}
