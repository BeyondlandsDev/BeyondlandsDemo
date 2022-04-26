using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateController : MonoBehaviour
{
    public PlayerController PlayerController;
    public CurrentGameState CurrentGameState;
    public GameState GameState;

    private void Update()
    {
        CheckState();
    }

    private void CheckState()
    {
        if (CurrentGameState.State == GameState)
        {
            if (PlayerController.enabled)
                return;
            else
                PlayerController.enabled = true;
        }
        else
            PlayerController.enabled = false;
    }
}
