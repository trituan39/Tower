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

	private bool isDead = false;

	void Start()
	{
		health = startHealth;
	}

	// Nhan dame
	public void TakeDamage(int amount)
	{
		health -= amount;

		healthBar.fillAmount = health / startHealth;

		if(health <= 0 && !isDead)
		{
			Die();
		}
	}

	//Chet
	void Die()
	{
		isDead = true;

		PlayerStat.Money += worth;

		WaveSpawner.EnemiesAlive--;

		Destroy(gameObject);
	}
}
