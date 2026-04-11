using UnityEngine;
using UnityEngine.SceneManagement;
public class CollisionHandler : MonoBehaviour
{
    private void OnCollisionEnter(Collision other)
    {
        switch(other.gameObject.tag)
        {
            case "Friendly":
                  Debug.Log("Everything is looking good");
                  break;
            case "Finish":
                  LoadNextLvl();
                  break;
            case "Fuel":
                  Debug.Log("Sorry I don't have any");
                  break;
            default:
                  Invoke("Reload", 4f); 
                  break; 
        }
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
