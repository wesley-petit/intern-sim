using UnityEngine;

public class TurnOn : MonoBehaviour
{
    public MonoBehaviour[] ComponentsOff;

    private void Awake()
    {
        foreach (var current in ComponentsOff)
            current.enabled = false;
    }

    private void OnMouseUp()
    {
        foreach (var current in ComponentsOff)
            current.enabled = true;
        
        Destroy(this);
    }
}
