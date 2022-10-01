using UnityEngine;
using System.Collections.Generic;
using UnityEngine.Events;

public class Inventory : MonoBehaviour
{
    public static Inventory playerInventory = null;

    public List<ItemSO> Items = new List<ItemSO>();

    public UnityEvent OnAdd = null;
    public UnityEvent OnRemove = null;

    private void Awake() => playerInventory = this;

    public bool Contains(ItemSO itemSo) => Items.Contains(itemSo);

    public void Add(ItemSO itemSo)
    {
        if (Items.Contains(itemSo))
        {
            Debug.LogWarning($"Item {itemSo.name} is already present.");
            return;
        }

        Items.Add(itemSo);
        OnAdd?.Invoke();
    }

    public void Remove(ItemSO itemSo)
    {
        if (!Items.Contains(itemSo))
        {
            Debug.LogWarning($"Ask to remove {itemSo.name}, but it wasn't present in the inventory.");
            return;
        }

        Items.Remove(itemSo);
        OnRemove?.Invoke();
    }
}
