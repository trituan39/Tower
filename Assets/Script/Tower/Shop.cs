using UnityEngine;

public class Shop : MonoBehaviour
{
	public TurretBlueprint Tower1;
	public TurretBlueprint Tower2;
	public TurretBlueprint Tower3;

	BuildManager buildManager;
	void Start()
	{
		buildManager = BuildManager.instance;
	}

	/// <summary>
	/// Tao Mua tower
	/// </summary>
	public void SelectTower1Item()
	{
		buildManager.SelectTurretToBuild(Tower1);
	}
	/// <summary>
	/// Tao Mua another tower
	/// </summary>
	public void SelectTower2Item()
	{
		buildManager.SelectTurretToBuild(Tower2);
	}
	public void SelectTower3Item()
	{
		buildManager.SelectTurretToBuild(Tower3);
	}
}
