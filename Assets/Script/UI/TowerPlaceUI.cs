using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TowerPlaceUI : MonoBehaviour
{
	public GameObject ui;

	public Text upgradeCost;
	public Button upgradeButton;

    private TowerPlace target;



    public void SetTarget(TowerPlace _target)
	{
		target = _target;

		target.GetBuildPosition();

		if (!target.isUpgraded)
		{
			upgradeCost.text = "$" + target.turretBlueprint.upgradeCost;
			upgradeButton.interactable = true;
		}
		else
		{
			upgradeCost.text = "DONE";
			upgradeButton.interactable = false;
		}
			
		ui.SetActive(true);
	}
	public void Hide()
	{
		ui.SetActive(false);
	}

	public void Upgrade()
	{
		target.UpgradeTurret();
		BuildManager.instance.DeselectTowerPlace();
	}
}
