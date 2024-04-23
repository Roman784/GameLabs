using UnityEngine;

public class Target : MonoBehaviour
{
    [SerializeField] private int _health;

    public void TakeDamage(int damage)
    {
        if (damage < 0) return;

        _health -= damage;

        if (_health <= 0)
            Destroy(gameObject);
    }
}
