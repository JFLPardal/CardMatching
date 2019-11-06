using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeaderboardOps : MonoBehaviour
{
    private const string c_leaderboardString = "leaderboard";
    private const string c_jsonOpsTag = "JsonOps";
    private LeaderboardTable m_leaderboard;
    private SaveAndLoadOps m_saveAndLoadOps;
    
    void Awake()
    {
        FindJsonOps();
        m_leaderboard = new LeaderboardTable();
        LoadLeaderboard();
        /*
        AddToLeaderboard(new LeaderboardEntry("Nemesis", 666));
        AddToLeaderboard( new LeaderboardEntry("Rita", 2300));
        AddToLeaderboard( new LeaderboardEntry("Miguel", 20410));*/
        
        Debug.Log(PlayerPrefs.GetString(c_leaderboardString));
    }

    private void LoadLeaderboard()
    {
        m_leaderboard = m_saveAndLoadOps.LoadString<LeaderboardTable>(c_leaderboardString);
        if (m_leaderboard == null)
        {
            Debug.LogError("Leaderboard could not be retrieved");
        }
    }
    public void AddToLeaderboard(LeaderboardEntry newEntry)
    {
        m_leaderboard.m_highscores.Add(newEntry);
        m_saveAndLoadOps.SaveLeaderboard(m_leaderboard, c_leaderboardString);
    }
    private void FindJsonOps()
    {
        m_saveAndLoadOps = GameObject.FindGameObjectWithTag(c_jsonOpsTag).GetComponent<SaveAndLoadOps>();
        if (m_saveAndLoadOps == null)
        {
            Debug.LogError("LeaderboardOps didn't find Game Object with tag " + c_jsonOpsTag);
        }
    }
}
