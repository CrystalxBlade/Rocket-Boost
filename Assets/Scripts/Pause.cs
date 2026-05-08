using UnityEngine;
using UnityEngine.SceneManagement;
public class Pause : MonoBehaviour
{
    public void Menu()
    {
        SceneManager.LoadScene("Home");
    }
    public void Quit()
    {
        Application.Quit();
    }
}
