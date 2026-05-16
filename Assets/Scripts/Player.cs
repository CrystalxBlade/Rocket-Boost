using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [SerializeField] InputAction thrust;
    [SerializeField] InputAction rotation;
    [SerializeField] float thrustForce;
    [SerializeField] float rotationStrength;
    [SerializeField] ParticleSystem mainBooster, leftBooster, rightBooster;
    AudioManager am;
    private void Awake()
    {
        am = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }
    Rigidbody rb;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    private void OnEnable()
    {
        thrust.Enable();
        rotation.Enable();
    }
    private void OnDisable()
    {
        thrust.Disable();
        rotation.Disable();
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
            if(!am.sfxSource.isPlaying)
            {
                mainBooster.Play();
                am.PlaySFX(am.boost);
            }
            else
            {
                am.sfxSource.Stop();
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
