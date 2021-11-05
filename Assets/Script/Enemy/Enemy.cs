using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
	//Toc do quai
    public float speed = 0.5f;

	//Mau
	public int health;

	//Cost enemy die
	public int worth;

	// Nhan dame
	public void TakeDamage(int amount)
	{
		health -= amount;

		if(health <= 0)
		{
			Die();
		}
	}

	//Chet
	void Die()
	{
		PlayerStat.Money += worth; 
		Destroy(gameObject);
	}
}
