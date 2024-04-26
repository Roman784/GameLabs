using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float _lifetime;

    [Space]

    [SerializeField] private AudioClip _hitSound;

    public void Awake()
    {
        Invoke(nameof(Destroy), _lifetime);
    }

    private void Destroy()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.TryGetComponent<Target>(out Target target))
        {
            target.TakeHit();
        }

        SoundPlayer.Instance.Play(_hitSound, transform.position);

        Destroy();
    }
}
