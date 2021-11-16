using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public string username;
    public string bestUsername;
    public int bestScore;
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
    public class SaveData
    {
        public string username;
        public int score;
    }

    public void SaveScore(int score)
    {
        string path = Application.persistentDataPath + "/scores.json";
        SaveData _saveData = new SaveData();
        _saveData.username = username;
        _saveData.score = score;

        string json = JsonUtility.ToJson(_saveData);
        File.WriteAllText(path,json);
    }

    public void LoadScore()
    {
        string path = Application.persistentDataPath + "/scores.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData _saveData = JsonUtility.FromJson<SaveData>(json);
            bestUsername = _saveData.username;
            bestScore = _saveData.score;
        }
    }
}
