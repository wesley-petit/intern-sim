using UnityEngine;
using System.Collections.Generic;
using UnityEngine.Events;

public class Inventory : MonoBehaviour
{
    public static Inventory playerInventory;

    public List<ItemSO> Items = new List<ItemSO>();
    public UnityEvent OnAdd;
    public UnityEvent OnRemove;

    private const int CAPACITY = 2;

    private void Awake() => playerInventory = this;

    public bool Contains(ItemSO item) => Items.Contains(item);
    public bool IsFull() => Items.Count == CAPACITY;

    public void Add(ItemSO item)
    {
        if (Items.Contains(item))
        {
            Debug.LogWarning($"Item {item.Name} is already present.");
            return;
        }

        Items.Add(item);
        OnAdd?.Invoke();
    }

    public void Remove(ItemSO item)
    {
        if (!Items.Contains(item))
        {
            Debug.LogWarning($"Ask to remove {item.Name}, but it wasn't present in the inventory.");
            return;
        }

        Items.Remove(item);
        OnRemove?.Invoke();
    }

    public void Empty()
    {
        Items.Clear();
        OnRemove?.Invoke();
    }
}
