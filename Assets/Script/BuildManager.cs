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
	public GameObject standardTurretPrefabs;

	void Start()
	{
		turretToBuild = standardTurretPrefabs; 
	}

	private GameObject turretToBuild;

    public GameObject GetTurretToBuild()
	{
		return turretToBuild;
	}
}
