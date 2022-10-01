using System.Collections.Generic;
using UnityEngine;

public class ItemContainer : MonoBehaviour
{
    public ItemSO Item;

    private HashSet<State> AllStates = new();
    private GameObject _currentGfx;

    private void Awake() => Load(Item);

    public void Load(ItemSO newItem)
    {
        CleanUpState(Item, newItem);
        Item = newItem;
        UpdateGfx(Item.Model);
    }

    public ItemSO GetItem() => Item;

    private void CleanUpState(ItemSO oldItem, ItemSO newItem)
    {
        if (oldItem)
        {
            foreach (var oldState in oldItem.InitialState)
                AllStates.Remove(oldState);
        }

        foreach (var newState in newItem.InitialState)
            AllStates.Add(newState);
    }
    
    private void UpdateGfx(GameObject original)
    {
        if (_currentGfx)
        {
            Destroy(_currentGfx);
        }

        _currentGfx = Instantiate(original, transform);
    }
}
