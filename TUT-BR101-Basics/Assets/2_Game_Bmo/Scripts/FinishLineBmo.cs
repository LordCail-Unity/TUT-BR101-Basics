using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLineBmo : MonoBehaviour
{

    // OnTriggerEnter will only work if the box collider is on the object this script is attached to.
    // It will not work if the collider is on a child object.
    // Quick fix: Remove collider from cube and add one to parent GameObject plus resize to fit

    private void OnTriggerEnter(Collider other)
    {
        // Better to replace this with Find Tag "Player"
        PlayerControllerBmo component = other.gameObject.GetComponent<PlayerControllerBmo>();
        if(component != null)
        {
            //Replace with reference to GameManager.LevelComplete
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }

}