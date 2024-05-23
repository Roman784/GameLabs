using System.Collections;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] private Rigidbody _bulletPrefab;
    [SerializeField] private Transform _shotPoint;

    [Space]

    [SerializeField] private float _force;
    [SerializeField] private float _reloadTime;
    private bool _canShoot;

    [Space]

    [SerializeField] private Effect _effect;
    [SerializeField] private AudioClip _sound;

    private void Awake()
    {
        _canShoot = true;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
            PerformShot();
    }

    private void PerformShot()
    {
        if (!_canShoot || GameOverMenu.Instance.IsGameOver || PauseMenu.IsPaused) return;

        Rigidbody spawnedBullet = Instantiate(_bulletPrefab, _shotPoint.position, Quaternion.identity);

        spawnedBullet.AddForce(GetShotDirection() * _force, ForceMode.Impulse);

        StartCoroutine(Reload());

        _effect.Enable();
        SoundPlayer.Instance.Play(_sound, _shotPoint.position);
    }

    private Vector3 GetShotDirection()
    {
        return _shotPoint.forward;
    }

    private IEnumerator Reload()
    {
        _canShoot = false;

        yield return new WaitForSeconds(_reloadTime);

        _canShoot = true;
    }
}
