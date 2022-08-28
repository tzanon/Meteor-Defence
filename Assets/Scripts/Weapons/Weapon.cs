using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
	private float _fireRate;
	
	private float _accuracy;
	
	private GameObject _target;
	
	private void CalculateTarget()
	{
		
	}
	
	public abstract void Fire();
	
	public virtual void Secondary() {}
}
