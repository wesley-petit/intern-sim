using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TaskManager : MonoBehaviour
{
    public UnityEvent<TaskSO> OnCreateTask = null;
    public UnityEvent<TaskSO> OnCompleteTask = null;
    public TaskRefiller TaskRefiller;

    private List<TaskSO> Tasks = new List<TaskSO>();
    private List<TaskSO> ActiveTasks = new List<TaskSO>();

    public void CreateTask()
    {
        TaskSO newTask;

        if (ActiveTasks.Count <= 0)
        {
            ActiveTasks = TaskRefiller.Refill();
        }
        
        List<TaskSO> taskAvailable = new List<TaskSO>();
        foreach (var taskSO in Tasks)
        {
            if (ActiveTasks.Contains(taskSO)) { continue; }
            taskAvailable.Add(taskSO);
        }

        if (taskAvailable.Count <= 0)
        {
            Debug.LogError("No more task available");
            return;
        }

        int rand = Random.Range(0, taskAvailable.Count);
        newTask = taskAvailable[rand];

        Tasks.Remove(newTask);
        ActiveTasks.Add(newTask);
        OnCreateTask?.Invoke(newTask);
    }

    public void CheckCompleteTask(RecipeSO recipe)
    {
        TaskSO completeTask = GetCompleTaskFor(recipe);

        if (completeTask != null)
        {
            ActiveTasks.Remove(completeTask);
            OnCompleteTask?.Invoke(completeTask);
        }
    }

    private TaskSO GetCompleTaskFor(RecipeSO recipe)
    {
        TaskSO completeTask = null;

        for (int i = 0; i < ActiveTasks.Count; i++)
        {
            if (ActiveTasks[i].Conditions == recipe)
            {
                completeTask = ActiveTasks[i];
                break;
            }
        }

        return completeTask;
    }
}
