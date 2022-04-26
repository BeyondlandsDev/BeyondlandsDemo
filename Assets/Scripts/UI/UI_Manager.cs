using System;
using UnityEngine;

[Serializable]
public class UI_Manager : MonoBehaviour
{
    public UIReferences UIReferences;
    //public CurrentGameState GameState;

    public GameState InventoryState;
    public GameState GameplayState;
    
    private void Awake()
    {
        UIReferences.InventoryUI.SetActive(false);    
    }

    private void Update()
    {
        ToggleInventoryUI();    
    }

    public void ToggleInventoryUI()
    {
        if (Input.GetButtonDown("Inventory"))
            UIReferences.InventoryUI.SetActive(!UIReferences.InventoryUI.activeSelf);

        if (UIReferences.InventoryUI.activeSelf)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            //UIReferences.Background.SetActive(true);
            UIReferences.CurrentState.State = InventoryState;
        }
        else
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            //UIReferences.Background.SetActive(false);
            UIReferences.CurrentState.State = GameplayState;
        }
    }
}
