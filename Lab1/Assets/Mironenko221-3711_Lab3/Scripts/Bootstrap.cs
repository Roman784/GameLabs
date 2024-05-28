using System.Collections;
using System.Linq;
using System.Threading.Tasks;
using UnityEngine;

public class Bootstrap : MonoBehaviour
{
    public static Bootstrap Instance { get; private set; }

    [SerializeField] private int _levelNumber;
    public int LevelNumber => _levelNumber;

    [Space]

    [SerializeField] private TargetDifficultyData targetDifficultyData;
    [SerializeField] private TargetSpawner[] _targetSpawners;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        UpdateBestScore();
        InitTargetSpawners();
    }

    private void UpdateBestScore()
    {
        int score = Repository.Instance.GetBestScore(_levelNumber);
        ScoreCounter.Instance.UpdateBestScore(score);
    }

    private void InitTargetSpawners()
    {
        foreach (var spawner in _targetSpawners)
        {
            float spawnRateMultiplyer = targetDifficultyData.SpawnRateMultiplyer.Evaluate(_levelNumber);
            float moveSpeedMultiplyer = targetDifficultyData.MoveSpeedMultiplyer.Evaluate(_levelNumber);
            spawner.Init(spawnRateMultiplyer, moveSpeedMultiplyer);
        }
    }
}
