using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
public class CollisionHandler : MonoBehaviour
{
    [SerializeField] float delayLvl;
    [SerializeField] ParticleSystem crashPartical, successPartical;
    [SerializeField] InputAction escape;
    [SerializeField] GameObject pauseScreen;
    bool pause;
    bool isControllable = true;
    void OnEnable()
    {
        escape.Enable();
    }
    void OnDisable()
    {
        escape.Disable();
    }
    void Start()
    {
        
    }
    void Update()
    {
        RespondToDebugKeys();
        if(escape.WasPressedThisFrame())
        {
            TogglePause();
        }
    }
    void TogglePause()
    {
        pause = !pause;
        pauseScreen.SetActive(pause);
        Time.timeScale = pause ? 0f : 1f;
    }
    void RespondToDebugKeys()
    {
        if(Keyboard.current.lKey.wasPressedThisFrame)
        {
            LoadNextLvl();
        }
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
        successPartical.Play();
        GetComponent<Player>().enabled = false;
        Invoke("LoadNextLvl", delayLvl); 
    }
    void CrashState()
    {
        isControllable = false;
        crashPartical.Play();
        GetComponent<Player>().enabled = false;
        Invoke("Reload", delayLvl);
    }
    void LoadNextLvl()
    {
        int currentScene = SceneManager.GetActiveScene().buildIndex;
        int nextScene = currentScene + 1;
        if(nextScene > PlayerPrefs.GetInt("Level"))
        {
            PlayerPrefs.SetInt("Level", nextScene);
            //SceneManager.LoadScene(nextScene);
        }
        SceneManager.LoadScene(nextScene); 
    }
    void Reload()
    {
        int currentScene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentScene); 
    }
}
