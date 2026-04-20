using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [SerializeField] InputAction thrust;
    [SerializeField] InputAction rotation;
    [SerializeField] float thrustForce;
    [SerializeField] float rotationStrength;
    [SerializeField] AudioClip mainEngine;
    [SerializeField] ParticleSystem mainBooster, leftBooster, rightBooster;
    AudioSource audioSource;
    Rigidbody rb;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
    }
    private void OnEnable()
    {
        thrust.Enable();
        rotation.Enable();
    }
    void FixedUpdate()
    {
        ProcessThrust();
        ProcessRotation();
    }
    private void ProcessThrust()
    {
        if (thrust.IsPressed())
        {
            rb.AddRelativeForce(Vector3.up * thrustForce * Time.fixedDeltaTime);
            if(!audioSource.isPlaying)
            { 
                audioSource.PlayOneShot(mainEngine);
                mainBooster.Play();
            }
            else
            {
                audioSource.Stop();
            }
        }
    }
    private void ProcessRotation()
    {
       float rotationInput = rotation.ReadValue<float>();
       if(rotationInput < 0)
        {
            leftBooster.Play();
            ApplyRotation(rotationStrength);
        }
        else if(rotationInput > 0)
        {
            rightBooster.Play(); 
            ApplyRotation(-rotationStrength);
        }
    }
    private void ApplyRotation(float rotateThisFrame)
    {
        rb.freezeRotation = true;
        transform.Rotate(Vector3.forward * rotateThisFrame * Time.fixedDeltaTime);
        rb.freezeRotation = false;
    }
}
