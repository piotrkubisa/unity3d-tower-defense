using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ConstructController : MonoBehaviour {

	public GameObject towerPrefab;
    public GameObject dartTrapPrefab;

    public GameObject trapConstructModal;
    public Text trapConstructError;

    private GameObject currentTrap;

    public GameObject trapModifyModal;
    public Text trapModifyError;
    public float dartTrapDpsUpgrade = 0.125f;

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

    protected void SlowmotionOn()
    {
        Time.timeScale = 0.1f;
    }

    protected void SlowmotionOff()
    {
        Time.timeScale = 1f;
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
        SlowmotionOn();
        trapConstructError.text = "";
        trapConstructModal.SetActive(true);
    }

    public void OnTrapConstructClose()
    {
        currentTrap = null;
        SlowmotionOff();
        trapConstructModal.SetActive(false);
    }

    public void OnDartTrapConstruct()
    {
        bool hasMonies = true;
        if (hasMonies)
        {
            // Prepare
            Renderer rend = currentTrap.GetComponent<Renderer>();
            Vector3 pos = new Vector3(currentTrap.transform.position.x, currentTrap.transform.position.y / 2, currentTrap.transform.position.z);            
            
            // Instantiate
            GameObject go = Instantiate(dartTrapPrefab, pos, currentTrap.transform.rotation) as GameObject;
            DartTrap dt = go.GetComponent<DartTrap>();
            dt.trapPlaceholder = currentTrap;
            dt.cc = this;

            // Hide Placeholder
            //rend.enabled = false;
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

    public void ModifyDartTrap(GameObject dt)
    {
        currentTrap = dt;
        OnDartTrapModifyOpen();        
    }

    public void OnDartTrapModifyOpen()
    {
        SlowmotionOn();
        trapModifyModal.SetActive(true);
        trapConstructError.text = "";
    }

    public void OnDartTrapModifyClose() {
        SlowmotionOff();
        trapModifyModal.SetActive(false);
        currentTrap = null;
    }

    public void OnDartTrapModifyUpgrade()
    {
        bool hasMonies = false;
        if (hasMonies)
        {
            // @todo: remove coins
            Debug.Log("some coins removed");
            DartTrap dt = currentTrap.GetComponent<DartTrap>();
            dt.dps += dartTrapDpsUpgrade;
            OnDartTrapModifyClose();
        }
        else
        {
            trapModifyError.text = "Not enough credits to upgrade attack of this trap.";
        }        
    }

    public void OnDartTrapModifySell()
    { 
        // @todo: addCredits to Base stats
        Debug.Log("some coins added");

        DartTrap dt = currentTrap.GetComponent<DartTrap>();
        dt.trapPlaceholder.SetActive(true);
        Destroy(currentTrap);
        OnDartTrapModifyClose();
    }

    public void ModifyTower(Tower tower)
    {
        // Show UI
    }
}
