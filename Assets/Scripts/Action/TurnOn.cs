using System;
using UnityEngine;
using UnityEngine.Events;

public class TurnOn : MonoBehaviour
{
    public UnityEvent<bool> OnTurn;
    public Renderer Renderer;
    public Material OnMaterial;
    
    private void Awake()
    {
        OnTurn?.Invoke(false);
    }

    private void OnMouseUp()
    {
        OnTurn?.Invoke(true);
        Renderer.material = OnMaterial;
        
        if (GetComponent<Outline>())
        {
            Destroy(GetComponent<Outline>());
        }
        Destroy(GetComponent<Collider>());
        Destroy(this);
    }
}
