using UnityEngine;
using UnityEngine.Events;

public class Horloge : MonoBehaviour
{
    public GameObject pivot;
    public float rotationSpeed;
    public int maxTimeInSeconds = 10;
    public UnityEvent OnEndTimer = null;

    private float timeSinceLastSpawn = 0f;

    private void Update()
    {
        pivot.transform.Rotate(new Vector3(0, Time.deltaTime * rotationSpeed, 0));

        timeSinceLastSpawn += Time.deltaTime;
        if (maxTimeInSeconds < timeSinceLastSpawn)
        {
            timeSinceLastSpawn -= maxTimeInSeconds;
            OnEndTimer?.Invoke();
        }
    }
}
