using UnityEngine;

public class SoundPlayer : MonoBehaviour
{
    public static SoundPlayer Instance {  get; private set; }

    [SerializeField] private SoundSourcer _sourcerPrefab;

    private float _volume = 1f;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }

    public void Play(AudioClip clip, Vector3 position)
    {
        SoundSourcer sourcer = Instantiate(_sourcerPrefab, position, Quaternion.identity);
        sourcer.Init(clip, _volume);
    }
}
