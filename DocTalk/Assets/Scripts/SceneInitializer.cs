using UnityEngine;

public class SceneInitializer : MonoBehaviour
{
    public CharacterSetup characterSetup;
    public string characterID;
    public string characterName;
    public string objectName;

    void Start()
    {
        characterSetup.SetupCharacter(characterID, characterName, objectName);
    }
}