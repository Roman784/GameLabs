using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] private Rigidbody _bulletPrefab;
    [SerializeField] private Transform _shotPoint;

    [Space]

    [SerializeField] private float _force;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
            MakeShot();
    }

    private void MakeShot()
    {
        Rigidbody spawnedBullet = Instantiate(_bulletPrefab, _shotPoint.position, Quaternion.identity);

        spawnedBullet.AddForce(GetShotDirection() * _force, ForceMode.Impulse);
    }

    private Vector3 GetShotDirection()
    {
        return -transform.forward;
    }
}
