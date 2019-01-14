using UnityEditor;
using System.IO;
using UnityEngine;

public static class EditorUtils
{
    [MenuItem("Ashley's Tools/Clear Player Data")]
    public static void ClearPlayerData()
    {
        if (File.Exists(PlayerData.PLAYER_DATA_FILE))
        {
            File.Delete(PlayerData.PLAYER_DATA_FILE);
        }

        AssetDatabase.Refresh();

        Debug.Log("Player data cleared!");
    }
}
