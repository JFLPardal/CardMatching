using TMPro;
using UnityEngine;

public class TextInputSaver : MonoBehaviour
{
    private TMP_InputField m_text = null;
    void Awake()
    {
        m_text = GetComponent<TMP_InputField>();
    }

    public void SaveUserNickname()
    {
        print(m_text.text);
        PlayerPrefs.SetString(Constants.NICKNAME_STRING, m_text.text);
    }
}
