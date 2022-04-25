using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Recipes Database", menuName = "Crafting System/Recipes Database")]
public class RecipesDatabase : ScriptableObject
{
    public Recipe CurrentSelectedRecipe;

    public List<Recipe> AvailableRecipes;
}
