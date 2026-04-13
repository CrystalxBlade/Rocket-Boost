using System;
using UnityEngine;
using UnityEngine.SceneManagement;
public class CollisionHandler : MonoBehaviour
{
    [SerializeField] float delayLvl;
    private void OnCollisionEnter(Collision other)
    {
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
        // todo add sound fx
        GetComponent<Player>().enabled = false;
        Invoke("LoadNextLvl", delayLvl); 
    }
    void CrashState()
    {
        // todo add sound fx
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
