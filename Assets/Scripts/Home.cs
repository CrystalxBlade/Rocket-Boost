using UnityEngine;
using UnityEngine.SceneManagement;

public class Home : MonoBehaviour
{
    public void Play()
    {
        int lvl = PlayerPrefs.GetInt("Level", 2);
        if(lvl >= 2 && lvl <= 3)
        {
            SceneManager.LoadScene(lvl);
        }
        else if(lvl > 3)
        {
            SceneManager.LoadScene(4);
        }
    }
    public void Levels()
    {
        SceneManager.LoadScene("Levels");
    }
    public void Reset()
    {
        PlayerPrefs.DeleteAll();
    }
    public void Quit()
    {
        Application.Quit();
    }
    public void ToggleSounds(GameObject soundsPanel)
    {
        soundsPanel.SetActive(!soundsPanel.activeSelf);
    }
}
