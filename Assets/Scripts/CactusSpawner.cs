using UnityEngine;

public class CactusSpawner : MonoBehaviour
{
	[SerializeField]
	GameObject[] obstacles;
	[SerializeField]
	Transform spawnPoint;
	[SerializeField]
	float spawnRate = 2f;
	private float nextSpawn;
	void Update()
	{
		if (Time.time > nextSpawn)
			SpawnObstacle();
	}
	void SpawnObstacle()
	{
		nextSpawn = Time.time + spawnRate;
		int randomObstacle = Random.Range(0, obstacles.Length);
		Instantiate(obstacles[randomObstacle], spawnPoint.position, Quaternion.identity);
	}
}
