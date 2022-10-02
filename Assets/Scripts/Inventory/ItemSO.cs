using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "New Item", menuName = "Gamagora/Item")]
public class ItemSO : ScriptableObject
{
    public string Name;
    public Sprite Sprite;
    public List<State> InitialState = new List<State>();

    [HideInInspector] public ItemContainer Container;
}
