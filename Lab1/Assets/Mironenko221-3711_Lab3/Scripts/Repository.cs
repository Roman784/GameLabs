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

    public int GetBestScore(int levelNumber)
    {
        string key = "Level" + levelNumber.ToString();
        if (PlayerPrefs.HasKey(key))
            return PlayerPrefs.GetInt(key);
        return 0;
    }

    public void UpdateScoreAsync(int levelNumber, int value)
    {
        string key = "Level" + levelNumber.ToString();
        PlayerPrefs.SetInt(key, value);
    }
}