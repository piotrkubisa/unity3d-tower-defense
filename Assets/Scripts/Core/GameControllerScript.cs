using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameControllerScript : MonoBehaviour {

    //private StatsScript stats;

    public WaveController waveController;
    public GameObject menu;
    public GameObject startScreen;

    [HideInInspector]
    public bool modalSempahore = true;

	// Use this for initialization
	void Awake () {
        Time.timeScale = 1f;
	}

    public void OnClickNextWave()
    {
        waveController.SkipWaveCooldown();
    }

    public void OnShowMenu()
    {
        menu.SetActive(true);
        Time.timeScale = 0f;
        modalSempahore = false;
    }

    public void OnCloseMenu()
    {
        menu.SetActive(false);
        Time.timeScale = 1f;
        modalSempahore = true;
    }

	public void LoadGame()
	{
		Application.LoadLevel (0);
	}

    public void Quit()
    {
        Application.Quit();
    }

    void OnPortalHPChanged()
    {

    }

    void GameOver()
    {
        Time.timeScale = 0.0f;
        startScreen.SetActive(true);
    }

    public void GameOverSuccess()
    {
        GameOver();
    }

    public void GameOverfailed()
    {
        GameOver();
    }
}
