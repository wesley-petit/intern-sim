using UnityEngine;

public class MeshModifier : MonoBehaviour, ITagResponse
{
    public Tag Tag;
    public MeshFilter MeshFilter;
    public Mesh NewMesh;

    public void Add(Tag tag)
    {
        if(tag == Tag)
        {
            Modify();
        }
    }

    public void Modify()
    {
        MeshFilter.mesh = NewMesh;
    }

    public void Remove(Tag tag)
    {
    }
}
