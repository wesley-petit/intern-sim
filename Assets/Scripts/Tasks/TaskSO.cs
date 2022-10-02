using UnityEngine;

[CreateAssetMenu(fileName = "New Task", menuName = "Gamagora/Task")]
public class TaskSO : ScriptableObject
{
    public string Description;
    public RecipeSO Conditions;
}
