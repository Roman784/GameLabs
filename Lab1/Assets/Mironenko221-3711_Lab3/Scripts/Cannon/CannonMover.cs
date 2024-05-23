using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class CannonMover : MonoBehaviour
{
    [SerializeField] private float _speed;

    private Rigidbody _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>(); 
    }

    private void FixedUpdate()
    {
        float input = Input.GetAxis("Vertical");

        Vector3 direction = transform.forward * input;

        if (direction != Vector3.zero)
            Move(direction);
    }

    private void Move(Vector3 direction)
    {
        if (PauseMenu.IsPaused) return;

        _rigidbody.velocity = direction * _speed * Time.fixedDeltaTime;
    }
}
