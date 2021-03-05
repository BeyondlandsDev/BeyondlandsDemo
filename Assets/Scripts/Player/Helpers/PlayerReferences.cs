using System;
using UnityEngine;

[Serializable]
public class PlayerReferences
{
    [Header("Components")]
    public Camera PlayerCamera;
    public Transform PlayerTransform;
    public CharacterController CharacterController;
    public Transform GroundCollider;
    public LayerMask GroundMask;

    [Header("Player Stats Set")]
    public StatSet PlayerStats;
    public MovementStat MovementStat;   
    public StaminaStat StaminaStat;

    [Header("Global Game Settings")]
    public GameSettings GameSettings;

    public FloatReference Gravity;
}
