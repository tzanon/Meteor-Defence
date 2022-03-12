using System.Collections.Generic;
using UnityEngine;

public class RadarObjectDetector : MonoBehaviour
{
	public RadarScreen screen;

	private int _dummyIdx = 1;

	// Start is called before the first frame update
	void Start()
	{
		screen = GetComponentInChildren<RadarScreen>();
	}

	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.Return))
		{
			var dummy = GameObject.CreatePrimitive(PrimitiveType.Sphere);
			dummy.AddComponent<Enemy>();
			dummy.transform.position = transform.position + new Vector3(6f * _dummyIdx, 2f * _dummyIdx, 10f * _dummyIdx);
			dummy.name = "dummy " + _dummyIdx;
			_dummyIdx++;

			screen.AddObjectToScreen(dummy);
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
			screen.RemoveObject(other.gameObject);
		}
	}

	public void AddObjectToTrack()
	{

	}

	public void RemoveObjectFromTracking()
	{

	}

}
