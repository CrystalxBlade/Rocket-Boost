using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class Credits : MonoBehaviour
{
    [SerializeField] InputAction home;

    void OnEnable()
    {
        home.Enable();
    }
    void OnDisable()
    {
        home.Disable();
    }
    void Update()
    {
        if(home.IsPressed())
        {
            SceneManager.LoadScene(2);
        }
    }
}
