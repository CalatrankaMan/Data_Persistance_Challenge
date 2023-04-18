using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class MainManager : MonoBehaviour
{

    public static MainManager Instance;
    public string m_BestScoreName;
    public string m_Name;
    public int m_BestScore;
    public int m_Score;
   


    // Start is called before the first frame update
    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    [System.Serializable]
    class SaveData
    {
        public int bs_score;
        public string bs_name;
    }
    void CheckLeaderboard(int score, string name)
    {
        SaveData data = new SaveData();

        if(score > data.bs_score)
        {
            data.bs_name = name;
            data.bs_score = score;
        }

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadLeaderboard()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            m_BestScoreName = data.bs_name;
            m_BestScore = data.bs_score;
        }
    }
}
