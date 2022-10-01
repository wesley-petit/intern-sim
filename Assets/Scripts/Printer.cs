using UnityEngine;

public class Printer : MonoBehaviour, ITagResponse
{
    public ItemSO Item;
    public MeshFilter MeshFilter;

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

                break;
            case Tag.Broken:
                break;
            case Tag.Empty:
                break;
            case Tag.Full:
                break;
            default:
                break;
        }
    }

    public void Remove(Tag tag)
    {

    }
}
