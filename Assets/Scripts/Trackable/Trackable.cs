using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Trackable : MonoBehaviour
{
	protected string _radarType;

	protected float _movementSpeed;

	protected Rigidbody _rb;

	public Vector3 MovementDirection
	{
		get;
		set;
	}

	protected virtual void Awake()
	{
		this.tag = _radarType;

		_rb = GetComponent<Rigidbody>();
		_rb.velocity = MovementDirection * _movementSpeed;
	}

	private void OnDestroy()
	{
		Debug.Log("Trackable object destroyed");
	}
}
