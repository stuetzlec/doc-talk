using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class API : MonoBehaviour
{
    [SerializeField] private string apiKey = "973cfcd9dfc0a419a537087bfd2cdb61"; // Replace with your actual API key
    [SerializeField] private string url = "https://api.convai.com/character/update";

    void Start()
    {
        string charID = "82ab0c6e-f53a-11ee-b0cc-42010a7be00e"; // Replace with actual character ID
        string backstory = "Test Passed! YAAAAAAAAAAAAY!";
        string charName = "testCharacter";
        string voiceType = "US MALE 1";

        UpdateCharacter(charID, backstory, charName, voiceType);
    }

    public void UpdateCharacter(string charID, string backstory, string charName, string voiceType)
    {
        StartCoroutine(PostCharacterUpdate(charID, backstory, charName, voiceType));
    }

    IEnumerator PostCharacterUpdate(string charID, string backstory, string charName, string voiceType)
    {
        // Create the payload
        string payload = JsonUtility.ToJson(new
        {
            charID = charID,
            backstory = backstory,
            voiceType = voiceType,
            charName = charName
        });

        // Create the request
        UnityWebRequest request = new UnityWebRequest(url, "POST");
        byte[] bodyRaw = System.Text.Encoding.UTF8.GetBytes(payload);
        request.uploadHandler = (UploadHandler)new UploadHandlerRaw(bodyRaw);
        request.downloadHandler = (DownloadHandler)new DownloadHandlerBuffer();
        request.SetRequestHeader("CONVAI-API-KEY", apiKey);
        request.SetRequestHeader("Content-Type", "application/json");

        // Log the sending of the request
        Debug.Log("Sending request to: " + url);
        Debug.Log("Payload: " + payload);

        // Wait for the response and then display it
        yield return request.SendWebRequest();

        if (request.isNetworkError || request.isHttpError)
        {
            Debug.LogError("Error: " + request.error);
            Debug.LogError("Response: " + request.downloadHandler.text);
        }
        else
        {
            Debug.Log("Response: " + request.downloadHandler.text);
        }
    }
}
