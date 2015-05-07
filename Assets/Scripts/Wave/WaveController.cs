using UnityEngine;
using System.Collections;

public class WaveController : MonoBehaviour {

	public Wave[] waves;
	public GameObject[] spawnPoints;

	public GameObject enemyPrefab;
	
	private int currentWave = 0;

	// Use this for initialization
	void Start () {
		// todo: via public DnD variable
		spawnPoints = GameObject.FindGameObjectsWithTag (Tag.Respawn);
	}
	
	// Update is called once per frame
	void LateUpdate () {
		SpawnEnemies ();
	}

	void SpawnEnemies()
	{
		// switch to next / may I spawn next error
		int r = Random.Range (0, this.spawnPoints.Length -1);
		GameObject spawnPoint = spawnPoints [r];

		bool ret = waves[currentWave].Spawn(spawnPoint.transform, enemyPrefab);
		if (false) {
			NextWave();
		}
	}

	void NextWave()
	{
		if (currentWave == waves.Length) {
			// Fin
		} else {
			currentWave++;
		}
	}


	
}
