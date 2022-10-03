using System;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    public InventorySlot[] slots = Array.Empty<InventorySlot>();

    public void Refresh()
    {
        int slotIndex = 0;
        foreach (var item in Inventory.playerInventory.Items)
        {
            if (slots.Length - 1 < slotIndex)
            {
                Debug.LogError("No more slots available.");
                break;
            }
            
            slots[slotIndex].Load(item.Sprite);
            slotIndex++;
        }

        while (slotIndex < slots.Length)
        {
            slots[slotIndex].Empty();
            slotIndex++;
        }
    }
}
