using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameControllerScript : MonoBehaviour {

	public StatsScript stats;
	public Text coinsText;

    private Tower activeTower;

    public WaveController waveController;
    public Text currentWaveText;

    public GameObject menu;

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

    public void OnShowMenu()
    {
        menu.SetActive(true);
        Time.timeScale = 0f;
    }

    public void OnCloseMenu()
    {
        menu.SetActive(false);
        Time.timeScale = 1f;
    }

    public void Quit()
    {
        Application.Quit();
    }

}
