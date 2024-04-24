using UnityEngine;
using System.IO;
using System;
using Convai.Scripts.Utils;
using TMPro;

public class TranscriptCollector : MonoBehaviour
{

    public void SaveToFile()
    {
    // Get the transcript from ChatBoxUI
    string transcript = "";  // Initialize an empty string to hold the transcript

// Iterate over each child of _chatPanel
for (int i = 0; i < ChatBoxUI._chatPanel.transform.childCount; i++)
{
    // Get the TMP_Text component of the child
    TMP_Text textComponent = ChatBoxUI._chatPanel.transform.GetChild(i).GetComponent<TMP_Text>();

    // If the child has a TMP_Text component, append its text to the transcript
    if (textComponent != null)
    {
        transcript += textComponent.text + "\n";  // Add a newline character after each message
    }
}

    // Log the transcript to the console
    Debug.Log(transcript);

    // Get the current date and time
    string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");

    // Create the filename with the timestamp
    string filename = "transcript_" + timestamp + ".txt";

    // Create the full file path
    string fullPath = Path.Combine(Application.persistentDataPath, filename);

    Debug.Log("Saving transcript to: " + fullPath);

    // Write the transcript to a file
    File.WriteAllText(fullPath, transcript);
    }
}
