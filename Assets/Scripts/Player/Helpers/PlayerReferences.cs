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

    [Header("Player Stats")]
    //public StatSet PlayerStats;
    public HealthStat HealthStat;
    public MovementStat MovementStat;   
    public StaminaStat StaminaStat;
    public HungerStat HungerStat;
    public ThirstStat ThirstStat;
    public SanityStat SanityStat;

    [Header("Global Game Settings")]
    public GameSettings GameSettings;
    public FloatReference Gravity;
}
