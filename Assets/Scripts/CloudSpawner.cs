using UnityEngine;

public class CloudSpawner : MonoBehaviour
{
    [SerializeField] GameObject Cloud;
    [SerializeField] Transform spawnPoint;
    [SerializeField] private float spawnRateMin = 3f;
    [SerializeField] private float spawnRateMax = 8f;
    private float spawnRate = 5f;
    private float nextSpawn = 5f;

    void Update()
    {
        spawnRate = Random.Range(spawnRateMin, spawnRateMax);
        if (Time.time > nextSpawn)
            SpawnCloud();
    }
    private void SpawnCloud()
    {
        nextSpawn = Time.time + spawnRate;
        Instantiate(Cloud, spawnPoint.position, Quaternion.identity);
    }
}
