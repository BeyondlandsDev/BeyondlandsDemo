using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class RecipeSelectButton : MonoBehaviour
{
    public Image Icon;
    public TextMeshProUGUI RecipeNameText;
    public Recipe Recipe; //????????
    public UI_CraftingDisplay UI;

    private void Awake()
    {
        UI = GetComponentInParent<UI_CraftingDisplay>();
    }

    public void ButtonClick()
    {
        UI.PlayerRecipes.CurrentSelectedRecipe = Recipe;
        UI.FillRecipeInspectDisplay(UI.PlayerRecipes.CurrentSelectedRecipe);
    }
}
