using System.Collections.Generic;
using UnityEngine;

public class PlayAnimState : MonoBehaviour
{
    public Animator animator;
    public State[] ValidStates;

    private State previousState = State.None;

    public void OnChangeState(HashSet<State> states)
    {
        foreach (var current in ValidStates)
        {
            if (states.Contains(current) && previousState != current)
            {
                animator.SetTrigger(current.ToString());
                previousState = current;
                break;
            }
        }
    }
}
