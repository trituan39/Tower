using UnityEngine;

public class BuildManager : MonoBehaviour
{
	public static BuildManager instance;

	void Awake()
	{
		if (instance != null)
		{
			Debug.LogError("Co nhieu buildManager on scenes!");
			return; 
		}
		instance = this;
	}

	//tra ve TurretBlueprint
	private TurretBlueprint turretToBuild;

	//tra ve towerplace
	private TowerPlace selectTowerPlace;

	//Tra ve TowerplaceUI
	public TowerPlaceUI towerPlaceUI;
	
	// noi co the dat thap
	public bool CanBuilt { get { return turretToBuild != null; } }

	// Tra ve bien turretToBuild khi qua hoac bang tien
	public bool HasMoney { get { return PlayerStat.Money >= turretToBuild.cost; }}

	//Chon vi tri Dat tower
	public void SelectTowerPlace(TowerPlace towerPlace)
	{
		if(selectTowerPlace == towerPlace)
		{
			DeselectTowerPlace();
			return;
		}
		selectTowerPlace = towerPlace;
		turretToBuild = null;

		towerPlaceUI.SetTarget(towerPlace);
	}

	public void DeselectTowerPlace()
	{
		selectTowerPlace = null;
		towerPlaceUI.Hide();
	}

	//Tao noi dat turret
	public void SelectTurretToBuild(TurretBlueprint turret)
	{
		turretToBuild = turret;
		DeselectTowerPlace();
	}

	public TurretBlueprint GetTurretToBuild()
	{
		return turretToBuild;
	}
}
