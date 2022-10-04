using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    bool restartLevel = false;

    public float restartDelay = 2f;

    public void RestartLevel ()
    {
        if (restartLevel == false)
        {
            restartLevel = true;
            Debug.Log("RESTART LEVEL");
            Invoke("Restart", restartDelay); // Invoke enables a delay before calling the method
        }
    }

    void Restart()
    {
        // Basic Syntax: SceneManager.LoadScene("Level01")
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Debug.Log("RESTARTED");
    }

}
