using UnityEngine;
using UnityEngine.SceneManagement;

public class keyswitcher : MonoBehaviour
{
    void Update()
    {
        // Check if the L key is pressed
        if (Input.GetKeyDown(KeyCode.L))
        {
            // Load the specified scene
            SceneManager.LoadScene(0);
        }
    }

}
