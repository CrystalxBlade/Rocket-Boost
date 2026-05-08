using UnityEngine;
using UnityEngine.SceneManagement;
public class Pause : MonoBehaviour
{
    [SerializeField] GameObject pauseScreen;

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            pauseScreen.SetActive(true);
        }
    }
    // public void Resume()
    // {
    //     Time.timeScale = 1f;
    // }
    // public void Menu()
    // {
    //     SceneManager.LoadScene("Home");
    // }
    // public void Quit()
    // {
    //     Application.Quit();
    // }
}
