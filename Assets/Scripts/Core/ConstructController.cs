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

    public GameObject dartTrapModifyModal;
    public Text dartTrapModifyError;
    public GameObject iceTrapModifyModal;
    public Text iceTrapModifyError;

    private GameObject currentTower;
    public GameObject towerConstructModal;
    public Text towerConstructError;

    public GameObject watchTowerModifyModal;
    public Text watchTowerModifyError;
    public GameObject guardTowerModifyModal;
    public Text guardTowerModifyError;

    private GameControllerScript gcs;
    private StatsScript stats;

    void Awake()
    {
        gcs = GetComponent<GameControllerScript>();
        stats = GetComponent<StatsScript>();
    }

    // Modal
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

    // Construct Trap
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
        int prefabCost = dartTrapPrefab.GetComponent<DartTrap>().cost;
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
        int prefabCost = iceTrapPrefab.GetComponent<IceTrap>().cost;
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

    // Dart Trap
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
            dartTrapModifyModal.SetActive(true);
            trapConstructError.text = "";
        }
    }

    public void OnDartTrapModifyClose()
    {
        HideModal();
        dartTrapModifyModal.SetActive(false);
        currentTrap = null;
    }

    public void OnDartTrapModifyUpgrade()
    {
        int cost = dartTrapPrefab.GetComponent<DartTrap>().dpsUpgradeCost;
        if (stats.Pay(cost))
        {
            DartTrap dt = currentTrap.GetComponent<DartTrap>();
            dt.Upgrade();
            OnDartTrapModifyClose();
        }
        else
        {
            dartTrapModifyError.text = "Not enough credits to upgrade attack of this trap.";
        }
    }

    public void OnDartTrapModifySell()
    {
        DartTrap dt = currentTrap.GetComponent<DartTrap>();
        stats.AddCredits(dt.cost);
        if (dt.trapPlaceholder)
        {
            dt.trapPlaceholder.SetActive(true);
        }
        Destroy(currentTrap);
        OnDartTrapModifyClose();
    }

    // Ice Trap
    // ============================================================

    public void ModifyIceTrap(GameObject dt)
    {
        currentTrap = dt;
        OnIceTrapModifyOpen();
    }

    public void OnIceTrapModifyOpen()
    {
        if (gcs.modalSempahore)
        {
            ShowModal();
            iceTrapModifyModal.SetActive(true);
            trapConstructError.text = "";
        }
    }

    public void OnIceTrapModifyClose()
    {
        HideModal();
        iceTrapModifyModal.SetActive(false);
        currentTrap = null;
    }

    public void OnIceTrapModifyUpgrade()
    {
        int cost = iceTrapPrefab.GetComponent<IceTrap>().iceSpeedUpgradeCost;
        if (stats.Pay(cost))
        {
            IceTrap it = currentTrap.GetComponent<IceTrap>();
            if (it.Upgrade())
            {
                OnIceTrapModifyClose();
            }
            else
            {
                stats.AddCredits(cost);
                iceTrapModifyError.text = "Reached maximum level of upgrade.";
            }
        }
        else
        {
            iceTrapModifyError.text = "Not enough credits to upgrade this trap.";
        }
    }

    public void OnIceTrapModifySell()
    {
        IceTrap dt = currentTrap.GetComponent<IceTrap>();
        stats.AddCredits(dt.cost);
        if (dt.trapPlaceholder)
        {
            dt.trapPlaceholder.SetActive(true);
        }
        Destroy(currentTrap);
        OnIceTrapModifyClose();
    }

    // Construct Tower
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
        int prefabCost = (watchTowerPrefab.GetComponent<TowerEvents>().tower as WatchTower).cost;
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
        int prefabCost = (guardTowerPrefab.GetComponent<TowerEvents>().tower as GuardTower).cost;
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

    // Watch Tower
    // ============================================================

    public void ModifyWatchTower(GameObject tower)
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
        WatchTower wt = currentTower.GetComponent<WatchTower>();
        stats.AddCredits(wt.cost);
        if (wt.towerPlaceholder)
        {
            wt.towerPlaceholder.SetActive(true);
        }
        Destroy(currentTower.GetComponentInParent<TowerEvents>().gameObject);
        OnWatchTowerModifyClose();
    }

    public void OnWatchTowerModifyUpgrade()
    {
        WatchTower wt = currentTower.GetComponent<WatchTower>();
        if (wt && stats.Pay(wt.dpsUpgradeCost))
        {
            wt.Upgrade();
            OnWatchTowerModifyClose();
        }
        else
        {
            watchTowerModifyError.text = "Not enough credits to upgrade attack of this Tower.";
        }
    }

    public void OnWatchTowerModifyClose()
    {
        HideModal();
        currentTower = null;
        watchTowerModifyModal.SetActive(false);
    }

    // Guard Tower
    // ============================================================

    public void ModifyGuardTower(GameObject tower)
    {
        currentTower = tower;
        OnGuardTowerModifyOpen();
    }

    public void OnGuardTowerModifyOpen()
    {
        if (gcs.modalSempahore)
        {
            ShowModal();
            guardTowerModifyError.text = "";
            guardTowerModifyModal.SetActive(true);
        }
    }

    public void OnGuardTowerModifySell()
    {
        GuardTower gt = currentTower.GetComponent<GuardTower>();
        stats.AddCredits(gt.cost);
        if (gt.towerPlaceholder)
        {
            gt.towerPlaceholder.SetActive(true);
        }
        Destroy(currentTower.GetComponentInParent<TowerEvents>().gameObject);
        OnGuardTowerModifyClose();
    }

    public void OnGuardTowerModifyUpgrade()
    {
        GuardTower gt = currentTower.GetComponent<GuardTower>();
        if (gt && stats.Pay(gt.dpsUpgradeCost))
        {
            gt.Upgrade();
            OnGuardTowerModifyClose();
        }
        else
        {
            guardTowerModifyError.text = "Not enough credits to upgrade attack of this Tower.";
        }
    }

    public void OnGuardTowerModifyClose()
    {
        HideModal();
        currentTower = null;
        guardTowerModifyModal.SetActive(false);
    }
}
