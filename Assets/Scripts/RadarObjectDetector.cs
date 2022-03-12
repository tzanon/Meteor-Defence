using System.Collections.Generic;
using UnityEngine;

public class RadarObjectDetector : MonoBehaviour
{
	public RadarScreen screen;

	public GameObject dummyEnemy;
	private int _dummyIdx = 1;

	private float _rotateRate = 20f;

	// Start is called before the first frame update
	void Start()
	{
		screen = GetComponentInChildren<RadarScreen>();
	}

	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.Return))
		{
			var dummy = Instantiate(dummyEnemy);

			float xCoord = Random.Range(-80f, 60f);
			Vector3 startPos = new Vector3(xCoord, 10f, 120f);

			dummy.transform.position = startPos;
			//dummy.transform.rotation = Quaternion.Euler(0f, 180f, 0f);
			dummy.name = "dummy " + _dummyIdx;
			_dummyIdx++;

			//screen.AddObjectToScreen(dummy);
		}
	}

	private void FixedUpdate()
	{
		var rotation = new Vector3(0f, _rotateRate, 0f) * Time.fixedDeltaTime;

		if (Input.GetKey(KeyCode.RightArrow))
		{
			transform.Rotate(rotation, Space.World);
		}

		if (Input.GetKey(KeyCode.LeftArrow))
		{
			transform.Rotate(-rotation, Space.World);
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

	public void AddObjectToTrack()
	{

	}

	public void RemoveObjectFromTracking()
	{

	}

}
