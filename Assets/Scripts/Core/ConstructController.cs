using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ConstructController : MonoBehaviour {

	public GameObject towerPrefab;
    public GameObject dartTrapPrefab;

    public GameObject trapConstructModal;
    public Text trapConstructError;

    private GameObject currentTrap;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public bool SpawnTower(GameObject placeholder)
	{
		bool isSpawned = true;

		// TowerPrefab Menu

		Renderer rend = placeholder.GetComponent<Renderer> ();
		Vector3 pos = new Vector3 (placeholder.transform.position.x, placeholder.transform.position.y / 2, placeholder.transform.position.z);
		rend.enabled = false; // should go to TowerPlaceholder

		Instantiate(towerPrefab, pos, Quaternion.identity);

		return isSpawned;
	}

    public void SpawnTrap(GameObject placeholder)
    {
        currentTrap = placeholder;
        OnTrapConstructOpen();

        /*
        Renderer rend = placeholder.GetComponent<Renderer>();
        Vector3 pos = new Vector3(placeholder.transform.position.x, placeholder.transform.position.y / 2, placeholder.transform.position.z);
        rend.enabled = false; // should go to TrapPlaceholder

        Instantiate(trapPrefab, pos, placeholder.transform.rotation);
         */
    }

    public void OnTrapConstructOpen()
    {
        Time.timeScale = 0.1f;
        trapConstructError.text = "";
        trapConstructModal.SetActive(true);
    }

    public void OnTrapConstructClose()
    {
        currentTrap = null;
        Time.timeScale = 1f;
        trapConstructModal.SetActive(false);
    }

    public void OnDartTrapConstruct()
    {
        bool hasMonies = false;
        if (hasMonies)
        {
            Renderer rend = currentTrap.GetComponent<Renderer>();
            Vector3 pos = new Vector3(currentTrap.transform.position.x, currentTrap.transform.position.y / 2, currentTrap.transform.position.z);
            rend.enabled = false;
            Instantiate(dartTrapPrefab, pos, currentTrap.transform.rotation);
            currentTrap.SetActive(false);
            OnTrapConstructClose();
        }
        else
        {
            trapConstructError.text = "Not enough credits to construct dart trap.";
        }
    }

    public void OnIceTrapConstruct()
    {
        bool hasMonies = true;
        if (hasMonies)
        {
            trapConstructError.text = "Not enough credits to construct ice trap.";
        }
    }

    public void ModifyTower(Tower tower)
    {
        // Show UI
    }
}
