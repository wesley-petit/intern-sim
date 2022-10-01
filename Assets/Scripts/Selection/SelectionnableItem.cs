using UnityEngine;

public class SelectionnableItem : MonoBehaviour
{
    private ItemContainer _itemContainer;
    private SelectionController _selectionController;

    private void Awake()
    {
        _itemContainer = GetComponent<ItemContainer>();
        _selectionController = FindObjectOfType<SelectionController>();
    }

    private void OnMouseUp()
    {
        ItemSO item = _itemContainer.GetItem();
        item.Container = _itemContainer;
        _selectionController.OnClick(item);
    }
}
