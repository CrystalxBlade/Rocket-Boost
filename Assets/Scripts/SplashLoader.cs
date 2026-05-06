using UnityEngine;
using UnityEngine.SceneManagement;
public class SplashLoader : MonoBehaviour
{
    [SerializeField] float delay = 10f;
    [SerializeField] string nextScene = "Menu";
    void Start()
    {
        Invoke("LoadNext", delay);
    }
    void LoadNext()
    {
        SceneManager.LoadScene(nextScene);
    }
}
