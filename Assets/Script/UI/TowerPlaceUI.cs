using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TowerPlaceUI : MonoBehaviour
{
	public GameObject ui;
	//Upgrade Button & Text
	public Text upgradeCost;
	public Button upgradeButton;
	//Sell Button & Text
	public Text sellAmount;

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

		sellAmount.text = "$" + target.turretBlueprint.GetSellAmount();
			
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
	public void Sell()
	{
		target.SellTurret();
		BuildManager.instance.DeselectTowerPlace();
	}
}
