using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStat : MonoBehaviour
{
    public static int Money;
    [SerializeField]
    public int startMoney;
	void Start()
	{
		Money = startMoney;
	}
}
