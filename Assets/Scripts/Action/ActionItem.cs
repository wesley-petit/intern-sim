using UnityEngine;

public class ActionItem : MonoBehaviour
{
    public Outline Outline;
    public TaskManager TaskManager;
    public RecipeSO Recipe;
    
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
        CursorController.Instance.ShowHand();
    }

    private void OnMouseDown()
    {
        CursorController.Instance.ShowGrapHand();
    }

    private void OnMouseUp()
    {
        CursorController.Instance.ShowHand();
        TaskManager.CheckCompleteTask(Recipe);
    }
    
    private void OnMouseExit()
    {
        if (Outline)
        {
            Outline.enabled = false;
        }
        CursorController.Instance.ShowNormal();
    }
}
