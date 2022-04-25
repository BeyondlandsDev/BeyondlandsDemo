using UnityEngine;

public class Interactable : MonoBehaviour
{
    [SerializeField]
    private string nameText;
    public string NameText { get => nameText; set => nameText = value;}

    [SerializeField]
    private string actionText;
    public string ActionText { get => actionText; set => actionText = value; }

    public virtual void Interact(PlayerReferences player)
    {
        //do common stuff?
    }
}
