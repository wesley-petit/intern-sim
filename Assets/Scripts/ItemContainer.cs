using UnityEngine;

public struct ItemContainer
{
    public ItemSO Item;
    public GameObject Container;

    public ItemContainer(ItemSO item, GameObject container)
    {
        Item = item;
        Container = container;
    }
}
