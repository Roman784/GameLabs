using UnityEngine;

public class CameraFollowing : MonoBehaviour
{
    [SerializeField] private Transform _target;

    private Vector3 DesiredPostion => 
        new Vector3(_target.position.x - _target.forward.x * _positionOffset.z, _target.position.y + _positionOffset.y, _target.position.z - _target.forward.z * _positionOffset.z);
    private Quaternion DesiredRotation => Quaternion.Euler(_target.rotation.eulerAngles + _rotationOffset);

    [Space]

    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _rotateSpeed;

    private Vector3 _positionOffset;
    private Vector3 _rotationOffset;

    private void Awake()
    {
        _positionOffset =  Abs(_target.position - transform.position);
        _rotationOffset = Abs(_target.rotation.eulerAngles - transform.rotation.eulerAngles);
    }

    private void FixedUpdate()
    {
        Move();
        Rotate();
    }

    private void Move()
    {
        transform.position = Vector3.Lerp(transform.position, DesiredPostion, _moveSpeed * Time.fixedDeltaTime);
    }

    private void Rotate()
    {
        transform.rotation = Quaternion.Lerp(transform.rotation, DesiredRotation, _rotateSpeed * Time.fixedDeltaTime);
    }

    private Vector3 Abs(Vector3 vector)
    {
        return new Vector3(Mathf.Abs(vector.x), Mathf.Abs(vector.y), Mathf.Abs(vector.z));
    }
}
