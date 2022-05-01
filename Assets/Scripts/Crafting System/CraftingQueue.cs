using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

[Serializable]
[CreateAssetMenu]
public class CraftingQueue : ScriptableObject
{
    public Queue<QueuedRecipe> Queue;
    public int MaxQueue;

    public Stack<QueuedRecipe> Pool;

    public bool IsCrafting = false;

    private void OnEnable()
    {
        Queue = new Queue<QueuedRecipe>();
        Pool = new Stack<QueuedRecipe>();

        for (int i = 0; i < MaxQueue; i++)
        {
            Pool.Push(new QueuedRecipe());
        }
    }

    public void AddToQueue(Recipe recipe, int amount)
    {
        if (Queue.Count < MaxQueue)
        {
            var newQueuedRecipe = Pool.Pop();
            newQueuedRecipe.SetNewQueuedRecipe(recipe, amount);
            Queue.Enqueue(newQueuedRecipe);
        }
        else
            Debug.Log("QUEUE IS FULL");
    }

    public void DequeueAndPool()
    {
        if (Queue.Count > 0)
        {
            var oldQueuedRecipe = Queue.Dequeue();
            Debug.Log($"DEQUEUING {oldQueuedRecipe.Recipe}");

            oldQueuedRecipe.ClearQueuedRecipe();
            Pool.Push(oldQueuedRecipe);
        }
        else
            Debug.Log("NOTHING TO DEQUEUE");
    }

//     public IEnumerator CraftingTimer()
//     {
//         while (PeekRecipe() != null && PeekRecipe().Remaining > 0)
//         {
//             if (PeekRecipe().Remaining != 0)
//             {
//                 IsCrafting = true;
//                 float duration = PeekRecipe().Recipe.Duration;
//                 float elapsed = 0;
//                 while (elapsed < duration)
//                 {
//                     elapsed += Time.deltaTime;
//                     PeekRecipe().Progress = elapsed/duration;
//                     yield return null;
//                 }

//                 yield return null;

//                 RemoveIngredients(PeekRecipe().Recipe);
//                 GiveRecipeResult(PeekRecipe().Recipe);
//                 PeekRecipe().Remaining--;
//                 OnInventoryChanged.Raise();

//                 yield return null;
//             }

//             if (PeekRecipe().Remaining < 0)
//             {
//                 PeekRecipe().Remaining = 0;
//                 yield return null;
//             }

//             if (PeekRecipe().Remaining > 0)
//             {
//                 StartCoroutine(CraftingTimer());
//             }


//             if (PeekRecipe().Remaining == 0)
//             {
//                 RecipeQueue.DequeueAndPool();
//                 KnownRecipes.CurrentlyCraftingRecipe = null;
//                 OnDequeueRecipe.Raise();
//                 yield return null;

//                 if (RecipeQueue.Queue.Count > 0 && PeekRecipe().Recipe != null)
//                 {
//                     StartCraftingRecipe();
//                 }
//                 yield return null;
//             }
//         }
//     }   

//     public QueuedRecipe PeekRecipe()
//     {
//         if (Queue.Count != 0)
//         {
//             return Queue.Peek();
//         }
//         else
//             return null;
//     }

//     public void ClearQueue()
//     {
//         foreach (QueuedRecipe recipe in Queue)
//         {
//             if (recipe != Queue.Peek())
//             {
//                 recipe.ClearQueuedRecipe();
//             }
//             else
//                 Queue.Peek().Remaining = 1;
//         }
//     }
}
