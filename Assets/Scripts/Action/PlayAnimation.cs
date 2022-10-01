using System;
using UnityEngine;

public class PrinterDoor : MonoBehaviour
{
    public GameObject Door;
    private bool bOpen = false;
    
    private void OnMouseUp()
    {
        bOpen = !bOpen;

        if (bOpen)
        {
            Debug.Log("Open");
        }
        else
        {
            Debug.Log("Close");
        }
    }
}
