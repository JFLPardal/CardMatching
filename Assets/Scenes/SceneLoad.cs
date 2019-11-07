using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoad : MonoBehaviour
{
    public void LoadCardMatching()
    {
        PlaySound.instance.Play(SceneChange.play);
        SceneManager.LoadScene(Constants.CARD_MATCHING_SCENE);
    }

    public void LoadMainMenu()
    {
        PlaySound.instance.Play(SceneChange.mainMenu);
        SceneManager.LoadScene(Constants.MAIN_MENU_SCENE);
    }
    public void LoadLeaderboard()
    {
        PlaySound.instance.Play(SceneChange.leaderboard);
        SceneManager.LoadScene(Constants.LEADERBOARD_SCENE);
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
