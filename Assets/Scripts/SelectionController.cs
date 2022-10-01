using UnityEngine;

public class SelectionController : MonoBehaviour
{
    public void OnClick(ItemSO item)
    {
        if (!Inventory.playerInventory.Contains(item))
        {
            Debug.Log(item.name + " has been selected.");
            Inventory.playerInventory.Add(item);
        }
        else
        {
            Debug.Log(item.name + " has been deselected.");
            Inventory.playerInventory.Remove(item);
        }
    }
}
