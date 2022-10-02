using UnityEngine;
using TMPro;

public class TaskUI : MonoBehaviour
{
    public TextMeshProUGUI TaskTextContainer;

    public void SetTask(TaskSO taskSO)
    {
        TaskTextContainer.SetText(taskSO.Description);
    }

    public void Complete()
    {
        //Debug.LogError("Task UI Complete !");
        Destroy(gameObject);
    }
}
