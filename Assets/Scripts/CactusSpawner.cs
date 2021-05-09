using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CactusSpawner : MonoBehaviour
{
	[SerializeField]
	GameObject[] obstacles;
	[SerializeField]
	Transform spawnPoint;
	[SerializeField]
	float spawnRate = 2f;
	private float nextSpawn;
	private float speed = 15f;
	void Update()
	{
		transform.position = new Vector2(transform.position.x + speed * Time.deltaTime, transform.position.y);
		if (transform.position.x < -13f)
			Destroy(gameObject);
	}
	void SpawnObstacle()
	{
		nextSpawn = Time.time + spawnRate;
		int randomObstacle = Random.Range(0, obstacles.Length);
		Instantiate(obstacles[randomObstacle], spawnPoint.position, Quaternion.identity);
	}
}
