using UnityEngine;
using System.Collections.Generic;

public enum State
{
    None,
    Normal,
    Broken,
    Empty,
    Full
}

[System.Serializable]
public struct ItemTransformation
{
    public ItemSO ItemIn;
    public ItemSO ItemOut;
}

[CreateAssetMenu(fileName = "New Recipe", menuName = "Gamagora/Recipe")]
public class RecipeSO : ScriptableObject
{
    public List<ItemTransformation> Ingredients = new();
}
