using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Random = UnityEngine.Random;

public class TaskManager : MonoBehaviour
{
    public UnityEvent<TaskSO> OnCreateTask = null;
    public UnityEvent<TaskSO> OnCompleteTask = null;
    public TaskRefiller TaskRefiller;

    private List<TaskSO> Tasks = new List<TaskSO>();
    private List<TaskSO> ActiveTasks = new List<TaskSO>();

    public int MaxTaskAccepted = 6;
    public UnityEvent OnWin;
    public UnityEvent OnLose;

    private void Awake() => CreateTasks();

    public void CreateTasks()
    {
        for (int i = 0; i < 2; i++)
        {
            if (Tasks.Count <= 0)
            {
                Tasks = TaskRefiller.Refill();
            }
            if (Tasks.Count <= 0)
            {
                Debug.Log("Win");
                OnWin?.Invoke();
                return;
            }

            if (ActiveTasks.Count == MaxTaskAccepted)
            {
                Debug.Log("Lose");
                OnLose?.Invoke();
                return;
            }
            
            // List<TaskSO> taskAvailable = new List<TaskSO>();
            // foreach (var taskSO in Tasks)
            // {
            //     if (ActiveTasks.Contains(taskSO)) { continue; }
            //     taskAvailable.Add(taskSO);
            // }
            //
            // if (taskAvailable.Count <= 0)
            // {
            //     Debug.LogError("No more task available");
            //     return;
            // }

            // int rand = Random.Range(0, taskAvailable.Count);
            // newTask = taskAvailable[rand];
            TaskSO newTask = Tasks[0];
            Tasks.Remove(newTask);
            ActiveTasks.Add(newTask);
            OnCreateTask?.Invoke(newTask);
        }
    }

    public void CheckCompleteTask(RecipeSO recipe)
    {
        TaskSO completeTask = GetCompleteTaskFor(recipe);

        if (completeTask != null)
        {
            ActiveTasks.Remove(completeTask);
            OnCompleteTask?.Invoke(completeTask);
        }
    }

    private TaskSO GetCompleteTaskFor(RecipeSO recipe)
    {
        TaskSO completeTask = null;

        for (int i = 0; i < ActiveTasks.Count; i++)
        {
            if (ActiveTasks[i].Condition == recipe)
            {
                completeTask = ActiveTasks[i];
                break;
            }
        }

        return completeTask;
    }
}
