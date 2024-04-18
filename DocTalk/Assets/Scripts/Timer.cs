using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class SceneTransitionTimer : MonoBehaviour
{
    // The scene to transition to
    public string sceneToLoad = "";

    // Time before scene transition (in seconds)
    public float transitionTime = 60f;

    private float timer;

    void Start()
    {
        timer = transitionTime;
    }

    void Update()
    {
        // Countdown the timer
        timer -= Time.deltaTime;
        Debug.Log("Time remaining: " + timer);
        // If the timer reaches zero or below, transition to the new scene
        if (timer <= 0f)
        {
            LoadNextScene();
        }
    }

    void LoadNextScene()
    {
        // Load the specified scene
        SceneManager.LoadScene(sceneToLoad);
    }
}
