using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_CraftingDisplay : MonoBehaviour
{
    public RecipesDatabase PlayerRecipes;
    public Sprite DefaultIcon;

    [Header("Crafting Menu")]
    [SerializeField] private GridLayoutGroup recipesButtonGroup; 
    [SerializeField] private RecipeSelectButton recipeSelectButton;

    [SerializeField] private List<RecipeSelectButton> recipeButtons;

    [SerializeField] private RecipeInspectDisplay recipeInspectDisplay;
    [SerializeField] private GridLayoutGroup ingredientsListGroup;
    [SerializeField] private RecipeIngredientIcon ingredientIconPrefab;
    [SerializeField] private List<RecipeIngredientIcon> ingredientIconsList;

    private void Awake()
    {
        FillRecipeList();
        ClearRecipeInspectDisplay();
    }

    private void OnEnable()
    {
        ClearRecipeInspectDisplay();
        //ClearIngredientsList();
    }

    // private void OnDisable()
    // {
    //     ClearRecipeInspectDisplay();
    // }

    public void FillRecipeList()
    {
        foreach (Recipe recipe in PlayerRecipes.AvailableRecipes)
        {
            //recipeButtons.Add(Instantiate(recipeSelectButton, recipesButtonGroup.transform));
            var button = Instantiate(recipeSelectButton, recipesButtonGroup.transform);
            button.Icon.sprite = recipe.Result.Item.Icon;
            button.RecipeNameText.text = recipe.Name;
            button.Recipe = recipe;
        }
    }

    public void ClearRecipeInspectDisplay()
    {
        recipeInspectDisplay.Icon.sprite = DefaultIcon;
        recipeInspectDisplay.RecipeNameText.text = "";
        recipeInspectDisplay.DescriptionText.text = "";
        ClearIngredientsList();
        PlayerRecipes.CurrentSelectedRecipe = null;
    }

    public void FillRecipeInspectDisplay(Recipe recipe)
    {
        ClearIngredientsList();
        recipeInspectDisplay.Icon.sprite = recipe.Result.Item.Icon;
        recipeInspectDisplay.RecipeNameText.text = recipe.Name;
        recipeInspectDisplay.DescriptionText.text = recipe.Result.Item.Description;
        GenerateIngredientIcons(recipe);
        FillIngredientIcons(recipe);
    }

    public void GenerateIngredientIcons(Recipe recipe)
    {
        foreach (ItemStack ingredient in recipe.Ingredients)
        {
            ingredientIconsList.Add(Instantiate(ingredientIconPrefab, ingredientsListGroup.transform));
        }
    }

    public void FillIngredientIcons(Recipe recipe)
    {
        for (int i = 0; i < ingredientIconsList.Count; i++)
        {
            ingredientIconsList[i].Icon.sprite = recipe.Ingredients[i].Item.Icon;
            ingredientIconsList[i].AmountText.text = "x"+recipe.Ingredients[i].Amount.ToString();
        }
    }

    public void ClearIngredientsList()
    {
        for (int i = 0; i < ingredientIconsList.Count; i++)
        {
            DestroyImmediate(ingredientIconsList[i].gameObject);
            //ingredientIconsList.RemoveAt(i);
        }
        ingredientIconsList.Clear();
    }

    public void ActivateCraftingButtons()
    {

    }
}
