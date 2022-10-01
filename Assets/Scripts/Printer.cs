using UnityEngine;

public class Printer : MonoBehaviour, ITagResponse
{
    public ItemSO Item;
    public GameObject Normal;
    public GameObject Broken;

    private GameObject _currentGFX;

    private void Awake()
    {
        foreach (var current in Item.InitialTags)
        {
            Add(current);
        }
    }

    public void Add(Tag tag)
    {
        switch (tag)
        {
            case Tag.Normal:
                ChangeGFX(Normal);
                break;
            
            case Tag.Broken:
                ChangeGFX(Broken);
                break;
            
            default:
                break;
        }
    }

    public void Remove(Tag tag)
    {

    }

    public void ChangeGFX(GameObject original)
    {
        if (_currentGFX)
        {
            Destroy(_currentGFX);
        }

        _currentGFX = Instantiate(original, transform);
    }
}
