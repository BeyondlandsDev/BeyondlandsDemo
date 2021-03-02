using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    public InteractableAction Action;

    public void Interact()
    {
        Action.Action(this);
    }
}
