using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ConstructController : MonoBehaviour
{

    public GameObject watchTowerPrefab;
    public GameObject guardTowerPrefab;
    public GameObject dartTrapPrefab;
    public GameObject iceTrapPrefab;

    public GameObject trapConstructModal;
    public Text trapConstructError;

    private GameObject currentTrap;

    public GameObject trapModifyModal;
    public Text trapModifyError;
    public float dartTrapDpsUpgrade = 0.125f;

    private GameObject currentTower;
    public GameObject towerConstructModal;
    public Text towerConstructError;

    public GameObject watchTowerModifyModal;
    public Text watchTowerModifyError;
    public float watchTowerDpsUpgrade = 5f;

    private GameControllerScript gcs;
    private StatsScript stats;

    // Use this for initialization
    void Awake()
    {
        gcs = GetComponent<GameControllerScript>();
        stats = GetComponent<StatsScript>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    // ===========================================================

    protected void ShowModal()
    {
        Time.timeScale = 0.1f;
        gcs.modalSempahore = false;
    }

    protected void HideModal()
    {
        Time.timeScale = 1f;
        gcs.modalSempahore = true;
    }

    // ============================================================

    public void SpawnTrap(GameObject placeholder)
    {
        currentTrap = placeholder;
        OnTrapConstructOpen();
    }

    public void OnTrapConstructOpen()
    {
        if (gcs.modalSempahore)
        {
            ShowModal();
            trapConstructError.text = "";
            trapConstructModal.SetActive(true);
        }
    }

    public void OnTrapConstructClose()
    {
        currentTrap = null;
        HideModal();
        trapConstructModal.SetActive(false);
    }

    public void OnDartTrapConstruct()
    {
        int prefabCost = 200;
        if (stats.Pay(prefabCost))
        {
            // Prepare
            Vector3 pos = new Vector3(currentTrap.transform.position.x, currentTrap.transform.position.y / 2, currentTrap.transform.position.z);

            // Instantiate
            GameObject go = Instantiate(dartTrapPrefab, pos, currentTrap.transform.rotation) as GameObject;
            DartTrap dt = go.GetComponent<DartTrap>();
            dt.trapPlaceholder = currentTrap;
            dt.cc = this;

            // Hide Placeholder
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
        int prefabCost = 200;
        if (stats.Pay(prefabCost))
        {
            // Prepare
            Vector3 pos = new Vector3(currentTrap.transform.position.x, currentTrap.transform.position.y / 2, currentTrap.transform.position.z);

            // Instantiate
            GameObject go = Instantiate(iceTrapPrefab, pos, currentTrap.transform.rotation) as GameObject;
            IceTrap it = go.GetComponent<IceTrap>();
            it.trapPlaceholder = currentTrap;
            it.cc = this;

            // Hide Placeholder
            currentTrap.SetActive(false);
            OnTrapConstructClose();
        }
        else
        {
            trapConstructError.text = "Not enough credits to construct ice trap.";
        }
    }

    // ============================================================

    public void ModifyDartTrap(GameObject dt)
    {
        currentTrap = dt;
        OnDartTrapModifyOpen();
    }

    public void OnDartTrapModifyOpen()
    {
        if (gcs.modalSempahore)
        {
            ShowModal();
            trapModifyModal.SetActive(true);
            trapConstructError.text = "";
        }
    }

    public void OnDartTrapModifyClose()
    {
        HideModal();
        trapModifyModal.SetActive(false);
        currentTrap = null;
    }

    public void OnDartTrapModifyUpgrade()
    {
        int prefabCost = 200;
        if (stats.Pay(prefabCost))
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
        stats.AddCredits(200);

        DartTrap dt = currentTrap.GetComponent<DartTrap>();
        dt.trapPlaceholder.SetActive(true);
        Destroy(currentTrap);
        OnDartTrapModifyClose();
    }

    // ============================================================

    public void SpawnTower(GameObject placeholder)
    {
        currentTower = placeholder;
        OnTowerConstructOpen();
    }

    public void OnTowerConstructOpen()
    {
        if (gcs.modalSempahore)
        {
            ShowModal();
            towerConstructError.text = "";
            towerConstructModal.SetActive(true);
        }
    }

    public void OnWatchTowerConstruct()
    {
        int prefabCost = 200;
        if (stats.Pay(prefabCost))
        {
            // Prepare
            Vector3 pos = new Vector3(currentTower.transform.position.x, currentTower.transform.position.y / 2, currentTower.transform.position.z);

            // Instantiate
            GameObject go = Instantiate(watchTowerPrefab, pos, Quaternion.identity) as GameObject;
            WatchTower wt = go.GetComponentInChildren<WatchTower>();
            wt.towerPlaceholder = currentTower;
            wt.cc = this;

            // Hide Placeholder
            currentTower.SetActive(false);
            OnTowerConstructClose();
        }
        else
        {
            towerConstructError.text = "Not enough credits to  construct Watch Tower.";
        }
    }

    public void OnGuardTowerConstruct()
    {
        int prefabCost = 200;
        if (stats.Pay(prefabCost))
        {
            // Prepare
            Vector3 pos = new Vector3(currentTower.transform.position.x, currentTower.transform.position.y / 2, currentTower.transform.position.z);

            // Instantiate
            GameObject go = Instantiate(guardTowerPrefab, pos, Quaternion.identity) as GameObject;
            GuardTower gt = go.GetComponentInChildren<GuardTower>();
            gt.towerPlaceholder = currentTower;
            gt.cc = this;

            // Hide Placeholder
            currentTower.SetActive(false);
            OnTowerConstructClose();
        }
        else
        {
            towerConstructError.text = "Not enough credits to  construct Guard Tower.";
        }
    }

    public void OnTowerConstructClose()
    {
        HideModal();
        currentTower = null;
        towerConstructModal.SetActive(false);
    }

    // ============================================================

    public void ModifyTower(GameObject tower)
    {
        currentTower = tower;
        OnWatchTowerModifyOpen();
    }

    public void OnWatchTowerModifyOpen()
    {
        if (gcs.modalSempahore)
        {
            ShowModal();
            watchTowerModifyError.text = "";
            watchTowerModifyModal.SetActive(true);
        }
    }

    public void OnWatchTowerModifySell()
    {
        // @todo: addCredits to Base stats
        stats.AddCredits(200);

        WatchTower wt = currentTower.GetComponent<WatchTower>();
        wt.towerPlaceholder.SetActive(true);
        Destroy(currentTower.GetComponentInParent<TowerEvents>().gameObject);
        OnWatchTowerModifyClose();
    }

    public void OnWatchTowerModifyUpgrade()
    {
        int prefabCost = 200;
        if (stats.Pay(prefabCost))
        {
            // @todo: remove coins
            Debug.Log("some coins removed");
            WatchTower wt = currentTower.GetComponent<WatchTower>();
            wt.dps += watchTowerDpsUpgrade;
            OnWatchTowerModifyClose();
        }
        else
        {
            watchTowerModifyError.text = "Not enough credits to upgrade attack of this Watch Tower.";
        }
    }

    public void OnWatchTowerModifyClose()
    {
        HideModal();
        currentTower = null;
        watchTowerModifyModal.SetActive(false);
    }
}
