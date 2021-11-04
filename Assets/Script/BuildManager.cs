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

	// vat the thap tieu chuan 1
	public GameObject Turret1Prefabs;
	// vat the thap tieu chuan 2
	public GameObject Turret2Prefabs;

	//Vi du dat tower
	/*void Start()
	{
		turretToBuild = standardTurretPrefabs; 
	}*/

	private TurretBlueprint turretToBuild;
	
	// noi co the dat thap
	public bool CanBuilt { get { return turretToBuild != null; } }

	public void BuildTurretOn(TowerPlace towerPlace)
	{
		GameObject turret = (GameObject)Instantiate(turretToBuild.prefabs, towerPlace.GetBuildPosition(), Quaternion.identity) ;
		towerPlace.turret = turret;
	}
	//Tao noi dat turret
	public void SelectTurretToBuild(TurretBlueprint turret)
	{
		turretToBuild = turret;
	}
}
