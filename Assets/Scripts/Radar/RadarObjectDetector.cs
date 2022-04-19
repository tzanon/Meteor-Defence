using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class RadarObjectDetector : MonoBehaviour
{
	private MeteorDefencePlayer _controls;

	public RadarScreen screen;

	private float _rotateRate = 20f;
	private Vector3 _rotation = Vector3.zero;

	private void OnEnable()
	{
		_controls.Debug.Enable();
	}

	private void OnDisable()
	{
		_controls.Debug.Disable();
	}

	private void Awake()
	{
		_controls = new MeteorDefencePlayer();
	}

	// Start is called before the first frame update
	private void Start()
	{
		if (!screen)
			screen = GetComponentInChildren<RadarScreen>();
	}

	private void FixedUpdate()
	{
		if (_rotation != Vector3.zero)
		{
			transform.Rotate(_rotation * Time.deltaTime);
		}
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.GetComponent<Trackable>())
		{
			screen.AddObjectToScreen(other.gameObject);
		}
	}

	private void OnTriggerExit(Collider other)
	{
		if (other.GetComponent<Trackable>())
		{
			screen.RemoveObjectFromScreen(other.gameObject);
		}
	}

	public void SetRotation(Vector3 direction)
	{
		_rotation = direction * _rotateRate;
	}

	public void AddObjectToTrack()
	{

	}

	public void RemoveObjectFromTracking()
	{

	}

}
