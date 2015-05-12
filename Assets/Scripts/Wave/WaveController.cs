using UnityEngine;
using System.Collections;

public class WaveController : MonoBehaviour {

	public Wave[] waves;
	public GameObject[] spawnPoints;

	public GameObject enemyPrefab;
    public float waveCooldownTime = 10f;
    private float waveEndedTime;
	
    //[HideInInspector]
	public int currentWave = 0;

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
		int r = Random.Range (0, this.spawnPoints.Length);
		GameObject spawnPoint = spawnPoints [r];

		bool ret = waves[currentWave].Spawn(spawnPoint.transform, enemyPrefab);
		if (!ret) {
			NextWave();
		}
	}

	void NextWave()
	{        
		if (currentWave >= waves.Length -1) {
            Fin();
		} else {
            if (waveEndedTime == 0)
            {
                waveEndedTime = Time.time;    
            }            
            Cooldown();
		}
	}

    void Cooldown()
    {
        if (Time.time > waveEndedTime + waveCooldownTime)
        {
            OnWaveChange();            
            waveEndedTime = 0;
        }        
    }

    public void SkipWaveCooldown()
    {
        // @todo: untoggle in Wave
        waveCooldownTime = 0;
    }

    void Fin()
    {
        Debug.Log("It was last round");
    }

    void OnWaveChange()
    {
        currentWave++;
        Debug.Log("Wave " + currentWave + " has started");
    }
}
