using System;
using UnityEngine;

[Serializable]
public class QueuedRecipe
{
    public Recipe Recipe;
    public int Amount;
    public int Remaining;
    public float Progress;

    public void SetNewQueuedRecipe(Recipe recipe, int amount)
    {
        Recipe = recipe;
        Amount = amount;
        Remaining = amount;
    }

    public void ClearQueuedRecipe()
    {
        Recipe = null;
        Amount = 0;
        Remaining = 0;
        Progress = 0;
    }
}

