using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStat : MonoBehaviour
{
	//Khai bao so tien hien co
	public static int Money;
	[SerializeField]
	int startMoney;

	//Khai bao so mang bat dau 
	public static int Lives;
	[SerializeField]
	int StartLives;

	void Start()
	{
		Money = startMoney;
		Lives = StartLives;
	}
}