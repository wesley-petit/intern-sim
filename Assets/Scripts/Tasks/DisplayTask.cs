using UnityEngine;
using System.Collections.Generic;

public class DisplayTask : MonoBehaviour
{
    public TaskUI Original;
    public Transform Parent;

    private Dictionary<TaskSO, TaskUI> taskUiByTask = new Dictionary<TaskSO, TaskUI>();

    public void Create(TaskSO taskSO)
    {
        if (taskUiByTask.ContainsKey(taskSO))
        {
            Debug.LogError("Task is already present and display. Can't process...");
            return;
        }

        TaskUI clone = Instantiate(Original, Parent);
        clone.SetTask(taskSO);
        taskUiByTask.Add(taskSO, clone);
    }

    public void Complete(TaskSO taskSO)
    {
        if (!taskUiByTask.TryGetValue(taskSO, out TaskUI taskUI))
        {
            Debug.LogError($"Task {taskSO.Description} has been completed, but it wasn't display");
            return;
        }

        taskUI.Complete();
        taskUiByTask.Remove(taskSO);
    }
}
