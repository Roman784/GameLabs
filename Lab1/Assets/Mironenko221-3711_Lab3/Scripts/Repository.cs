using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using UnityEngine;

public class Repository
{
    private static Repository _instance;
    public static Repository Instance
    {
        get
        {
            if (_instance == null)
                _instance = new Repository();
            return _instance;
        }
    }

    public GameData GameData { get; private set; }

    private string _savePath;

    private Repository()
    {
        _savePath = Path.Combine (Application.dataPath, "gameData.json");
    }

    public async Task SaveAsync()
    {
        try
        {
            string json = JsonUtility.ToJson(GameData, true);
            await File.WriteAllTextAsync (_savePath, json);

            Debug.Log("Save data complete");
        }
        catch { Debug.Log("Save data error"); }
    }

    public async Task LoadAsync()
    {
        try
        {
            if (!File.Exists(_savePath))
            {
                Debug.Log("File not exist");

                DefaultDataAsync();
                return;
            }

            string json = await File.ReadAllTextAsync(_savePath);
            GameData = JsonUtility.FromJson<GameData>(json);

            Debug.Log("Load data complete");
        }
        catch { Debug.Log("Load data error"); }
    }

    public async void UpdateScoreAsync(int levelNumber, int value)
    {
        Score score = GameData.Scores.FirstOrDefault(s => s.LevelNumber == levelNumber);

        if (score == null)
        {
            AddScoreAsync(levelNumber, value);
            return;
        }

        score.Value = value;

        await SaveAsync();
    }

    private async void AddScoreAsync(int levelNumber, int value)
    {
        Score newScore = new Score()
        {
            LevelNumber = levelNumber,
            Value = value
        };

        GameData.Scores.Add(newScore);

        await SaveAsync();
    }

    private async void DefaultDataAsync()
    {
        GameData = new GameData()
        {
            Scores = new List<Score>()
        };

        Debug.Log("Default data");

        await SaveAsync();
    }
}

[System.Serializable]
public class GameData
{
    public List<Score> Scores = new List<Score>();
}

[System.Serializable]
public class Score
{
    public int LevelNumber { get; set; }
    public int Value {  get; set; }
}