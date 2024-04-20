using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class SoundSourcer : MonoBehaviour
{
    public void Init(AudioClip clip, float volume)
    {
        AudioSource source = GetComponent<AudioSource>();

        source.clip = clip;
        source.volume = volume;

        source.Play();

        DontDestroyOnLoad(gameObject);
        Destroy(gameObject, clip.length);
    }
}
