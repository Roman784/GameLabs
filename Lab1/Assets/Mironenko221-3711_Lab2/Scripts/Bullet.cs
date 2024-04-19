using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float _lifetime;

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
        Debug.Log(collider.name);

        Destroy();
    }
}
