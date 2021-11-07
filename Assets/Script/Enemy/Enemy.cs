using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
	[HideInInspector]
	//Toc do quai
    public float speed = 0.5f;
	//Mau bat dau
	public int startHealth;
	//Mau
	private float health;
	//Cost enemy die
	public int worth;

	[Header("Unity Stuff")]
	public Image healthBar;

	void Start()
	{
		health = startHealth;
	}

	// Nhan dame
	public void TakeDamage(int amount)
	{
		health -= amount;

		healthBar.fillAmount = health / startHealth;

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
