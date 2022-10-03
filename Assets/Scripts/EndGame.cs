using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGame : MonoBehaviour
{
    public Animator EndScreen;
    public TextMeshProUGUI EndText = null;

    private bool end = false;

    public void Win()
    {
        if (end)
            return;
        
        End();
        EndText.SetText("You Win!!");
    }
    
    public void Lose()
    {
        if (end)
            return;
        
        End();
        EndText.SetText("You Lose... Retry ?");
    }
    
    public void Retry()
    {
        SceneManager.LoadScene(0);
    }

    private void End()
    {
        Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
        Collider[] colliders = FindObjectsOfType<Collider>();
        foreach (var current in colliders)
            current.enabled = false;
        
        Outline[] outlines = FindObjectsOfType<Outline>();
        foreach (var current in outlines)
            current.enabled = false;

        gameObject.SetActive(true);

        EndScreen.SetTrigger("End");
        end = true;
    }
}
