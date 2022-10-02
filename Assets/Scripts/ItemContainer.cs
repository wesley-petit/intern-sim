using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ItemContainer : MonoBehaviour
{
    public ItemSO Item;
    public UnityEvent<HashSet<State>> OnChangeState = null;

    private HashSet<State> AllStates = new HashSet<State>();
    private GameObject _currentGfx;

    private void Awake() => Load(Item);

    public void Load(ItemSO newItem)
    {
        CleanUpState(Item, newItem);
        Item = newItem;
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

        OnChangeState.Invoke(AllStates);
    }
}
