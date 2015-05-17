using UnityEngine;
using System.Collections;

public class Wave : MonoBehaviour {

	public float waveSpeed = 1f;
    public float spawnDuration = 2f;
	public int enemiesStandarToSpawn = 1;
    public int enemiesTankerToSpawn = 0;

	private int enemiesSpawned = 0;
    private float lastSpawnTime;

	// Use this for initialization
	void Start () {
        lastSpawnTime = Time.time;
	}

	// Can I spawn next enemy?
	bool checkWaveVolume()
	{
        if (enemiesSpawned >= enemiesStandarToSpawn + enemiesTankerToSpawn)
        {
            return false;
        }

		return true;
	}

	public bool Spawn(Transform spawnPoint, GameObject prefab)
	{
		bool canSpawn = checkWaveVolume();

        if (canSpawn)
        {
            if (Time.time > lastSpawnTime + spawnDuration)
            {
                // just spawn it!
                Instantiate(prefab, spawnPoint.position, spawnPoint.rotation);
                lastSpawnTime = Time.time;
                enemiesSpawned++;
            }
		}

		return canSpawn;
	}
}
