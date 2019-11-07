using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverSceneChange : MonoBehaviour
{
    private BoardManager m_boardManager = null;
    void Awake()
    {
        m_boardManager = GameObject.FindGameObjectWithTag("BoardManager").GetComponent<BoardManager>();
        m_boardManager.OnGameOver += LoadScoreboardScene;
    }
    private void LoadScoreboardScene()
    {
        StartCoroutine(WaitAndLoadScene());
    }

    private IEnumerator WaitAndLoadScene()
    {
        yield return new WaitForSecondsRealtime(Constants.SECONDS_BEFORE_LEAVING_VICTORY_SCREEN);
        SceneManager.LoadScene(Constants.LEADERBOARD_SCENE);
    }
    private void OnDisable()
    {
        m_boardManager.OnGameOver -= LoadScoreboardScene;
    }
}
