using UnityEngine;

public class StartMenu : MonoBehaviour
{

    public GameObject startScreenUI;

    public void OnStartButtonClick()
    {
        FindObjectOfType<LevelManager>().StartGame();
    }

}
