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
        Vector3 pos = transform.position + new Vector3(0, 0, 0);

        Instantiate(ship, pos, Quaternion.identity);
    }
}
