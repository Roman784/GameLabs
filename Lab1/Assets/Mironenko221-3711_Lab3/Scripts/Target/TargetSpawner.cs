using UnityEngine;

public class TargetSpawner : MonoBehaviour
{
    [SerializeField] private Target _targetPrefab;

    [Space]

    [SerializeField] private int _score;
    [SerializeField] private float _moveSpeed;

    [Space]

    [SerializeField] private float _startDelay;
    [SerializeField] private float _repeateRate;

    [Space]

    [SerializeField] private Transform _fromPoint;
    [SerializeField] private Transform _toPoint;

    public void Init(float spawnRateMultiplyer, float moveSpeedMultiplyer)
    {
        _repeateRate *= spawnRateMultiplyer;
        _moveSpeed *= moveSpeedMultiplyer;

        InvokeRepeating(nameof(Spawn), _startDelay, _repeateRate);
    }

    private void Spawn()
    {
        Target target = Instantiate(_targetPrefab, _fromPoint.position, _targetPrefab.transform.rotation, null);
        target.Init(_score, _moveSpeed, _toPoint.position);
    }
}
