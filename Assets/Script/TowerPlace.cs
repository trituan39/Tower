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

	[Header("Optional")]
	// tao vi tri dat tru 
	public GameObject turret;

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
		//Neu ko co vat the thi tra ve
		if (!buildManager.CanBuilt)
			return;
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

		if (turret != null)
		{
			Debug.Log("Can't build");
			return;
		}
		buildManager.BuildTurretOn(this);
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
			rend.material.color = hoverColor;
		}else
		{
			//Cho mau ko the dat
			rend.material.color = notEnoughMoneyColor;
		}
	}
	void OnMouseExit()
	{
		//khi tha chuot tra ve mau cu
		rend.material.color = starColor;
	}
}
