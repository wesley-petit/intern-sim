using System;
using UnityEngine;

public class SelectionnableItem : MonoBehaviour
{
    public Outline Outline;

    private ItemContainer _itemContainer;
    private SelectionController _selectionController;

    private void Awake()
    {
        _itemContainer = GetComponent<ItemContainer>();
        _selectionController = FindObjectOfType<SelectionController>();
        if (Outline)
        {
            Outline.enabled = false;
        }
    }

    private void OnMouseEnter()
    {
        if (Outline)
        {
            Outline.enabled = true;
        }
        // Cursor.visible = false;
    }

    private void OnMouseExit()
    {
        if (Outline)
        {
            Outline.enabled = false;
        }
        // Cursor.visible = true;
    }

    private void OnMouseUp()
    {
        ItemSO item = _itemContainer.GetItem();
        item.Container = _itemContainer;
        _selectionController.OnClick(item);
    }
}
