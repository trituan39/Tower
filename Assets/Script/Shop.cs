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
	public void PurchaseTower1Item()
	{
		buildManager.SetTurretToBuild(buildManager.Turret1Prefabs);
	}
	/// <summary>
	/// Tao Mua another tower
	/// </summary>
	public void PurchaseTower2Item()
	{
		buildManager.SetTurretToBuild(buildManager.Turret2Prefabs);
	}
}
