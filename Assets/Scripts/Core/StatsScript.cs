using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class StatsScript : MonoBehaviour {

    public float coins = 1000f;
    public Text coinsText;

	// Use this for initialization
	void Start () {
        OnCoinsChanged();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    
    public bool Pay(int price)
    {
        if (coins - price < 0)
        {
            return false;
        }

        coins -= price;
        OnCoinsChanged();
        return true;
    }

    public void AddCredits(int credits)
    {
        coins += credits;
        OnCoinsChanged();
    }

    void OnCoinsChanged()
    {
        coinsText.text = coins.ToString();
    }
}
