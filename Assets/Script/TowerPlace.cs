using UnityEngine;

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

	void Start()
	{
		//dat rend lay tu sprite render
		rend = GetComponent<SpriteRenderer>();
		starColor = rend.material.color;
	}
	void OnMouseDown()
	{
		if (turret != null)
		{
			Debug.Log("Can't build");
			return;
		}
		//Goi vat the tu tien trinh buildManager
		GameObject turretToBuild = BuildManager.instance.GetTurretToBuild();
		//dat vi tri vat tai vi tri towerplace
		turret = (GameObject)Instantiate(turretToBuild, transform.position, transform.rotation);
	}

	void OnMouseEnter()
	{
		//khi nhan vao no doi mau 
		rend.material.color = hoverColor;
	}
	void OnMouseExit()
	{
		//khi tha chuot tra ve mau cu
		rend.material.color = starColor;
	}
}
