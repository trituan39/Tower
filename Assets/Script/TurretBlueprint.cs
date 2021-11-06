using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class TurretBlueprint 
{
    //Lay tower tu prefabs
    public GameObject prefabs;
    //ghi gia tien
    public int cost;

    //Vat the thanh dc nang cap
    public GameObject upgradedPrefab;
    //So tien Upgrade
    public int upgradeCost;

    public int GetSellAmount()
	{
        return (cost+upgradeCost)/2;
	}
}
