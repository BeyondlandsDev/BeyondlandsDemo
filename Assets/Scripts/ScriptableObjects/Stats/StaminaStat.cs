using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "STAT_newStaminaStat", menuName = "Stats/Stamina Stat")]
public class StaminaStat : Stat
{
    [SerializeField]
    private float staminaDrain;
    public float StaminaDrain { get => staminaDrain; set => staminaDrain = value; }

    [SerializeField]
    private float staminaRegen;
    public float StaminaRegen { get => staminaRegen; set => staminaRegen = value; }

    [SerializeField]
    private bool isFatigued;
    public bool IsFatigued { get => isFatigued; set => isFatigued = value; }

    [SerializeField]
    private float fatiguedCoolDown;
    public float FatiguedCoolDown { get => fatiguedCoolDown; set => fatiguedCoolDown = value; }

    [SerializeField]
    private bool isRunning;
    public bool IsRunning { get => isRunning; set => isRunning = value; }

    public override void DoUpdate()
    {
        base.DoUpdate();
        RunningCheck();   
    }

    public void RunningCheck()
    {
        if (!IsFatigued)
        {
            if (IsRunning)
            {
                CurrentValue -= StaminaDrain * Time.deltaTime;
                if (CurrentValue <= 0)
                    IsFatigued = true;
            }
            else if (CurrentValue < 100)
                CurrentValue += StaminaRegen * Time.deltaTime;
        }
    }

}
