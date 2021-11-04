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

	// Tra ve khi qua tien
	public bool HasMoney { get { return PlayerStat.Money >= turretToBuild.cost; } }

	public void BuildTurretOn(TowerPlace towerPlace)
	{
		//Tra ve stat va tra so tien neu ko thi ko dat tower
		if(PlayerStat.Money < turretToBuild.cost)
		{
			Debug.Log("Not enough money!");
			return;
		}
		//Giam so tien sau khi dat tru
		PlayerStat.Money -= turretToBuild.cost;

		GameObject turret = (GameObject)Instantiate(turretToBuild.prefabs, towerPlace.GetBuildPosition(), Quaternion.identity) ;
		towerPlace.turret = turret;

		//bao so tien con lai
		Debug.Log("Turret build! Money left:"+ PlayerStat.Money);
	}
	//Tao noi dat turret
	public void SelectTurretToBuild(TurretBlueprint turret)
	{
		turretToBuild = turret;
	}
}
