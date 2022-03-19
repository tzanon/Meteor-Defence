using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
	private MeteorDefencePlayer _controlMapping;

	private Vector3 _movementDirection;
	private float _movementSpeed = 2f;

	private float _xMouse, _yMouse;
	private float _lookSensitivity = 8f;
	private Camera _pov;

	private void Awake()
	{
		_pov = GetComponentInChildren<Camera>();

		_xMouse = transform.rotation.eulerAngles.y;
		_yMouse = _pov.transform.rotation.eulerAngles.x;

		_movementDirection = Vector3.zero;

		_controlMapping = new MeteorDefencePlayer();
		//_controlMapping.Player.Move
	}

	private void FixedUpdate()
	{
		if (_movementDirection != Vector3.zero)
		{
			transform.Translate(_movementSpeed * Time.fixedDeltaTime * _movementDirection);
		}
	}

	public void Move(InputAction.CallbackContext context)
	{
		var moveVal = context.ReadValue<Vector2>();

		if (context.performed)
		{
			_movementDirection = new Vector3(moveVal.x, 0f, moveVal.y);
		}
		else if (context.canceled)
		{
			_movementDirection = Vector3.zero;
		}
	}

	public void Look(InputAction.CallbackContext context)
	{
		var mouseDelta = context.ReadValue<Vector2>();

		float deltaX = mouseDelta.x * _lookSensitivity * Time.deltaTime;
		float deltaY = mouseDelta.y * _lookSensitivity * Time.deltaTime;

		_xMouse += deltaX;
		_yMouse = Mathf.Clamp(_yMouse - deltaY, -80f, 80f);

		_pov.transform.localEulerAngles = new Vector3(_yMouse, 0f, 0f);
		transform.localEulerAngles = new Vector3(0f, _xMouse, 0f);

		if (context.performed)
		{
			//Debug.Log("Performed look");
		}
		else if (context.canceled)
		{
			//Debug.Log("Canceled look");
		}
	}

	public void FireWeapon(InputAction.CallbackContext context)
	{
		if (context.performed)
		{
			Debug.Log("Performed firing");
		}
		else if (context.canceled)
		{
			Debug.Log("Canceled firing");
		}
	}

	public void NextWeapon(InputAction.CallbackContext context)
	{

	}

	public void PrevWeapon(InputAction.CallbackContext context)
	{

	}

	public void NextEquipment(InputAction.CallbackContext context)
	{

	}

	public void PrevEquipment(InputAction.CallbackContext context)
	{

	}

}
