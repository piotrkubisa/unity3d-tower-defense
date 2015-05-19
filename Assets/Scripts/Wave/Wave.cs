using UnityEngine;
using System.Collections;

public class Wave : MonoBehaviour {

	public float waveSpeed = 1f;
    public float spawnDuration = 2f;
	public int enemiesStandardToSpawn = 1;
    public int enemiesTankerToSpawn = 0;

	private int enemiesSpawned = 0;
    private float lastSpawnTime;
	public WaveController waveController;

	private bool spawnerEnabled = false;

	// Use this for initialization
	void Start () {
        lastSpawnTime = Time.time;
	}

	// Can I spawn next enemy?
	public bool checkWaveVolume()
	{
        if ((enemiesStandardToSpawn + enemiesTankerToSpawn)<=0)
        {
            return false;
        }

		return true;
	}

	void LateUpdate()
	{
		if (spawnerEnabled) {
			if (!Spawn()) {
				Disable();
			}
		} 
	}

	public bool Enable(WaveController wc)
	{
		if (!waveController) {
			waveController = wc;
		}
		if (spawnerEnabled) {
			if (!checkWaveVolume ()) {
				// I cannot spawn more, and i am going to be disabled
				spawnerEnabled = false;
			}
		} else {
			spawnerEnabled = true;
		}

		return spawnerEnabled;
	}

	public void Disable()
	{
		this.gameObject.SetActive(false);
		spawnerEnabled = false;;
	}

	GameObject GetNextEnemyPrefab() {
		if (enemiesTankerToSpawn > 0 && enemiesStandardToSpawn > 0) {
			int r = Random.Range (0, 5);
			if (r < 4) {
				enemiesStandardToSpawn--;
				return waveController.enemyPrefab;
			} else {
				enemiesTankerToSpawn--;
				return waveController.enemyTankerPrefab;
			}
		} else if (enemiesStandardToSpawn <= 0) { 
			enemiesTankerToSpawn--;
			return waveController.enemyTankerPrefab;
		} else {
			enemiesStandardToSpawn--;
			return waveController.enemyPrefab;
		}
	}

	public bool Spawn()
	{
		bool canSpawn = checkWaveVolume();

        if (canSpawn)
        {
            if (Time.time > lastSpawnTime + spawnDuration)
            {
				int r = Random.Range (0, waveController.spawnPoints.Length);
				GameObject spawnPoint = waveController.spawnPoints [r];

				GameObject prefab = GetNextEnemyPrefab();
				EnemyBehaviourScript eb = prefab.gameObject.GetComponent<EnemyBehaviourScript>();
				eb.targetCollectible = waveController.collectible;

                // just spawn it!
				Instantiate(prefab, spawnPoint.transform.position, spawnPoint.transform.rotation);
                lastSpawnTime = Time.time;
                enemiesSpawned++;
            }
		}

		return canSpawn;
	}
}
