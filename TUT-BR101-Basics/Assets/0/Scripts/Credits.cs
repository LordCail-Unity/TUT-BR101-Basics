using UnityEngine;

public class Credits : MonoBehaviour
{

    public GameObject fadeOutUI;

    public void Quit ()
    {
        fadeOutUI.SetActive(true); //Just to show the end game effect in editor
        Application.Quit(); // Will have no effect in Editor
        Debug.Log("Application Quit Successfully");
    }

}
