using UnityEngine;
using System.Collections;

public class Wave : MonoBehaviour {

	public float waveSpeed = 1f;
	public int enemiesToSpawn = 1;

	private int enemiesSpawned = 0;

	// Use this for initialization
	void Start () {
	
	}

	// Update is called once per frame
	void Update () {
	
	}

	// Can I spawn next enemy?
	bool checkWaveVolume()
	{
		if (enemiesSpawned >= enemiesToSpawn) {
			return false;
		}
		return true;
	}

	public bool Spawn(Transform spawnPoint, GameObject prefab)
	{
		bool isSpawned = false;

		if (checkWaveVolume()) {
			GameObject go = Instantiate(prefab, spawnPoint.position, spawnPoint.rotation) as GameObject;
			enemiesSpawned++;

		}

		return isSpawned;
	}
}
