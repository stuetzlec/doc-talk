using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Linq;
using System;

public class FeedbackBoard : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip soundToPlay;
    public GameObject feedbackDictionary;
    public TextMeshProUGUI textComponent;

    public Dictionary<string, int> feedbackDict;

    void Start()
    {
        // Set the text to an empty string
        audioSource.clip = soundToPlay;
        audioSource.Play();
        initDictionary();
        GetTopKFeedback(3);
    }

    public void initDictionary()
    {
        feedbackDict = new Dictionary<string, int>
        {
            { "Good", 8 },
            { "Bad", 3 },
            { "Neutral", 11 },
            { "Great", 14 },
            { "Terrible", 2 }
        };
    }

    public void GetTopKFeedback(int k)
    {
        // Sort the dictionary by value
        var sortedDict = from entry in feedbackDict orderby entry.Value descending select entry;

        // Get the top k feedbacks
        int count = 0;
        foreach (KeyValuePair<string, int> entry in sortedDict)
        {
            if (count < k)
            {
                SetText(entry.Key + "<br>");
                count++;
            }
            else
            {
                break;
            }
        }
    }

    // Function to set the text
    public void SetText(string newText)
    {
        // Check if the Text component reference is set
        if (textComponent != null)
        {
            // Set the text
            textComponent.text += newText;
        }
        else
        {
            Debug.LogError("Text component reference is not set!");
        }
    }

}
