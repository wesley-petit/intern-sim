using System;
using System.Collections.Generic;
using UnityEngine;

public class TaskRefiller : MonoBehaviour
{
    public List<TaskSO> Tutorial = new List<TaskSO>();
    public List<TaskSO> Normal = new List<TaskSO>();
    public List<TaskSO> Absurd = new List<TaskSO>();

    private List<TaskSO> Combine = new List<TaskSO>();
    public int Round = 0;
    //
    // private void Awake()
    // {
    //     foreach (var temp in Absurd)
    //         Combine.Add(temp);
    //     
    //     foreach (var temp in Normal)
    //         Combine.Add(temp);
    // }

    public List<TaskSO> Refill()
    {
        Round++;
        if (Round < 2)
        {
            return Tutorial;
        }
        else if (Round == 2)
        {
            return Normal;
        }
        else if (Round == 3)
        {
            return Absurd;
        }
        else
        {
            return new List<TaskSO>();
        }
    }
}
