using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Trackable : MonoBehaviour
{
	protected string _radarType;

	protected Vector3 _movementDirection;
	protected float _movementSpeed;

	protected Rigidbody _rb;

	protected virtual void Awake()
	{
		this.tag = _radarType;

		_rb = GetComponent<Rigidbody>();
		_rb.velocity = _movementDirection * _movementSpeed;
	}

}
