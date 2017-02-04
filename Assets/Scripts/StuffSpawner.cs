using UnityEngine;

public class StuffSpawner : MonoBehaviour {

	public float timeBetweenSpawns;
	public Stuff[] StuffPrefabs;
	public float velocity;

	float timeSinceLastSpawn;


	// Timer for spawner
	void FixedUpdate () {
		timeSinceLastSpawn += Time.deltaTime;
		if (timeSinceLastSpawn >= timeBetweenSpawns) {
			timeSinceLastSpawn -= timeBetweenSpawns;
			SpawnStuff ();
		}
	}

	// Acutal spawner
	void SpawnStuff () {
		// Select item within random range
		Stuff prefab = StuffPrefabs [Random.Range (0, StuffPrefabs.Length)];

		// Spawn it with the prefab.
		Stuff spawn = Instantiate<Stuff> (prefab);
		spawn.transform.localPosition = transform.position;

		// Launch the prefab
		spawn.Body.velocity = transform.up * velocity;
	}
}
