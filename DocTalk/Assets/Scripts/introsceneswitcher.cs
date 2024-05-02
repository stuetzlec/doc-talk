using UnityEngine;
using UnityEngine.SceneManagement;

public class SoundAndSceneSwitch : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip soundToPlay;
    private bool soundPlayed = false;

    void Update()
    {
        // Check if the sound has been played
        if (!soundPlayed)
        {
            // Play the sound
            audioSource.clip = soundToPlay;
            audioSource.Play();
            Debug.Log("Playing sound: " + soundToPlay.name);
            soundPlayed = true;
        }

        // Wait for 2 seconds after playing the sound before switching scenes
        if (soundPlayed && Time.timeSinceLevelLoad >= 67f)
        {
            audioSource.Stop();
        }
    }
}
