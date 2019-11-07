using System;
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
      string mins, seconds;
      mins = Mathf.Floor(time / Constants.SECONDS).ToString(Constants.MINUTES_FORMAT);
      seconds = (time % Constants.SECONDS).ToString(Constants.MINUTES_FORMAT);
      mins = String.Concat(mins, Constants.DELIMITER, seconds);
      m_time.text = mins;
   }

   public void SetRank(int rank)
   {
      m_rank.text = rank.ToString();
   }
}
