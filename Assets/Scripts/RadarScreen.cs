using System.Collections.Generic;
using UnityEngine;

public class RadarScreen : MonoBehaviour
{
	private Dictionary<GameObject, GameObject> _enemyBlips;

	public CapsuleCollider radarZone;
	public GameObject blipPrefab;

	private readonly Quaternion blipRot = Quaternion.Euler(90f, 0f, 0f);
	private const float blipHeight = 0.6f;

	public float updateRate = 1.0f;
	private float _updateCooldown;

	private float _screenRadius;

	private void Awake()
	{
		_enemyBlips = new Dictionary<GameObject, GameObject>();

		_screenRadius = transform.localScale.x / 2;
	}

	// Start is called before the first frame update
	void Start()
	{
		_updateCooldown = 0f;
	}

	// move blips in here
	private void LateUpdate()
	{
		_updateCooldown -= Time.deltaTime;

		if (_updateCooldown <= 0f)
		{
			_updateCooldown = updateRate;

			foreach (var pair in _enemyBlips)
			{
				var obj = pair.Key;
				var blip = pair.Value;
				UpdateBlipPosition(obj, blip);
			}
		}
	}

	public void AddObjectToScreen(GameObject obj)
	{
		if (obj.CompareTag("Enemy"))
		{
			AddEnemyObject(obj);
		}
	}

	private void AddEnemyObject(GameObject enemy)
	{
		var blip = Instantiate(blipPrefab, transform);
		blip.transform.localRotation = blipRot;

		UpdateBlipPosition(enemy, blip);

		_enemyBlips.Add(enemy, blip);
		Debug.Log("Added enemy to radar");
	}

	public void RemoveObject(GameObject obj)
	{
		if (_enemyBlips.ContainsKey(obj))
		{
			var blip = _enemyBlips[obj];
			_enemyBlips.Remove(obj);
			Destroy(blip);

			Debug.Log("Removed enemy from radar");

			return;
		}

		// check other dictionaries if necessary (e.g. friendly, unidentified)
	}

	private void UpdateBlipPosition(GameObject obj, GameObject blip)
	{
		var detectorRadius = radarZone.radius;
		var detectorPosition = radarZone.transform.position;
		var objPosition = obj.transform.position;

		Vector3 dist = objPosition - detectorPosition;
		float blipX = _screenRadius * dist.x / detectorRadius;
		float blipZ = _screenRadius * dist.z / detectorRadius;

		blip.transform.localPosition = new Vector3(blipX, blipHeight, blipZ);
	}
}
