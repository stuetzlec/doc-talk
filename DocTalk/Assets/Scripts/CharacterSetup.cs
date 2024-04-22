using UnityEngine;
using Convai.Scripts;
public class CharacterSetup : MonoBehaviour
{
    public string characterID;
    public string characterName;
    public string objectName;

    public void SetupCharacter(string id, string name, string objName)
    {
        GameObject characterObject = GameObject.Find(objName);
        
        if(characterObject == null)
        {
            Debug.LogError("Character object is not found with the provided object name: " + objName);
            return;
        }

        ConvaiNPC convaiNPC = characterObject.GetComponent<ConvaiNPC>();
        if (convaiNPC == null)
        {
            Debug.LogError("ConvaiNPC component is not attached to the character object.");
            return;
        }

        // Directly set the public attributes in ConvaiNPC
        convaiNPC.characterID = id;
        convaiNPC.characterName = name;

        // Set the position of the character object
        characterObject.transform.position = new Vector3(0f, 1.11000001f, 8.04599953f);
    }
}
