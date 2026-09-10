using UnityEngine;

public class AudioScript : MonoBehaviour
{
    [Header("Audio Sources")]
    public AudioSource Music;
    public AudioSource SFX;
    [Header("Audio Clips")]
    public AudioClip background;
    public AudioClip jump;
    public AudioClip hit;
    private void Start()
    {
        Music.clip = background;
        Music.Play();
    }
    public void PlaySFX(AudioClip clip)
    {
        SFX.PlayOneShot(clip);
    }
}