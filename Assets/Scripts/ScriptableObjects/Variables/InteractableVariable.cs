using UnityEngine;

[CreateAssetMenu(fileName ="VAR_newInteractableVariable", menuName ="Variables/Interactable Variable")]
public class InteractableVariable : ScriptableObject
{
#if UNITY_EDITOR
    [Multiline]
    public string DeveloperDescription = "";
#endif
    public Interactable DefaultValue;
    private Interactable currentValue;

    public Interactable CurrentValue
    {
        get { return currentValue; }
        set { currentValue = value; }
    }

    public void SetValue(Interactable value)
    {
        CurrentValue = value;
    }

    public void SetValue(InteractableVariable value)
    {
        CurrentValue = value.CurrentValue;
    }

    private void OnEnable()
    {
        currentValue = DefaultValue;
    }
}
