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

    [SerializeField] private Button craftOneButton;
    [SerializeField] private Button craftAllButton;
    [SerializeField] private Button craftFiveButton;

    // [Header("Crafting Buttons On/Off")]
    // [SerializeField] private bool canCraftOne;
    // [SerializeField] private bool canCraftFive;
    // [SerializeField] private bool canCraftAll;

    private void Awake()
    {
        FillRecipeList();
        ClearRecipeInspectDisplay();
    }

    private void OnEnable()
    {
        ClearRecipeInspectDisplay();
        ActivateCraftingButtons();
    }

    public void FillRecipeList()
    {
        foreach (Recipe recipe in PlayerRecipes.AvailableRecipes)
        {
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
        ActivateCraftingButtons();
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
            ingredientIconsList[i].gameObject.SetActive(false);
            Destroy(ingredientIconsList[i].gameObject);
        }
        ingredientIconsList.Clear();
    }

    public void ActivateCraftingButtons()
    {
        if (PlayerRecipes.CurrentSelectedRecipe != null)
        {
            craftOneButton.enabled = true;
            craftAllButton.enabled = true;
            craftFiveButton.enabled = true;
            // ButtonEnable(craftOneButton);
            // ButtonEnable(craftAllButton);
            // ButtonEnable(craftFiveButton);
        }
        else
        {
            craftOneButton.enabled = false;
            craftAllButton.enabled = false;
            craftFiveButton.enabled = false;
            // ButtonDisable(craftOneButton);
            // ButtonDisable(craftAllButton);
            // ButtonDisable(craftFiveButton);
        }
    }

    private void ButtonEnable(Button button)
    {
        var text = button.GetComponentInChildren<Text>();
        text.color = Color.black;
        button.enabled = true;
    }

    private void ButtonDisable(Button button)
    {
        var text = button.GetComponentInChildren<Text>();
        text.color = Color.grey;
        button.enabled = false;
    }
}
