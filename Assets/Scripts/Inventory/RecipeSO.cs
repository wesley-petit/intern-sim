using UnityEngine;
using System.Collections.Generic;

public enum Tag
{
    None,
    Normal,
    Broken,
    Empty,
    Full
}

[System.Serializable]
public struct UseItem
{
    public ItemSO Item;
    public Tag AddedTag;
    public Tag RemoveTag;
}

[CreateAssetMenu(fileName = "New Recipe", menuName = "Gamagora/Recipe")]
public class RecipeSO : ScriptableObject
{
    public List<UseItem> Ingredients = new List<UseItem>();
}
