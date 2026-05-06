using Unity.Mathematics;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    [SerializeField] GameObject ship;
    [SerializeField] float spawnTime;
    float timer;
    void Start()
    {
        timer = 0;
        SpawnShip();
    }
    void Update()
    {
        timer += Time.deltaTime;
        if(timer > spawnTime)
        {
            SpawnShip();
            timer = 0;
        }
    }
    void SpawnShip()
    {
        Instantiate(ship, transform.position, Quaternion.Euler(0, 10, 0));
    }
}
