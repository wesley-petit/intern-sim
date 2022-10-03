using System;
using System.Collections.Generic;
using UnityEngine;

public class TaskRefiller : MonoBehaviour
{
    public List<TaskSO> Tutorial = new List<TaskSO>();
    public List<TaskSO> Normal = new List<TaskSO>();
    public List<TaskSO> Absurd = new List<TaskSO>();

    private List<TaskSO> Combine = new List<TaskSO>();
    private int round = 0;

    private void Awake()
    {
        foreach (var temp in Absurd)
            Combine.Add(temp);
        
        foreach (var temp in Normal)
            Combine.Add(temp);
    }

    public List<TaskSO> Refill()
    {
        round++;

        if (round < 2)
        {
            return Tutorial;
        }
        else if (round == 3)
        {
            return Normal;
        }
        else if (round == 4)
        {
            return Absurd;
        }
        else
        {
            return Combine;
        }
    }
}
