using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Character
{
    public string Name;
    public Color NameTextColor;
    public GameObject CutsceneSprite;
}

[CreateAssetMenu(fileName = "CharacterManifest", menuName = "Inventory/List", order = 1)]
public class CharacterManifest : ScriptableObject
{
    public List<Character> Characters;
}
