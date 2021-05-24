using UnityEngine;

public class CactusSpawner : MonoBehaviour
{
	[SerializeField] GameObject[] cactuses;
	[SerializeField] Transform spawnPoint;
	[SerializeField] private float spawnRateMin = 0.75f;
	[SerializeField] private float spawnRateMax = 1.1f;
	private float spawnRate = 1f;
	private float nextSpawn = 1f;

    private void Update()
	{
		spawnRate = Random.Range(spawnRateMin, spawnRateMax);
		if (Time.time > nextSpawn)
			SpawnObstacle();
	}
	private void SpawnObstacle()
	{
		nextSpawn = Time.time + spawnRate;
		int randomCactus = Random.Range(0, cactuses.Length);
		Instantiate(cactuses[randomCactus], spawnPoint.position, Quaternion.identity);
	}
}
