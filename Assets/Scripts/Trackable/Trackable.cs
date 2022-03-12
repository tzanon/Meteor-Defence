using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Trackable : MonoBehaviour
{
	protected string _radarType;

	protected Vector3 _movementDirection;

	protected virtual void Awake()
	{
		this.tag = _radarType;
	}


}
