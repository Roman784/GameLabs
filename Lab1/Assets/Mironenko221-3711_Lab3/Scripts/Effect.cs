using UnityEngine;

[RequireComponent(typeof(ParticleSystem))]
public class Effect : MonoBehaviour
{
    private ParticleSystem _effect;

    private void Awake()
    {
        _effect = GetComponent<ParticleSystem>();
    }

    public void Enable()
    {
        _effect.Play();
    }
}
