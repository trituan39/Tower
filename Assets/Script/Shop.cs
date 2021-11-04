using UnityEngine;

public class Shop : MonoBehaviour
{
	BuildManager buildManager;
	void Start()
	{
		buildManager = BuildManager.instance;
	}

	/// <summary>
	/// Tao Mua tower
	/// </summary>
	public void PurchaseTowerItem()
	{
		buildManager.SetTurretToBuild(buildManager.standardTurretPrefabs);
	}
	/// <summary>
	/// Tao Mua another tower
	/// </summary>
	public void PurchaseAnotherTowerItem()
	{
		buildManager.SetTurretToBuild(buildManager.anotherTurretPrefabs);
	}
}
