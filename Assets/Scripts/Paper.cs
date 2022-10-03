using System;
using UnityEngine;
using System.Collections.Generic;

public class Paper : MonoBehaviour
{
    public ItemContainer ItemContainer;
    public ItemSO PaperSo;
    public GameObject WritenText;
    public GameObject Stamped;
    public GameObject Coffee;
    
    public Transform Origin1;
    public Transform Origin2;

    private List<GameObject> AllClones = new();

    public void OnChangeState(HashSet<State> States)
    {
        ItemContainer.Item = PaperSo;
        
        while (AllClones.Count != 0)
        {
            Destroy(AllClones[0]);
            AllClones.RemoveAt(0);
        }

        foreach (var state in States)
        {
            GameObject original = null;
            Transform parent = null;
            Vector3 position = Vector3.zero;
            switch (state)
            {
                case State.Dirty:
                    original = Coffee;
                    parent = Origin1;
                    // position = Origin1.position;
                    break;
                case State.Scanned:
                    original = WritenText;
                    parent = Origin1;
                    // position = Origin1.position;
                    break;
                case State.Writed:
                    original = WritenText;
                    parent = Origin1;
                    // position = Origin1.position;
                    break;
                case State.Stamped:
                    original = Stamped;
                    parent = Origin2;
                    // position = Origin2.position;
                    break;
            }

            if (original != null)
            {
                var clone = Instantiate(original, position, Quaternion.identity, parent);
                clone.transform.localPosition = Vector3.zero;
                clone.transform.localRotation = Quaternion.identity;
                AllClones.Add(clone);
            }
        }
    }
}
