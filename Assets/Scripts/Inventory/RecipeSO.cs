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

public struct UseItem
{
    public ItemSO Item;
    public List<Tag> AddedTags;
    public List<Tag> RemoveTags;
}

[CreateAssetMenu(fileName = "New Recipe", menuName = "Gamagora/Recipe")]
public class RecipeSO : ScriptableObject
{
    public List<UseItem> Ingredients = new List<UseItem>();
}
