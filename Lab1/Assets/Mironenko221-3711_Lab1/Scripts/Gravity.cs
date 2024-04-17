using UnityEngine;

[RequireComponent (typeof(Rigidbody))]
public class Gravity : MonoBehaviour
{
    [SerializeField, Range(-1f, 1f)] private float _scale = 1.0f;
    private float g = Physics.gravity.y;

    private Rigidbody _rigidbody;

    void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _rigidbody.useGravity = false;
    }

    void FixedUpdate()
    {
        Vector3 gravity = _rigidbody.mass * g * _scale * Vector3.up;
        _rigidbody.AddForce(gravity, ForceMode.Acceleration);
    }
}
