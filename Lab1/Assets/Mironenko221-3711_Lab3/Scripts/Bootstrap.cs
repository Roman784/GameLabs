using System.Collections;
using System.Threading.Tasks;
using UnityEngine;

public class Bootstrap : MonoBehaviour
{
    [SerializeField] private int _levelNumber;

    [Space]

    [SerializeField] private TargetDifficultyData targetDifficultyData;
    [SerializeField] private TargetSpawner[] _targetSpawners;

    private IEnumerator Start()
    {
        yield return LoadGameData();
        InitTargetSpawners();
    }

    private IEnumerator LoadGameData()
    {
         Task task = Repository.Instance.LoadAsync();
        yield return new WaitUntil(() => task.IsCompleted);

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
