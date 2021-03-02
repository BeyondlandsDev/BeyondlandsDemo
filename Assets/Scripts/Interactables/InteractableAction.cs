using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class InteractableAction : ScriptableObject
{
    public string ActionText;
    public virtual void Action(Interactable interactable) { }
}
