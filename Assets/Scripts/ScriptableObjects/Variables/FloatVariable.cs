using UnityEngine;

[CreateAssetMenu(fileName = "VAR_newFloatVariable", menuName = "Variables/Float Variable")]
public class FloatVariable : ScriptableObject
{
#if UNITY_EDITOR
    [Multiline]
    public string DeveloperDescription = "";
#endif
    public float DefaultValue;
    private float currentValue;

    public float CurrentValue
    {
        get { return currentValue; }
        set { currentValue = value; }
    }

    public void SetValue(float value)
    {
        CurrentValue = value;
    }

    public void SetValue(FloatVariable value)
    {
        CurrentValue = value.CurrentValue;
    }

    public void ApplyChange(float amount)
    {
        CurrentValue += amount;
    }

    public void ApplyChange(FloatVariable amount)
    {
        CurrentValue += amount.CurrentValue;
    }

    private void OnEnable()
    {
        currentValue = DefaultValue;
    }
}
