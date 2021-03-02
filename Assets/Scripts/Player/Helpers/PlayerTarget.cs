using System;
using UnityEngine;

[Serializable]
public class PlayerTarget
{
    public InteractableVariable target;
    public float targetDistance = 5f;
    public LayerMask layerMask;

    public void CheckForTarget(Camera cam)
    {
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        Physics.Raycast(ray, out RaycastHit hit, targetDistance, layerMask);

        if (hit.collider == null)
        {
            target.CurrentValue = null;
            return;
        }

        target.CurrentValue = hit.collider.GetComponent<Interactable>();

        if (Input.GetKeyDown(KeyCode.E))
        {
            target.CurrentValue.Interact();
        }
    }
}
