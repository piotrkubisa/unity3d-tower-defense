using UnityEngine;
using System.Collections;

public class Wave : MonoBehaviour {

	public float waveSpeed = 1f;
    public float spawnDuration = 2f;
	public int enemiesToSpawn = 1;

	private int enemiesSpawned = 0;
    private float lastSpawnTime;

	// Use this for initialization
	void Start () {
        lastSpawnTime = Time.time;
	}

	// Update is called once per frame
	void Update () {
	
	}

	// Can I spawn next enemy?
	bool checkWaveVolume()
	{
        if (enemiesSpawned >= enemiesToSpawn)
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
                GameObject go = Instantiate(prefab, spawnPoint.position, spawnPoint.rotation) as GameObject;
                lastSpawnTime = Time.time;
                enemiesSpawned++;
            }
		}

		return canSpawn;
	}
}
