using UnityEngine;
using UnityEngine.SceneManagement;
public class Pause : MonoBehaviour
{
    public void Menu()
    {
        SceneManager.LoadScene("Home");
        Time.timeScale = 1f;
    }
    public void Quit()
    {
        Application.Quit();
    }
}
