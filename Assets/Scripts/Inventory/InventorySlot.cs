using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    public Image Image;

    public void Load(Sprite sprite)
    {
        Image.sprite = sprite;
        Image.color = new Color(1f, 1f, 1f, 1f);
    }
    
    public void Empty()
    {
        Image.sprite = null;
        Image.color = new Color(0f, 0f, 0f, 0f);
    }
}
