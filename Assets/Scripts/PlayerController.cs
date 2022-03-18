using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
	private float _movementSpeed = 2f;

	private Camera _pov;

	private void Awake()
	{
		_pov = GetComponentInChildren<Camera>();
	}

	// Start is called before the first frame update
	void Start()
	{
		
	}

	// Update is called once per frame
	void Update()
	{
		
	}

	private void FixedUpdate()
	{
		
	}
}
