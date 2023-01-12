using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class SoundSystem : MonoBehaviour
{
    private AudioSource aud;

    private void Awake()
    {
        aud = GetComponent<AudioSource>();
    }

    public void PlaySound(AudioClip sound)
    {
        aud.PlayOneShot(sound);
    }

}
