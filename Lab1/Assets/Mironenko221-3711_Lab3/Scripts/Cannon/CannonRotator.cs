using UnityEngine;

public class CannonRotator: MonoBehaviour
{
    [SerializeField] private float _barrelRate;
    [SerializeField] private float _cannonRate;

    [Space]

    [SerializeField] private Transform _barrel;

    [Space]

    [SerializeField] private Vector3 _upperLimits;
    [SerializeField] private Vector3 _lowerLimits;

    private Camera _camera;

    private void Start()
    {
        _camera = Camera.main;
    }

    private void Update()
    {
        RotateCannon();
        RotateBarrel();
    }

    private void RotateCannon()
    {
        float input = Input.GetAxis("Horizontal");

        Vector3 direction = new Vector3(0f, input, 0f) * _cannonRate;

        transform.Rotate(direction);
    }

    private void RotateBarrel()
    {
        Ray ray = _camera.ScreenPointToRay(Input.mousePosition);
        float range = _barrelRate + Vector3.Distance(_barrel.transform.position, _camera.transform.position);

        _barrel.transform.LookAt(ray.direction * range + ray.origin);
        _barrel.transform.localEulerAngles = LimitAngles(_barrel.transform.localEulerAngles);

        Debug.DrawRay(ray.origin, ray.direction * range, Color.red);
    }

    private Vector3 LimitAngles(Vector3 angles)
    {
        // ѕредставление углов в диапазоне он -180 до 180
        if (angles.x >= 180f) angles.x -= 360f;
        if (angles.y >= 180f) angles.y -= 360f;

        angles.x = Mathf.Clamp(angles.x, _lowerLimits.x, _upperLimits.x);
        angles.y = Mathf.Clamp(angles.y, _lowerLimits.y, _upperLimits.y);

        return angles;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, _barrelRate);
    }
}
