using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    public Image SpriteContainer;

    public void Load(Sprite sprite)
    {
        SpriteContainer.sprite = sprite;
        SpriteContainer.color = new Color(1f, 1f, 1f, 1f);
    }
    
    public void Empty()
    {
        SpriteContainer.sprite = null;
        SpriteContainer.color = new Color(0f, 0f, 0f, 0f);
    }
}
