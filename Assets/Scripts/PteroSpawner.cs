using UnityEngine;

public class PteroSpawner : MonoBehaviour
{
    [SerializeField] GameObject Ptero;
    [SerializeField] Transform spawnPoint;
    [SerializeField] private float spawnRateMin = 5f;
    [SerializeField] private float spawnRateMax = 8f;
    private float spawnRate = 5f;
    private float nextSpawn = 5f;

    void Update()
    {
        spawnRate = Random.Range(spawnRateMin, spawnRateMax);
        if (Time.time > nextSpawn)
            SpawnObstacle();
    }
    private void SpawnObstacle()
    {
        nextSpawn = Time.time + spawnRate;
        Instantiate(Ptero, spawnPoint.position, Quaternion.identity);
    }
}
