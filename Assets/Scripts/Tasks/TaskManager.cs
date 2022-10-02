using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TaskManager : MonoBehaviour
{
    public List<TaskSO> TaskAvailable = new List<TaskSO>();
    private List<TaskSO> ActualTasks = new List<TaskSO>();

    public UnityEvent<TaskSO> OnCreateTask = null;
    public UnityEvent<TaskSO> OnCompleteTask = null;

    private void Start()
    {
        CreateTask();
    }

    public void CreateTask()
    {
        TaskSO newTask;

        do
        {
            int rand = Random.Range(0, TaskAvailable.Count);
            newTask = TaskAvailable[rand];
        }
        while (ActualTasks.Contains(newTask));

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
