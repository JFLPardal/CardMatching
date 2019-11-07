using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[System.Serializable] 
public class LeaderboardEntry
{
    [SerializeField] private string m_playerName;
    [SerializeField] private uint m_time;
    [SerializeField] private int m_rank;

    public LeaderboardEntry(string name, uint time, int rank)
    {
        m_playerName = name;
        m_time = time;
        m_rank = rank;
    }
    public uint Time()
    {
        return m_time;
    }

    public string Name()
    {
        return m_playerName;
    }

    public int Rank()
    {
        return m_rank;
    }

    public void SetRank(int newRank)
    {
        m_rank = newRank;
    }
}

public class LeaderboardTable
{
    [SerializeField] private List<LeaderboardEntry> m_highscores;
    public LeaderboardTable()
    {
        m_highscores = new List<LeaderboardEntry>();
    }
    public void Add(LeaderboardEntry entryToAdd)
    {
        m_highscores.Add(entryToAdd);
        SortLeaderboard();
    }

    public ref List<LeaderboardEntry> Leaderboard()
    {
        return ref m_highscores;
    }
    
    public void DeleteLast()
    {
        m_highscores.RemoveAt(m_highscores.Count - 1);
    }

    public int Count()
    {
        return m_highscores.Count;
    }

    public void SortLeaderboard()
    {
        m_highscores = m_highscores.OrderBy(o => o.Time()).ToList();
        int rank = 1;
        foreach (var score in m_highscores)
        {
            score.SetRank(rank);
            rank++;
            Debug.Log(score.Time().ToString());
        }
    }

    public bool IsHighscore(int time)
    {
        return time < m_highscores[m_highscores.Count - 1].Time();
    }
}
