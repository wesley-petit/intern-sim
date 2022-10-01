using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "New Item", menuName = "Gamagora/Item")]
public class ItemSO : ScriptableObject
{
    public string Name;
    public GameObject Model;
    public Sprite Sprite;
    public List<State> InitialState = new();

    [HideInInspector] public ItemContainer Container;
}
