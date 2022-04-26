using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraftingManager : MonoBehaviour
{
    public Inventory Inventory;
    public RecipesDatabase KnownRecipes;

    private void Awake()
    {
        Inventory = GetComponentInParent<PlayerController>().Player.Inventory;
        KnownRecipes = GetComponentInParent<PlayerController>().Player.KnownRecipes;
    }

    public void Craft(int amount)
    {
        //Debug.Log(amount);
        var recipe = KnownRecipes.CurrentSelectedRecipe;
        if (HasRequiredIngredients(recipe, amount))
        {
            //add to queue
            //start timer
            RemoveIngredients(recipe, amount);
            GiveRecipeResult(recipe, amount);
        }
    }

    public void CraftAll()
    {
        //craft as many recipe items with the available ingredients
        var recipe = KnownRecipes.CurrentSelectedRecipe;
        Debug.Log(GetMaxCraftingAmount(recipe));

        Craft(GetMaxCraftingAmount(recipe));
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

    private void GiveRecipeResult(Recipe recipe, int amount)
    {
        Inventory.AddItem(recipe.Result.Item, recipe.Result.Amount*amount);
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

    // public void OnRecipeSelectClick(Recipe recipe)
    // {
    //     if (HasRequiredIngredients(recipe, 1))

    // }
}
