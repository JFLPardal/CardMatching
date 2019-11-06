using TMPro;
using UnityEngine;

public class LeaderboardUIEntry : MonoBehaviour
{
   [SerializeField] private TextMeshProUGUI m_rank = null;
   [SerializeField] private TextMeshProUGUI m_name = null;
   [SerializeField] private TextMeshProUGUI m_time = null;
   
   public void SetName(string name)
   {
      m_name.text = name;
   }

   public void SetTime(uint time)
   { 
      m_time.text = time.ToString();
   }

   public void SetRank(int rank)
   {
      m_rank.text = rank.ToString();
   }
}
