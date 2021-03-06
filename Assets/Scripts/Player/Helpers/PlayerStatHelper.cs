using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System;

//[Serializable]
public class PlayerStatHelper
{
    private HealthStat health;
    private HungerStat hunger;
    private ThirstStat thirst;
    private SanityStat sanity;

    //public UnityEvent IsStarving;

    public PlayerStatHelper(PlayerReferences playerRef)
    {
        health = playerRef.HealthStat;
        health.IsDead = false;
        hunger = playerRef.HungerStat;
        hunger.IsStarving = false;
        thirst = playerRef.ThirstStat;
        thirst.IsDehydrated = false;
        sanity = playerRef.SanityStat;
        sanity.IsInsane = false;
    }

    public void Tick()
    {
        Debug.Log("TICK");
        HungerDrain();
        ThirstDrain();
        DyingDrain();
        WellfedHealthRegen();
        //HydratedHealthRegen();
        //HealthRegen();

        //MOVE TO EVENT vvv
        if (health.CurrentValue <= 0)
            health.IsDead = true;

        if (health.IsDead == true)
            health.CurrentValue = 0;
        //MOVE TO EVENT ^^^    

        if (Input.GetKey(KeyCode.R))
            health.ChangeValue(-10);
    }

    public void HungerDrain()
    {
        if (!hunger.NoDrain)
        {
            if (hunger.CurrentValue > 0)
                hunger.CurrentValue -= hunger.GetDrain() * Time.deltaTime;
            else
            {
                hunger.CurrentValue = 0;
                hunger.IsStarving = true;
                hunger.NoDrain = true;
                //DyingDrain();
            }
        }
    }

    public void HungerRegen()
    {
        if (!hunger.NoRegen)
        {
            if (hunger.CurrentValue < hunger.MaxValue)
                hunger.CurrentValue += hunger.GetRegen() * Time.deltaTime;
            else
            {
                hunger.CurrentValue = hunger.MaxValue;
                hunger.NoRegen = true;
            }
        }
    }
    
    public void ThirstDrain()
    {
        if (!thirst.NoDrain)
        {
            if (thirst.CurrentValue > 0)
                thirst.CurrentValue -= thirst.GetDrain() * Time.deltaTime;
            else
            {
                thirst.CurrentValue = 0;
                thirst.IsDehydrated = true;
                thirst.NoDrain = true;
                //DyingDrain();
            }
        }
    }

    public void ThirstRegen()
    {
        if (!thirst.NoRegen)
        {
            if (thirst.CurrentValue < thirst.MaxValue)
                thirst.CurrentValue += thirst.GetRegen() * Time.deltaTime;
            else
            {
                thirst.CurrentValue = thirst.MaxValue;
                thirst.NoRegen = true;
            }
        }
    }

    public void DyingDrain()
    {
        if (hunger.IsStarving || thirst.IsDehydrated)
            health.CurrentValue -= health.GetDrain() * Time.deltaTime;
    }

    public void WellfedHealthRegen()
    {
        float hungerPercent = (hunger.CurrentValue/hunger.MaxValue)*100;
        if (hungerPercent > 75)
            HealthRegen();
    }

    // public void HydratedHealthRegen()
    // {
    //     float thirstPercent = (thirst.CurrentValue/thirst.MaxValue)*100;
    //     if (thirstPercent > 60)
    //         HealthRegen();
    // }

    public void HealthRegen()
    {
        if (!health.NoRegen)
        {
            if (health.CurrentValue < health.MaxValue)
                health.CurrentValue += health.GetRegen() * Time.deltaTime;
            else
            {
                health.CurrentValue = health.MaxValue;
                health.NoRegen = true;
            }
        }

        if (health.CurrentValue < health.MaxValue)
            health.NoRegen = false;
    }

    public void SanityDrain()
    {
        if (!sanity.NoDrain)
        {
            if (sanity.CurrentValue > 0)
                sanity.CurrentValue -= sanity.GetDrain();
            else
            {
                sanity.CurrentValue = 0;
                sanity.IsInsane = true;
                sanity.NoDrain = true;
            }
        }
    }
}
