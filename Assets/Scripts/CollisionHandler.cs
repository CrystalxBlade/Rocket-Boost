using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
public class CollisionHandler : MonoBehaviour
{
    [SerializeField] float delayLvl;
    [SerializeField] AudioClip crash, success;
    AudioSource audioSource;
    bool isControllable = true;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    private void OnCollisionEnter(Collision other)
    {
        if(!isControllable) { return; }

        switch(other.gameObject.tag)
        {
            case "Friendly":
                  Debug.Log("Everything is looking good");
                  break;
            case "Finish":
                  NextLvl();             
                  break;
            case "Fuel":
                  Debug.Log("Sorry I don't have any");
                  break;
            default:
                  CrashState(); 
                  break;
        }
    }
    private void NextLvl()
    {
        isControllable = false;
        audioSource.Stop();
        audioSource.PlayOneShot(success);
        GetComponent<Player>().enabled = false;
        Invoke("LoadNextLvl", delayLvl); 
    }
    void CrashState()
    {
        isControllable = false;
        audioSource.Stop();
        audioSource.PlayOneShot(crash);
        GetComponent<Player>().enabled = false;
        Invoke("Reload", delayLvl);
    }
    void LoadNextLvl()
    {
        int currentScene = SceneManager.GetActiveScene().buildIndex;
        int nextScene = currentScene + 1;
        if(nextScene == SceneManager.sceneCountInBuildSettings)
        {
            nextScene = 0;
        }
        SceneManager.LoadScene(nextScene); 
    }
    void Reload()
    {
        int currentScene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentScene); 
    }
}
