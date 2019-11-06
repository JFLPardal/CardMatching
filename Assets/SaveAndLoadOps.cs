using UnityEngine;

public class SaveAndLoadOps : MonoBehaviour
{ 
    public void SaveLeaderboard(in LeaderboardTable dataToSave, in string attributeName) 
    {
        string jsonString = JsonUtility.ToJson(dataToSave);
        PlayerPrefs.SetString(attributeName, jsonString);
        PlayerPrefs.Save();
    }
    
    public T LoadString<T>(in string attributeName) 
    {
        string savedString = PlayerPrefs.GetString(attributeName);
        T jsonObject =  JsonUtility.FromJson<T>(savedString);
        return jsonObject;
    }
}
