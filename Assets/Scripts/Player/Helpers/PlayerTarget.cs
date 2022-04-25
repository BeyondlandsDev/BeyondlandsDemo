using System;
using UnityEngine;

[Serializable]
public class PlayerTarget
{
    private float targetDistance = 5f;
    private LayerMask layerMask = LayerMask.GetMask("Interactable");
    private PlayerReferences player;
    private Camera cam;
    private InteractableVariable target;

    public Interactable CurrentTarget;

    public PlayerTarget(PlayerReferences playerRef)
    {
        player = playerRef;
        target = playerRef.Target;
        //layerMask = LayerMask.GetMask("Interactable");
        cam = playerRef.PlayerCamera;
    }

    public void CheckForTarget()
    {
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        Physics.Raycast(ray, out RaycastHit hit, targetDistance, layerMask);

        if (hit.collider == null)
        {
            target.CurrentValue = null;
            CurrentTarget = null;
            return;
        }

        target.CurrentValue = hit.collider.GetComponent<Interactable>();
        CurrentTarget = target.CurrentValue;

        if (Input.GetButtonDown("Interact"))
        {
            target.CurrentValue.Interact(player);
        }
    }
}
