using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraftingController : MonoBehaviour
{
    public Inventory Inventory;
    public RecipesDatabase KnownRecipes;

    public CraftingQueue RecipeQueue;
    public List<QueuedRecipe> QueuedRecipesList;
    //public bool CraftingInProgress;
//    public QueuedRecipe PeekRecipe;

    public GameEvent OnEnqueueRecipe;
    public GameEvent OnDequeueRecipe;
    public GameEvent OnInventoryChanged;

    private void Awake()
    {
        Inventory = GetComponentInParent<PlayerController>().Player.Inventory;
        KnownRecipes = GetComponentInParent<PlayerController>().Player.KnownRecipes;
        KnownRecipes.CurrentlyCraftingRecipe = null;
    }

    private void Update()
    {
        TryActivateQueue();
        ShowQueue();
    }

    private void ShowQueue()
    {
        QueuedRecipesList.Clear();
        foreach (QueuedRecipe recipe in RecipeQueue.Queue)
            QueuedRecipesList.Add(recipe);
    }

    public void TryActivateQueue()   //this needs to be called by event, not update, or by crafting buttons
    {
        if (RecipeQueue.Queue.Count == 0)
        {
            RecipeQueue.IsCrafting = false;
            return;
        }

        if (RecipeQueue.Queue.Count > 0 && !RecipeQueue.IsCrafting)
        {
            if (PeekRecipe().Recipe == null)
            {
                RecipeQueue.Queue.Dequeue();
                RecipeQueue.IsCrafting = false;
            }
            else
                StartCrafting();
        }

    }

    public void CraftAny(int amount)    //this is for the button
    {
        var recipe = KnownRecipes.CurrentSelectedRecipe;
        if (HasRequiredIngredients(recipe, amount))
        {
            SendToQueue(recipe, amount);
        }
    }

    public void CraftAll()      //this is for the button
    {
        //craft as many recipe items with the available ingredients

        var recipe = KnownRecipes.CurrentSelectedRecipe;
        CraftAny(GetMaxCraftingAmount(recipe));
    }

    public void StartCrafting()
    {
        KnownRecipes.CurrentlyCraftingRecipe = PeekRecipe().Recipe;
        RecipeQueue.IsCrafting = true;
        StartCoroutine(ProcessRecipeStack());
    }

    public void SendToQueue(Recipe recipe, int amount)
    {
        Debug.Log($"SENDING {recipe.Name} x {amount} TO QUEUE");
        RecipeQueue.AddToQueue(recipe, amount);
        //OnEnqueueRecipe.Raise();

    }

    private bool HasRequiredIngredients(Recipe recipe, int amount)
    {
        foreach (ItemStack ingredient in recipe.Ingredients)
        {
            if (Inventory.HasItem(ingredient.Item))
            {
                if (Inventory.GetAmount(ingredient.Item) < (ingredient.Amount*amount))
                    return false;
                else
                    continue;
            }
            else
                return false;
        }
        return true;
    }

    private void RemoveIngredients(Recipe recipe, int amount)
    {
        foreach (ItemStack ingredient in recipe.Ingredients)
        {
            Inventory.RemoveItem(ingredient.Item, ingredient.Amount*amount);
        }
    }

    private void RemoveIngredients(Recipe recipe)
    {
        foreach (ItemStack ingredient in recipe.Ingredients)
        {
            Inventory.RemoveItem(ingredient.Item, ingredient.Amount);
        }
    }

    private void GiveRecipeResult(Recipe recipe, int amount)
    {
        Inventory.AddItem(recipe.Result.Item, recipe.Result.Amount*amount);
    }

    private void GiveRecipeResult(Recipe recipe)
    {
        Inventory.AddItem(recipe.Result.Item, recipe.Result.Amount);
    }

    private int GetMaxCraftingAmount(Recipe recipe)
    {
        //List<ItemStack> ingredientCounter = new List<ItemStack>();
        List<int> amounts = new List<int>();

        foreach (ItemStack ingredient in recipe.Ingredients)
        {
            if (Inventory.HasItem(ingredient.Item))
            {
                int amt = Inventory.GetAmount(ingredient.Item) / ingredient.Amount;
                amounts.Add(amt);
            }
            else
                return 0;
        }
        amounts.Sort();
        return amounts[0];
    }

    private IEnumerator ProcessRecipeStack()
    {
        var recipe = PeekRecipe();
        while (recipe != null && recipe.Remaining > 0)
        {
            while (recipe.Remaining > 0)
            {
                RecipeQueue.IsCrafting = true;
                float duration = recipe.Recipe.Duration;
                float elapsed = 0;
                while (elapsed < duration)
                {
                    elapsed += Time.deltaTime;
                    recipe.Progress = elapsed/duration;
                    yield return null;
                }
                //StartCoroutine(RecipeTimer());

                yield return null;

                RemoveIngredients(recipe.Recipe);
                GiveRecipeResult(recipe.Recipe);
                recipe.Remaining--;
                OnInventoryChanged.Raise();

                yield return null;
            }

            if (recipe.Remaining < 0)
            {
                recipe.Remaining = 0;
                yield return null;
            }

            if (recipe.Remaining > 0)
            {
                StartCoroutine(ProcessRecipeStack());
            }


            if (recipe.Remaining == 0)
            {
                RecipeQueue.DequeueAndPool();
                KnownRecipes.CurrentlyCraftingRecipe = null;
                OnDequeueRecipe.Raise();
                yield return null;

                if (RecipeQueue.Queue.Count > 0 && PeekRecipe().Recipe != null)
                {
                    StartCrafting();
                }
                yield return null;
            }
        }
    }   

    // private IEnumerator RecipeTimer()
    // {
    //     float duration = PeekRecipe().Recipe.Duration;
    //     float elapsed = 0;
    //     while (elapsed < duration)
    //     {
    //         elapsed += Time.deltaTime;
    //         PeekRecipe().Progress = elapsed/duration;
    //         yield return null;
    //     }
    // }

    public QueuedRecipe PeekRecipe()
    {
        if (RecipeQueue.Queue.Count != 0)
        {
            return RecipeQueue.Queue.Peek();
        }
        else
            return null;
    }

    public void ClearQueue()
    {
        foreach (QueuedRecipe recipe in RecipeQueue.Queue)
        {
            if (recipe != RecipeQueue.Queue.Peek())
            {
                recipe.ClearQueuedRecipe();
            }
            else
                RecipeQueue.Queue.Peek().Remaining = 1;
        }
    }

        //activate bc something is in the queue    
        //take queued item
        //begin crafting queued item (run timer)
        //remove ingredients from inventory
        //give crafted item to inventory
        //remove queued item from queue
        //begin next queued item
        //rinse repeat until there is nothing in queue
}
