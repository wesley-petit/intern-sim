using System;
using UnityEngine;

public class CoffeeButton : MonoBehaviour
{
    public ItemContainer CoffeMachine;
    public ItemSO FullCoffee;
    
    private void OnMouseUp()
    {
        if (CoffeMachine.Item != FullCoffee)
        {
            CoffeMachine.Load(FullCoffee);
        }
    }
}
