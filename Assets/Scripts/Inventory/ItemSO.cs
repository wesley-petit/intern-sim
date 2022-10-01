using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "New Item", menuName = "Gamagora/Item")]
public class ItemSO : ScriptableObject
{
    public string Name;
    public Image Sprite;
}
