using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class RadarObjectDetector : MonoBehaviour
{
	private MeteorDefencePlayer _controls;

	public RadarScreen screen;

	public GameObject dummyEnemy;
	private int _dummyIdx = 1;

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
		_controls.Debug.SpawnMeteor.performed += SpawnMeteor;

		_controls.Debug.RotateRadar.started += RotateRadar;
		_controls.Debug.RotateRadar.canceled += RotateRadar;
	}

	// Start is called before the first frame update
	private void Start()
	{
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

	private void SpawnMeteor(InputAction.CallbackContext ctx)
	{
		var dummy = Instantiate(dummyEnemy);

		float xCoord = Random.Range(-80f, 60f);
		Vector3 startPos = new Vector3(xCoord, 10f, 120f);

		dummy.transform.position = startPos;
		//dummy.transform.rotation = Quaternion.Euler(0f, 180f, 0f);
		dummy.name = "dummy " + _dummyIdx;
		_dummyIdx++;
	}

	private void RotateRadar(InputAction.CallbackContext ctx)
	{
		if (ctx.started)
		{
			var direction = ctx.ReadValue<float>();
			_rotation = new Vector3(0f, _rotateRate * direction, 0f);
		}
		else if (ctx.canceled)
		{
			_rotation = Vector3.zero;
		}
	}

	public void AddObjectToTrack()
	{

	}

	public void RemoveObjectFromTracking()
	{

	}

}
