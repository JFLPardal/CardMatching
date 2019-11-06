using System.Collections.Generic;
using UnityEngine;

[System.Serializable] 
public class LeaderboardEntry
{
    [SerializeField] private string m_playerName;
    [SerializeField] private uint m_time;

    public LeaderboardEntry(string name, uint time)
    {
        m_playerName = name;
        m_time = time;
    }
}

public class LeaderboardTable
{
    [SerializeField] public List<LeaderboardEntry> m_highscores;
    public LeaderboardTable()
    {
        m_highscores = new List<LeaderboardEntry>();
    }
}
