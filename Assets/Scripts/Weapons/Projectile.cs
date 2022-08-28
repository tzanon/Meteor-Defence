using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
	private int _damage;
	
	private float _movementSpeed;
	
	private Rigidbody _rb;
	
	private void Awake()
	{
		_rb = GetComponent<Rigidbody>();
		_rb.velocity = transform.forward * _movementSpeed;
	}
	
    // Start is called before the first frame update
    void Start()
    {
		
    }

    // Update is called once per frame
    void Update()
    {
        
    }
	
	private void OnCollisionEnter(Collision other)
	{
		
	}
}
