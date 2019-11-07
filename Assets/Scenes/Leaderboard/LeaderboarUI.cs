using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public struct LeaderboardInfo
{
    public int m_rank;
    public string m_name;
    public uint m_time;

    public LeaderboardInfo(int rank, string name, uint time)
    {
        m_rank = rank;
        m_name = name;
        m_time = time;
    }
}

public class LeaderboarUI : MonoBehaviour
{
    [SerializeField] private VerticalLayoutGroup m_entriesArea = null;
    [SerializeField] private RectTransform m_leaderboardEntryPrefab = null;

    private List<LeaderboardUIEntry> m_entries = null;
    private bool m_inited = false;
    void Awake()
    { 
        if(!m_inited)
            Init();
    }

    public void UpdateEntry(LeaderboardInfo entryInfo)
    {
        if(!m_inited)
            Init();
        int index = entryInfo.m_rank - 1;
        m_entries[index].SetRank(entryInfo.m_rank);
        m_entries[index].SetTime(entryInfo.m_time);
        m_entries[index].SetName(entryInfo.m_name);
    }

    private void Init()
    {
        m_entries = new List<LeaderboardUIEntry>();
        
        int i = 0;
        while (i < Constants.MAX_ENTRIES)
        {
            var entry = Instantiate(m_leaderboardEntryPrefab, m_entriesArea.transform).GetComponent<LeaderboardUIEntry>();
            m_entries.Add(entry);
            i++;
        }
        m_inited = true;
    }
    
}
