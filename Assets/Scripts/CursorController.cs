using UnityEngine;

public class CursorController : MonoBehaviour
{
    public static CursorController Instance;
    public Texture2D Normal;
    public Texture2D Hand;
    public Texture2D GrapHand;

    private void Awake()
    {
        Cursor.visible = true;
        Instance = this;
        ShowNormal();
    }

    private Vector2 HotspotPosition = new Vector2(256, 256);
    public void ShowNormal()
    {
        Cursor.SetCursor(Normal, HotspotPosition, CursorMode.Auto);
    }
    
    public void ShowHand()
    {
        Cursor.SetCursor(Hand, HotspotPosition, CursorMode.Auto);
    }

    public void ShowGrapHand()
    {
        Cursor.SetCursor(GrapHand, HotspotPosition, CursorMode.Auto);
    }
}
