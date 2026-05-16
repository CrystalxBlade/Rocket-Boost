using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header("-----------Audio Source-----------")]
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource sfxSource;

    [Header("-----------Audio Clips-----------")]
    public AudioClip background;
    public AudioClip crash;
    public AudioClip sucess;
    public AudioClip boost;

    private void Start()
    {
        musicSource.clip = background;
        musicSource.Play(); 
    }
    public void PlaySFX(AudioClip clip)
    {
        sfxSource.PlayOneShot(clip);
    }

}
