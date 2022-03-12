using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Trackable
{
	

	protected override void Awake()
	{
		_radarType = "Enemy";

		_movementDirection = transform.forward;
		_movementSpeed = 7f;

		base.Awake();
	}

	
}
