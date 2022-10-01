using UnityEngine;

public class SelectionnableItem : MonoBehaviour
{
    public ItemSO Item;

    private SelectionController _selectionController = null;

    private void Awake() => _selectionController = FindObjectOfType<SelectionController>();
    private void OnMouseUp()
    {
        Item.Container = GetComponent<ITagResponse>();
        _selectionController.OnClick(Item);
    }
}
