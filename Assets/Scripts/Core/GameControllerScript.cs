using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameControllerScript : MonoBehaviour {

	public StatsScript stats;
	public Text coinsText;

    private Tower activeTower;

    public WaveController waveController;
    public Text currentWaveText;

	// Use this for initialization
	void Awake () {
		stats = new StatsScript();
        coinsText.text = stats.coins.ToString();
        currentWaveText.text = waveController.currentWave.ToString();
	}

    public void OnClickNextWave()
    {
        waveController.SkipWaveCooldown();
    }
    public void OnClickUpgradeTower() { }
    public void OnClickConstructTower() { }
    public void OnClickConstructTrap() { }
    public void OnClickUpgradeCancel() { }
    public void OnClickDestroyTower() { }

}
