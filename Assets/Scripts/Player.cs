using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [SerializeField] InputAction thrust;

    private void OnEnable()
    {
        thrust.Enable();
    }
    void Update()
    {
        if(thrust.IsPressed())
        {
            Debug.Log("Thrust pressed");
        }
    }
}
