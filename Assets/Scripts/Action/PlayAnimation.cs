using UnityEngine;

public class PlayAnimation : MonoBehaviour
{
    public Animator Animator;
    public Outline Outline;

    private bool bOpen = false;

    private void Awake()
    {
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
        bOpen = !bOpen;

        if (bOpen)
        {
            Animator.SetBool("Open", bOpen);
            Destroy(Outline);
            Destroy(GetComponent<Collider>());
            Destroy(this);
        }
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
