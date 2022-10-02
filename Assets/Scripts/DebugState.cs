using UnityEngine;

public class DebugState : MonoBehaviour
{
    public Animator animator;

    public State state;
    public State previousState;
    public void OnMouseUp()
    {
        if (previousState != State.None)
        {
            animator.ResetTrigger(previousState.ToString());
        }
        Debug.Log(state);
        animator.SetTrigger(state.ToString());
        previousState = state;
    }
}
