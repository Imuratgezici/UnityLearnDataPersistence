using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.IO;
using TMPro;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    public static GameManager Instance;
    public string BestScoreName;
    public int BestScore;
    public string userName;
    public TextMeshProUGUI BestScoreText;

   private void Awake() {
        if (Instance != null)
    {
        Destroy(gameObject);
        return;
    }
        Instance = this;
        DontDestroyOnLoad(gameObject);
        LoadBestScore();
        BestScoreText.text = "Best Score: "+BestScoreName+" "+BestScore;
    }


    [System.Serializable]
class SaveData
{
    public string BestScoreName;
    public int BestScore;
}

public void SaveBestScore()
{
    SaveData data = new SaveData();
    data.BestScoreName = BestScoreName;
    data.BestScore = BestScore;
    
    string json = JsonUtility.ToJson(data);
  
    File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
}

public void LoadBestScore()
{
    string path = Application.persistentDataPath + "/savefile.json";
    if (File.Exists(path))
    {
        string json = File.ReadAllText(path);
        SaveData data = JsonUtility.FromJson<SaveData>(json);

        BestScoreName = data.BestScoreName;
        BestScore = data.BestScore;
    }
}
}
