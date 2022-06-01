using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDamageable
{
	const int zeroHealth = 0;
	
	int MaxHealth { get; set; }
	
	int CurrentHealth { get; set; }
	
	void ApplyDamage(int dmgAmount)
	{
		if (CurrentHealth - dmgAmount < zeroHealth)
		{
			Die();
		}
		else
		{
			CurrentHealth -= dmgAmount;
		}
	}
	
	void Heal(int healAmount)
	{
		if (CurrentHealth + healAmount > MaxHealth)
		{
			CurrentHealth = MaxHealth;
		}
		else
		{
			CurrentHealth += healAmount;
		}
	}
	
	void Die();
}
