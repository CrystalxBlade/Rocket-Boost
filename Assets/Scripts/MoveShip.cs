using UnityEngine;

public class MoveShip : MonoBehaviour
{
    [SerializeField] Vector3 direction;
    void Update()
    {
        transform.Translate(direction * Time.deltaTime);
        Destroy(gameObject, 10);
    }
}
