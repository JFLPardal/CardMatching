using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoad : MonoBehaviour
{
    public void LoadCardMatching()
    {
        SceneManager.LoadScene(Constants.CARD_MATCHING_SCENE);
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene(Constants.MAIN_MENU_SCENE);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
