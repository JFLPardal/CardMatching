using UnityEngine;

public enum SceneChange
{
    mainMenu,
    leaderboard,
    play
};

public class PlaySound : MonoBehaviour
{
    public static PlaySound instance = null;
    
    [SerializeField] private AudioSource m_player;
    
    [SerializeField] private AudioClip m_playButtonPressed = null;
    [SerializeField] private AudioClip m_leaderboardPressed = null;
    [SerializeField] private AudioClip m_mainMenuPressed = null;

    private void Awake()
    {
        MakeSingleton();
    }

    public void Play(AudioClip clip)
    {
        m_player.PlayOneShot(clip);
    }
    public void Play(SceneChange clip)
    {
        switch (clip)
        {
            case SceneChange.mainMenu:
                m_player.PlayOneShot(m_mainMenuPressed);
                break;
            case SceneChange.leaderboard:
                m_player.PlayOneShot(m_leaderboardPressed);
                break;
            case SceneChange.play:
                m_player.PlayOneShot(m_playButtonPressed);
                break;
        }
    }

    private void MakeSingleton()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }
}
