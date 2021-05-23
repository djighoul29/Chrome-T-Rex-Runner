using UnityEngine;

public class CactusSpawner : MonoBehaviour
{
	[SerializeField] GameObject[] obstacles;
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
		int randomObstacle = Random.Range(0, obstacles.Length);
		Instantiate(obstacles[randomObstacle], spawnPoint.position, Quaternion.identity);
	}
}
