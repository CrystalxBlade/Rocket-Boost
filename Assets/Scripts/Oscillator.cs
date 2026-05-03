using UnityEngine;

public class Oscillator : MonoBehaviour
{
    [SerializeField] Vector3 movementVector;
    [SerializeField] float speed;
    Vector3 startPos;
    Vector3 endPos; 
    float movementfactor;
    void Start()
    {
        startPos = transform.position;
        endPos = startPos + movementVector;
    }
    void Update()
    {
        
        transform.position = Vector3.Lerp(startPos, endPos, movementfactor);
    }
}
