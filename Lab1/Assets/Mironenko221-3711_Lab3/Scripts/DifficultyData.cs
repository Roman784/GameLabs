using UnityEngine;

[CreateAssetMenu(fileName = "TargetDifficultyData", menuName = "Difficulty/TargetDifficultyData")]
public class TargetDifficultyData : ScriptableObject
{
    [field: SerializeField] public AnimationCurve SpawnRateMultiplyer { get; private set; }
    [field: SerializeField] public AnimationCurve MoveSpeedMultiplyer { get; private set; }
}
