using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class VolumeManager : MonoBehaviour
{
    public Slider musicSlider;
    public Slider sfxSlider;
    public AudioMixer myMixer;

    void Start()
    {
        float savedVolume = PlayerPrefs.GetFloat("musicVolume", 1f);
        musicSlider.value = savedVolume;
        SetMusicVolume();

        float savedSound = PlayerPrefs.GetFloat("sfxVolume", 1f);
        sfxSlider.value = savedSound;
        SetSFXVolume();
    }
    public void SetMusicVolume()
    {
        float volume = musicSlider.value;
        myMixer.SetFloat("music", Mathf.Log10(volume) * 20);
        PlayerPrefs.SetFloat("musicVolume", volume);
    }
    public void SetSFXVolume()
    {
        float sound = sfxSlider.value;
        myMixer.SetFloat("sfx", Mathf.Log10(sound) * 20);
        PlayerPrefs.SetFloat("sfxVolume", sound);
    }
}
