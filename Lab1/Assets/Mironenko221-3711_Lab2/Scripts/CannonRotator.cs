using UnityEngine;

public class CannonRotator: MonoBehaviour
{
    [SerializeField] private float _rate;

    [Space]

    [SerializeField] private Transform _barrel;
    [SerializeField] private Transform _base;

    [Space]

    [SerializeField] private Vector3 _upperLimits;
    [SerializeField] private Vector3 _lowerLimits;

    private void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");

        if (y != 0) Rotate(_barrel, new Vector3(y, 0f, 0f));
        if (x != 0) Rotate(_base, new Vector3(0f, x, 0f));
    }

    private void Rotate(Transform transform, Vector3 direction)
    {
        Vector3 currentAngles = transform.localEulerAngles;
        Vector3 newAngles = currentAngles + direction * _rate * Time.deltaTime;

        LimitAngles(ref newAngles);

        transform.localEulerAngles = newAngles;
    }

    private void LimitAngles(ref Vector3 angles)
    {
        // ѕредставление углов в диапазоне он -180 до 180
        if (angles.x >= 180f) angles.x -= 360f;
        if (angles.y >= 180f) angles.y -= 360f;

        angles.x = Mathf.Clamp(angles.x, _lowerLimits.x, _upperLimits.x);
        angles.y = Mathf.Clamp(angles.y, _lowerLimits.y, _upperLimits.y);
    }
}
