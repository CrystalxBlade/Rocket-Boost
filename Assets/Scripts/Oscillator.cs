using Unity.Mathematics;
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
        movementfactor = Mathf.PingPong(Time.time * speed, 1);
        transform.position = Vector3.Lerp(startPos, endPos, movementfactor);
    }
}
