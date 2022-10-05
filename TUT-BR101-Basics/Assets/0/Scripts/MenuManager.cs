using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{

    public Object startLevel;

    public void StartGame()
    {
        SceneManager.LoadScene(startLevel.name);
    }

}