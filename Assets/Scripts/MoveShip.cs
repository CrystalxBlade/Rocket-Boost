using UnityEngine;

public class MoveShip : MonoBehaviour
{
    [SerializeField] float moveSpeed;
    void Start()
    {
        
    }
    void Update()
    {
        transform.Translate(0, 0, -moveSpeed * Time.deltaTime);
    }
}
