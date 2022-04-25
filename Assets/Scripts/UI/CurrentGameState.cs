using UnityEngine;

[CreateAssetMenu(fileName = "STATE_currentGameState", menuName = "Game State/Current Game State")]
public class CurrentGameState : ScriptableObject
{
    public GameState State;
}
