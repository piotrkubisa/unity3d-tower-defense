using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class WaveController : MonoBehaviour
{

    public Wave[] waves;
    public GameObject[] spawnPoints;

    public GameObject enemyPrefab;
    public GameObject enemyTankerPrefab;
    public float waveCooldownTime = 10f;
    private float waveCooldownCache;
    private float waveEndedTime;

    public GameObject collectible;
    public Text currentWaveText;

    //[HideInInspector]
    public int currentWave = 0;

    private int enemiesCount = 0;
    private int enemiesKilled = 0;

    // Use this for initialization
    void Awake()
    {
        waveCooldownCache = waveCooldownTime;
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
        currentWaveText.text = (currentWave + 1) + "/" + waves.Length;
        for (int i = 0; i < waves.Length; i++)
        {
            enemiesCount += waves[i].enemiesStandardToSpawn;
            enemiesCount += waves[i].enemiesTankerToSpawn;
        }
    }

    void LateUpdate()
    {
        CallCurrentWave();
    }

    void CallCurrentWave()
    {
        bool ret = waves[currentWave].Enable(this);
        if (!ret)
        {
            NextWave();
        }
    }

    void NextWave()
    {
        if (currentWave >= waves.Length - 1)
        {
            Fin();
        }
        else
        {
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
        }
    }

    public void SkipWaveCooldown()
    {
        waveCooldownTime = 0;
        NextWave();
    }

    void Fin()
    {
        if (enemiesKilled >= enemiesCount)
        {
            Debug.Log("All dead, success");
        }
        Debug.Log("It was last round");
    }

    public void OnEnemyKilled()
    {
        enemiesKilled++;
    }

    void OnWaveChange()
    {
        waveEndedTime = 0;
        currentWave++;
        waveCooldownTime = waveCooldownCache;
        currentWaveText.text = (currentWave + 1) + "/" + waves.Length;
        Debug.Log("Wave " + currentWave + " has started");
    }
}
