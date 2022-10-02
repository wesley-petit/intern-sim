using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TaskManager : MonoBehaviour
{
    public List<TaskSO> Tasks = new List<TaskSO>();
    private List<TaskSO> ActualTasks = new List<TaskSO>();

    public UnityEvent<TaskSO> OnCreateTask = null;
    public UnityEvent<TaskSO> OnCompleteTask = null;

    public void CreateTask()
    {
        TaskSO newTask;

        List<TaskSO> taskAvailable = new List<TaskSO>();
        foreach (var taskSO in Tasks)
        {
            if (ActualTasks.Contains(taskSO)) { continue; }
            taskAvailable.Add(taskSO);
        }

        if (taskAvailable.Count <= 0)
        {
            Debug.LogError("No more task available");
            return;
        }

        int rand = Random.Range(0, taskAvailable.Count);
        newTask = taskAvailable[rand];

        ActualTasks.Add(newTask);
        OnCreateTask?.Invoke(newTask);
    }

    public void CheckCompleteTask(RecipeSO recipe)
    {
        TaskSO completeTask = GetCompleTaskFor(recipe);

        if (completeTask != null)
        {
            ActualTasks.Remove(completeTask);
            OnCompleteTask?.Invoke(completeTask);
        }
    }

    private TaskSO GetCompleTaskFor(RecipeSO recipe)
    {
        TaskSO completeTask = null;

        for (int i = 0; i < ActualTasks.Count; i++)
        {
            if (ActualTasks[i].Conditions == recipe)
            {
                completeTask = ActualTasks[i];
                break;
            }
        }

        return completeTask;
    }
}
