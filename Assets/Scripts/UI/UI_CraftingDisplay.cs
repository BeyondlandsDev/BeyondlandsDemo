using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_CraftingDisplay : MonoBehaviour
{
    public RecipesDatabase PlayerRecipes;
    public CraftingQueue RecipeQueue;
    public Sprite DefaultIcon;

    [Header("Recipe List")]
    [SerializeField] private GridLayoutGroup recipesButtonGroup; 
    [SerializeField] private RecipeSelectButton recipeSelectButton;

    [SerializeField] private List<RecipeSelectButton> recipeButtons;

    [Header("Recipe Inspect & Ingredients")]
    [SerializeField] private RecipeInspectDisplay recipeInspectDisplay;
    [SerializeField] private GridLayoutGroup ingredientsListGroup;
    [SerializeField] private RecipeIngredientIcon ingredientIconPrefab;
    [SerializeField] private List<RecipeIngredientIcon> ingredientIconsList;

    [Header("Recipe Queue")]
    [SerializeField] private GridLayoutGroup queuedRecipesGroup;
    [SerializeField] private QueuedRecipeIcon queuedRecipeIconPrefab;
    [SerializeField] private List<QueuedRecipeIcon> queuedRecipeIconList;
    [SerializeField] private Stack<QueuedRecipeIcon> unusedQueuedRecipeIcons;

    [Header("Crafting Buttons")]
    [SerializeField] private Button craftOneButton;
    [SerializeField] private Button craftAllButton;
    [SerializeField] private Button craftFiveButton;
    [SerializeField] private Button clearQueueButton;

    private void Awake()
    {
        FillRecipeList();
        ClearRecipeInspectDisplay();
        CreateQueueDisplay();
    }

    private void OnEnable()
    {
        ClearRecipeInspectDisplay();
        ActivateCraftingButtons();
        UpdateQueueDisplay();
    }

    private void Update()
    {
        //CheckQueue();
        UpdateQueueDisplay();
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
            clearQueueButton.enabled = true;
            // ButtonEnable(craftOneButton);
            // ButtonEnable(craftAllButton);
            // ButtonEnable(craftFiveButton);
        }
        else
        {
            craftOneButton.enabled = false;
            craftAllButton.enabled = false;
            craftFiveButton.enabled = false;
            clearQueueButton.enabled = false;
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

    private void CreateQueueDisplay()
    {
        for (int i = 0; i < 5; i++)
        {
            queuedRecipeIconList.Add(Instantiate(queuedRecipeIconPrefab, queuedRecipesGroup.transform));
            //queuedRecipeIconList[i].gameObject.SetActive(false);
        }
    }

    public void UpdateQueueDisplay()
    {
        ClearQueueDisplay();

        if (RecipeQueue.Queue.Count > 0)
        {
            int i = 0;
            foreach (QueuedRecipe recipe in RecipeQueue.Queue)
            {
                if (recipe.Remaining > 0)
                {
                    queuedRecipeIconList[i].Icon.sprite = recipe.Recipe.Result.Item.Icon;
                    queuedRecipeIconList[i].AmountText.text = recipe.Remaining.ToString(); //CHECK IF REMAINING OR AMOUNT
                    queuedRecipeIconList[i].ProgressBar.fillAmount = Mathf.Lerp(1f, 0f, recipe.Progress);
                    queuedRecipeIconList[i].gameObject.SetActive(true);
                    i++;
                }
            }
        }
        else
        {
            ClearQueueDisplay();
        }
    }

    public void ClearQueueDisplay()
    {
        foreach (QueuedRecipeIcon icon in queuedRecipeIconList)
        {
            ClearQueueIcon(icon);
        }
    }

    public void ClearQueueIcon(QueuedRecipeIcon icon)
    {
        icon.Icon.sprite = DefaultIcon;
        icon.AmountText.text = ""; //CHECK IF REMAINING OR AMOUNT
        icon.ProgressBar.fillAmount = 0f;
        icon.gameObject.SetActive(false);
    }

    public void RemoveDequeuedRecipeIcon()
    {
        queuedRecipeIconList[0].gameObject.SetActive(false);
    }

    private void CheckQueue()
    {
        if (RecipeQueue.Queue.Count > 0)
            UpdateQueueDisplay();
    }
}
