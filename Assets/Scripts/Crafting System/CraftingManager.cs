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
}
