using UnityEngine;

public class CharacterData : MonoBehaviour
{
    public static CharacterData Instance { get; private set; }

    [SerializeField]
    private CharacterManifest manifest;

	void Start ()
    {
        Instance = this;
	}

    public Character GetCharacter(string CharacterName)
    {
        for (int i = 0, count = manifest.Characters.Count; i < count; ++i)
        {
            Character current = manifest.Characters[i];
            if (current.Name == CharacterName)
            {
                return current;
            }
        }

        return null;
    }
}
