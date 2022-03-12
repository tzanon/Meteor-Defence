using System.Collections.Generic;
using UnityEngine;

public class RadarObjectDetector : MonoBehaviour
{
	public RadarScreen screen;

	private int _dummyIdx = 0;

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
			dummy.transform.position = new Vector3(0f, 4f, 6f);
			dummy.name = "dummy " + _dummyIdx++;

			screen.AddObjectToScreen(dummy);
		}
	}

	private void OnTriggerEnter(Collider other)
	{
		
	}

	private void OnTriggerExit(Collider other)
	{
		
	}

	public void AddObjectToTrack()
	{

	}

	public void RemoveObjectFromTracking()
	{

	}

}
