using UnityEngine;

public class Rotator: MonoBehaviour
{
    [SerializeField] private float _rate;

    [Space]

    [SerializeField] private Vector3 _upperLimits;
    [SerializeField] private Vector3 _lowerLimits;

    private void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");

        Vector3 direction = new Vector3(y, x, 0f);

        if (direction != Vector3.zero)
            Rotate(direction);
    }

    private void Rotate(Vector3 direction)
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
