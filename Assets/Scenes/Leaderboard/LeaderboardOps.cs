using System;
using UnityEngine;

public class LeaderboardOps : MonoBehaviour
{
    [SerializeField] private RectTransform m_leaderboardUI = null;
    
    private const string c_leaderboardString = "leaderboard";
    private const string c_jsonOpsTag = "JsonOps";
    private LeaderboardTable m_leaderboard;
    private SaveAndLoadOps m_saveAndLoadOps;
    
    void Awake()
    {
        FindJsonOps();
        m_leaderboard = new LeaderboardTable();
        
        LoadLeaderboard();
        LoadLastScoreIfPreviousSeceneWasGame();
    }

    private void LoadLastScoreIfPreviousSeceneWasGame()
    {
        if (PlayerPrefs.GetInt(Constants.NEW_SCORE_FLAG) == 1)
        {
            CheckIfHighscore(PlayerPrefs.GetInt("lastScore"));
            PlayerPrefs.SetInt(Constants.NEW_SCORE_FLAG, 0);
        }
    }

    private void CheckIfHighscore(int time)
    {
        if (m_leaderboard.Count() >= Constants.MAX_ENTRIES)
        {
            if (m_leaderboard.IsHighscore(time))
            {
                string nickname = PlayerPrefs.GetString(Constants.NICKNAME_STRING);
                LeaderboardEntry newEntry = new LeaderboardEntry(nickname, (uint)Mathf.RoundToInt(time), -1); 
                AddToLeaderboard(newEntry);
            }
        }
        else
        {
            string nickname = PlayerPrefs.GetString(Constants.NICKNAME_STRING);
            LeaderboardEntry newEntry = new LeaderboardEntry(nickname, (uint)Mathf.RoundToInt(time), -1);
            AddToLeaderboard(newEntry);
        }
    }
    private void LoadLeaderboard()
    {
        m_leaderboard = m_saveAndLoadOps.LoadString<LeaderboardTable>(c_leaderboardString);
        if (m_leaderboard == null)
        {
            Debug.LogError("Leaderboard could not be retrieved");
            return;
        }
        m_leaderboard.SortLeaderboard();
       
        foreach (var entry in m_leaderboard.Leaderboard())
        { 
            UpdateEntryUI(entry);
        }
    }
    public void AddToLeaderboard(LeaderboardEntry newEntry)
    {
        m_leaderboard.Add(newEntry);
        if (m_leaderboard.Count() > Constants.MAX_ENTRIES)
        {
            while(m_leaderboard.Count() > Constants.MAX_ENTRIES)
                m_leaderboard.DeleteLast();
        }
        UpdateEntryUI(newEntry);
        m_saveAndLoadOps.SaveLeaderboard(m_leaderboard, c_leaderboardString);
    }

    private void UpdateEntryUI(LeaderboardEntry entryToAdd)
    {
        LeaderboardInfo info = new LeaderboardInfo(entryToAdd.Rank(),entryToAdd.Name(), entryToAdd.Time());
        m_leaderboardUI.GetComponent<LeaderboarUI>().UpdateEntry(info);
    }
    private void FindJsonOps()
    {
        m_saveAndLoadOps = GameObject.FindGameObjectWithTag(c_jsonOpsTag).GetComponent<SaveAndLoadOps>();
        if (m_saveAndLoadOps == null)
        {
            Debug.LogError("LeaderboardOps didn't find Game Object with tag " + c_jsonOpsTag);
        }
    }

    private void OnApplicationQuit()
    {
        m_saveAndLoadOps.SaveLeaderboard(m_leaderboard, c_leaderboardString);
    }
}
