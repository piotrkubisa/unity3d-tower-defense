using UnityEngine;
using System.Collections;

public class WaveController : MonoBehaviour {

	public Wave[] waves;
	public GameObject[] spawnPoints;

	public GameObject enemyPrefab;
	public GameObject enemyTankerPrefab;
    public float waveCooldownTime = 10f;
    private float waveEndedTime;

	public GameObject collectible;
	
    //[HideInInspector]
	public int currentWave = 0;

	// Use this for initialization
    void Awake()
    {
        // check if not set
        if (spawnPoints.Length < 1)
        {
            spawnPoints = GameObject.FindGameObjectsWithTag(Tag.Respawn);
        }
        if (!collectible)
        {
            collectible = GameObject.FindGameObjectWithTag(Tag.Collectible);
        }
        if (waves.Length < 1)
        {
            waves = Wave.FindObjectsOfType<Wave>();
        }
    }
	
	// Update is called once per frame
	void LateUpdate () {
		CallCurrentWave ();
	}

	void CallCurrentWave()
	{
		bool ret = waves[currentWave].Enable (this);
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
