using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [SerializeField] InputAction thrust;
    Rigidbody rb;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    private void OnEnable()
    {
        thrust.Enable();
    }
    void FixedUpdate()
    {
        if(thrust.IsPressed())
        {
            rb.AddRelativeForce(0, 0.2f, 0);
        }
    }
}
