using System;
using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;

public class TowerPlace : MonoBehaviour
{
	//goi mau bao phu
	public Color hoverColor;
	//goi mau khi ko du tien mua tower
	public Color notEnoughMoneyColor;

	[HideInInspector]
	// tao vi tri dat tru 
	public GameObject turret;
	[HideInInspector]
	public TurretBlueprint turretBlueprint;
	[HideInInspector]
	public bool isUpgraded = false;

	//dat rend tu spriterender
	private SpriteRenderer rend;
	//goi mau mac dinh
	private Color starColor;

	//Goi buildManager 
	BuildManager buildManager;

	void Start()
	{
		//dat rend lay tu sprite render
		rend = GetComponent<SpriteRenderer>();
		//dat mau default 
		starColor = rend.material.color;
		//dat buildManager de lay tien trinh
		buildManager = BuildManager.instance;
	}

	public Vector2 GetBuildPosition()
	{
		return transform.position;
	}

	void OnMouseDown()
	{
		//Su dung event system de ko bi nhap trung lap vat the vao map
		if (EventSystem.current.IsPointerOverGameObject())
			return;
		
		if (turret != null)
		{
			buildManager.SelectTowerPlace(this);
			return;
		}

		//Neu du tien thi mau hover ko du thi mau notEnoughMoneyColor
		if (buildManager.HasMoney)
		{
			//khi nhan vao no doi mau 
			rend.material.color = hoverColor;
		}
		else
		{
			//Cho mau ko the dat
			rend.material.color = notEnoughMoneyColor;
		}
		//Neu ko co vat the thi tra ve
		if (!buildManager.CanBuilt)
			return;

		BuildTurret(buildManager.GetTurretToBuild());
	}

	void BuildTurret(TurretBlueprint blueprint)
	{
		//Tra ve stat va tra so tien neu ko thi ko dat tower
		if (PlayerStat.Money < blueprint.cost)
		{
			Debug.Log("Not enough money!");
			return;
		}
		//Giam so tien sau khi dat tru
		PlayerStat.Money -= blueprint.cost;

		//Xac dinh vi tri de xay thanh
		GameObject _turret = (GameObject)Instantiate(blueprint.prefabs, GetBuildPosition(), Quaternion.identity);
		turret = _turret;

		turretBlueprint = blueprint;

		//thanh da dc xay
		Debug.Log("Turret build!");
	}

	public void UpgradeTurret()
	{
		//Tra ve stat va tra so tien neu ko thi ko dat tower
		if (PlayerStat.Money < turretBlueprint.upgradeCost)
		{
			Debug.Log("Not enough money to upgrade!");
			return;
		}
		//Giam so tien sau khi dat tru
		PlayerStat.Money -= turretBlueprint.upgradeCost;

		//Xoa thanh cu 
		Destroy(turret);

		//Xay thanh moi dc nang cap
		GameObject _turret = (GameObject)Instantiate(turretBlueprint.upgradedPrefab, GetBuildPosition(), Quaternion.identity);
		turret = _turret;

		isUpgraded = true;

		//thanh da dc nang cap
		Debug.Log("Turret upgrade!");
	}

	void OnMouseEnter()
	{
		//Su dung event system de ko bi nhap trung lap vat the vao map
		if (EventSystem.current.IsPointerOverGameObject())
			return;

		//Neu ko co vat the thi tra ve
		if (buildManager.CanBuilt)
			return;

		//Neu du tien thi mau hover ko du thi mau notEnoughMoneyColor
		if (buildManager.HasMoney)
		{
			//khi nhan vao no doi mau 
			rend.color = hoverColor;
		}
		else
		{
			//Cho mau ko the dat
			rend.color = notEnoughMoneyColor;
		}
	}
	void OnMouseExit()
	{
		//khi tha chuot tra ve mau cu
		rend.material.color = starColor;
	}
}
