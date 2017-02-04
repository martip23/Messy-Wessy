using UnityEngine;

public class StuffSpawner : MonoBehaviour {

	public FloatRange timeBetweenSpawns, scale, randomVelocity, angularVelocity;
	public Stuff[] StuffPrefabs;
	public float velocity;
	public Material stuffMaterial;

	float currentSpawnDelay;
	float timeSinceLastSpawn;


	// Timer for spawner
	void FixedUpdate () {
		timeSinceLastSpawn += Time.deltaTime;
		if (timeSinceLastSpawn >= currentSpawnDelay) {
			timeSinceLastSpawn -= currentSpawnDelay;
			currentSpawnDelay = timeBetweenSpawns.RandomInRange;
			SpawnStuff ();
		}
	}

	// Acutal spawner
	void SpawnStuff () {

		// Select item within random range
		Stuff prefab = StuffPrefabs [Random.Range (0, StuffPrefabs.Length)];

		// Spawn it with the prefab.
		Stuff spawn = Instantiate<Stuff> (prefab);

		spawn.transform.localPosition 	= transform.position;
		spawn.transform.localScale 		= Vector3.one * scale.RandomInRange;
		spawn.transform.localRotation = Random.rotation;

		// Launch the prefab
		spawn.Body.velocity = transform.up * velocity +
			Random.onUnitSphere * randomVelocity.RandomInRange;
		spawn.Body.angularVelocity =
			Random.onUnitSphere * angularVelocity.RandomInRange; 

		spawn.GetComponent<MeshRenderer> ().material = stuffMaterial;
	}
}
