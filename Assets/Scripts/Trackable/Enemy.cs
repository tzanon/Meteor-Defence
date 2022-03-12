using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Trackable
{
	protected override void Awake()
	{
		_radarType = "Enemy";

		MovementDirection = transform.forward;
		_movementSpeed = 6f;

		base.Awake();
	}

	
}
