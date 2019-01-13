using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class PlayerData : MonoBehaviour
{
    private const string PLAYER_DATA_FILE = "./playerdata.txt";

    private Dictionary<string, int> PlayerStats;

    public void Start()
    {
        PlayerStats = new Dictionary<string, int>();
    }

    public void UpdateStat(string statName, int increment)
    {
        if (!PlayerStats.ContainsKey(statName))
        {
            PlayerStats.Add(statName, 0);
        }

        PlayerStats[statName] += increment;
    }

    public int GetStat(string statName)
    {
        int val = 0;
        if (PlayerStats.ContainsKey(statName))
        {
            val = PlayerStats[statName];
        }
        return val;
    }

    private void SaveStats()
    {
    }
}
