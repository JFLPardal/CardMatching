using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TMPro;
using UnityEngine;
public class Clock : MonoBehaviour
{
    public static event Action<int> OnTimeCalculated = delegate {  };
    
    [SerializeField] private BoardManager m_boardManager = null;
    
    private TextMeshProUGUI m_text = null;
    private float m_time = 0f;
    private string m_seconds = "";
    private string m_minutes = "";
    private const string c_timeFormat = Constants.MINUTES_FORMAT;
    private const string c_timeDelimiter = Constants.DELIMITER;
    private const int c_seconds = Constants.SECONDS;
    
    void Awake()
    {
        m_text = GetComponentInChildren<TextMeshProUGUI>();
        m_boardManager.OnGameOver += StopClock;
    }

    void Update()
    {
        m_time += Time.deltaTime;
        UpdateTimerText();
    }

    private void UpdateTimerText()
    {
        m_minutes = Mathf.Floor(m_time / c_seconds).ToString(c_timeFormat);
        m_seconds = (m_time % c_seconds).ToString(c_timeFormat);
        m_minutes = String.Concat(m_minutes, c_timeDelimiter, m_seconds);
        m_text.text = m_minutes.ToString();
    }

    private void StopClock()
    {
        UpdateTimerText();
        print("finished game in: " + m_text.text);
        OnTimeCalculated(Mathf.FloorToInt(m_time));
        this.enabled = false;
    }
}
