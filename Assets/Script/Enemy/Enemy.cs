using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
	//Toc do ban dau
	public float startSpeed = 1f;
	[HideInInspector]
	//Toc do quai
	public float speed;
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
		speed = startSpeed;
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
	
	public void Slow(float pct)
	{
		speed = startSpeed * (1f - pct);
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
