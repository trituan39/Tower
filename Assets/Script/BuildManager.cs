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

	// vat the thap tieu chuan
	public GameObject Turret1Prefabs;

	public GameObject Turret2Prefabs;

	//Vi du dat tower
	/*void Start()
	{
		turretToBuild = standardTurretPrefabs; 
	}*/

	private GameObject turretToBuild;

    public GameObject GetTurretToBuild()
	{
		return turretToBuild;
	}

	public void SetTurretToBuild(GameObject turret)
	{
		turretToBuild = turret;
	}
}
