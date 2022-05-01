using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Crafting Recipe", menuName = "Crafting System/New Recipe")]
public class Recipe : ScriptableObject
{
    public string Name;

    public List<ItemStack> Ingredients;

    public ItemStack Result;

    public float Duration;
}
