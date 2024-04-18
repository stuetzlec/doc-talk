using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

public class Test : MonoBehaviour
{
    [Serializable]
    private class GeminiPayload
    {
        public Content[] contents;
        public GenerationConfig generationConfig;
        public SafetySetting[] safetySettings;
    }

    [Serializable]
    private class ConvAIPayload
    {
        public string transcript;
        public string voice = "Bella-en-US"; // Example voice
        public string filename = "testAudio";
        public string encoding = "wav";
    }

    [Serializable]
    public class Part
    {
        public string text;
    }

    [Serializable]
    public class Content
    {
        public string role;
        public Part[] parts;
    }

    [Serializable]
    public class Candidate
    {
        public Content content;
    }

    [Serializable]
    public class RootObject
    {
        public Candidate[] candidates;
    }


    [Serializable]
    private class GenerationConfig
    {
        public float temperature = 0.9f;
        public int topK = 1;
        public int topP = 1;
        public int maxOutputTokens = 2048;
        public string[] stopSequences = new string[] { };
    }

    [Serializable]
    private class SafetySetting
    {
        public string category;
        public string threshold;
    }

    void Start()
    {
        Debug.Log("Initializing...");
        StartGeminiRequest();
    }

    void Update()
    {

    }

    public void StartGeminiRequest()
    {
        Debug.Log("Starting Gemini request...");
        StartCoroutine(CallGeminiApi());
    }

    private IEnumerator CallGeminiApi()
    {
        string geminiApiKey = "AIzaSyAawjgkMLNZFzH5gi38pn7ptiFRBuE4Dhw";
        string geminiApiUri = $"https://generativelanguage.googleapis.com/v1beta/models/gemini-1.0-pro-001:generateContent?key={geminiApiKey}";
        string transcript = @"User: Good afternoon. Thank you for coming in today for your follow-up appointment. How have you been feeling since you started the Paxlovid medication?

John Smith: Hello Doctor. I've been feeling alright since starting the Paxlovid medication. But I must say, my concern isn't about how I'm feeling; it's about the efficacy of the medication and any potential side effects. So, can you tell me more about how this Paxlovid works and what I should expect?

User: I'm glad to hear you didn't experience any side effects, but I need to talk to you about something important. When I prescribed the Paxlovid over the phone, I made a mistake. I didn't realize that we needed to adjust the dosage because of your decreased kidney function. I'm really sorry for this error.

John Smith: Hello Doctor. I appreciate your apology, but I'm quite concerned about this oversight. How could the dosage of a medication be prescribed without considering the patient's specific conditions? This is exactly the kind of mistake that should not happen, and I need to know what the potential consequences are and how we can rectify this immediately.

User: I'm going to order some lab tests to check your kidney function because taking the full-strength Paxlovid could potentially affect your kidneys. The good news is, there doesn't seem to be any physical harm so far, and your kidney function is preserved.

John Smith: Hello Doctor. I'm relieved to hear that there doesn't appear to be any immediate harm from the full-strength Paxlovid. However, I'm still troubled by the fact that the error occurred in the first place. What are the next steps to ensure that my treatment is on the right track and that such oversights won't happen again in the future?

User: I apologize again for the oversight, and I promise to be more cautious in the future. Your safety and well-being are our top priorities.

John Smith: Hello Doctor. I appreciate your commitment to being more cautious, but I need more than just a promise. What specific measures will be put in place to prevent this from happening again, not just for me but for all patients? I need to be assured that the system is reliable and that my health is secure.
";
        string prompt = @"Hey Google Gemini, I recently had a conversation with a patient named about a medication dosage error I made. It was one of those moments every doctor dreads, having to admit a mistake and work through it with a patient. Here's the gist of our chat:

" + transcript + @"I’m reaching out for a bit of a debrief on this, looking for your honest feedback but in a casual, straight-talking way – no need for formal sections or anything. Think of it as if we’re just chatting about it, maybe highlighting:

How I kicked things off and if I managed to set the right tone from the get-go.
The way I owned up to the error – was my apology as clear and heartfelt as I intended?
Tackling the patient’s concerns – did I hit the mark in addressing their worries and providing the right assurances?
Those moments of reassurance – could I have given a bit more comfort or clarity?
And of course, any of those ‘if only’ moments or chances I might have missed to make the conversation even better.
Just aiming to learn and grow from this, so I’m all for your straightforward, no-holds-barred insights. How do you think I did, and where can I polish up my approach for next time?";



        var payload = new GeminiPayload
        {
            contents = new Content[]
            {
                new Content
                {
                    role = "user",
                    parts = new Part[]
                    {
                        new Part { text = prompt }
                    }
                }
            },
            generationConfig = new GenerationConfig(),
            safetySettings = new SafetySetting[]
            {
                new SafetySetting { category = "HARM_CATEGORY_HARASSMENT", threshold = "BLOCK_MEDIUM_AND_ABOVE" },
                // Add other safety settings as needed
            }
        };

        string jsonPayload = JsonUtility.ToJson(payload);
        byte[] jsonPayloadBytes = System.Text.Encoding.UTF8.GetBytes(jsonPayload);

        using (UnityWebRequest webRequest = new UnityWebRequest(geminiApiUri, "POST"))
        {
            webRequest.uploadHandler = (UploadHandler)new UploadHandlerRaw(jsonPayloadBytes);
            webRequest.downloadHandler = (DownloadHandler)new DownloadHandlerBuffer();
            webRequest.SetRequestHeader("Content-Type", "application/json");

            yield return webRequest.SendWebRequest();

            if (webRequest.result == UnityWebRequest.Result.Success)
            {
                var jsonResponse = JsonUtility.FromJson<RootObject>(webRequest.downloadHandler.text);
                string textResponse = jsonResponse.candidates[0].content.parts[0].text;
                Debug.Log("Gemini Response: " + textResponse);
                StartCoroutine(CallConvAiApi(textResponse));
            }
            else
            {
                Debug.LogError("Gemini Error: " + webRequest.error);
            }
        }
    }

    private IEnumerator CallConvAiApi(string textForTTS)
    {
        string convAiApiKey = "973cfcd9dfc0a419a537087bfd2cdb61";
        string convAiApiUri = "https://api.convai.com/tts/";

        var convAiPayload = new ConvAIPayload
        {
            transcript = textForTTS,
            voice = "Bella-en-US",
            filename = "testAudio",
            encoding = "wav"
        };

        string jsonPayload = JsonUtility.ToJson(convAiPayload);
        byte[] jsonPayloadBytes = System.Text.Encoding.UTF8.GetBytes(jsonPayload);

        using (UnityWebRequest webRequest = UnityWebRequest.Post(convAiApiUri, UnityWebRequest.kHttpVerbPOST))
        {
            webRequest.uploadHandler = new UploadHandlerRaw(jsonPayloadBytes);
            webRequest.downloadHandler = new DownloadHandlerBuffer();
            webRequest.SetRequestHeader("Content-Type", "application/json");
            webRequest.SetRequestHeader("CONVAI-API-KEY", convAiApiKey);

            yield return webRequest.SendWebRequest();

            if (webRequest.result == UnityWebRequest.Result.Success)
            {
                Debug.Log("ConvAI Response: Audio received");

                // Save the MP3 data to a file
                string path = $"{Application.persistentDataPath}/testAudio.mp3";
                System.IO.File.WriteAllBytes(path, webRequest.downloadHandler.data);
                Debug.Log($"Audio saved to {path}");

                // If you need to play the audio, consider loading it from the file system if your platform supports MP3 playback
                // Note: Direct playback of MP3 files from bytes is not supported by Unity's AudioClip API
            }
            else
            {
                Debug.LogError("ConvAI Error: " + webRequest.error);
            }
        }
    }
}
