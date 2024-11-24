using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadOnClick : MonoBehaviour
{
    public string sceneName;  // The name of the scene to load

    void OnMouseDown()
    {
        // Load the specified scene when the object is clicked
        SceneManager.LoadScene(sceneName);
    }
}
