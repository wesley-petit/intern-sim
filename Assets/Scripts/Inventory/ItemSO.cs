using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "New Item", menuName = "Gamagora/Item")]
public class ItemSO : ScriptableObject
{
    public string Name;
    public Image Sprite;
    public ITagResponse Container;
    public List<Tag> InitialTags = new List<Tag>();
}
