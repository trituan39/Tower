using UnityEngine;
using UnityEngine.EventSystems;

public class TowerPlace : MonoBehaviour
{
	//goi mau bao phu
	public Color hoverColor;
	// tao vi tri dat tru 
	private GameObject turret;

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
	void OnMouseDown()
	{
		//Su dung event system de ko bi nhap trung lap vat the vao map
		if (EventSystem.current.IsPointerOverGameObject())
			return;
		//Neu ko co vat the thi tra ve
		if (buildManager.GetTurretToBuild() == null)
			return;

		if (turret != null)
		{
			Debug.Log("Can't build");
			return;
		}
		//Goi vat the tu tien trinh buildManager
		GameObject turretToBuild = buildManager.GetTurretToBuild();
		//dat vi tri vat tai vi tri towerplace
		turret = (GameObject)Instantiate(turretToBuild, transform.position, transform.rotation);
	}

	void OnMouseEnter()
	{
		//Su dung event system de ko bi nhap trung lap vat the vao map
		if (EventSystem.current.IsPointerOverGameObject())
			return;
		//Neu ko co vat the thi tra ve
		if (buildManager.GetTurretToBuild() == null)
			return;
		//khi nhan vao no doi mau 
		rend.material.color = hoverColor;
	}
	void OnMouseExit()
	{
		//khi tha chuot tra ve mau cu
		rend.material.color = starColor;
	}
}