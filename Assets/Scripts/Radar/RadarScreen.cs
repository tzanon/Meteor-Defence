using System.Collections.Generic;
using UnityEngine;

public abstract class RadarScreen : MonoBehaviour
{
	private Dictionary<GameObject, GameObject> _enemyBlips;

	public CapsuleCollider radarZone;
	public GameObject blipPrefab;

	public float updateRate = 1.0f;
	private float _updateCooldown;

	protected float _screenRadius;

	protected virtual void Awake()
	{
		_enemyBlips = new Dictionary<GameObject, GameObject>();
	}

	// Start is called before the first frame update
	protected void Start()
	{
		_updateCooldown = 0f;
	}

	// move blips in here
	protected void LateUpdate()
	{
		_updateCooldown -= Time.deltaTime;

		if (_updateCooldown <= 0f)
		{
			_updateCooldown = updateRate;
			var toDelete = new List<GameObject>();

			foreach (var obj in _enemyBlips.Keys)
			{
				if (obj == null) // if object destroyed
				{
					toDelete.Add(obj);
					continue;
				}
				else
				{
					UpdateBlipPosition(obj, _enemyBlips[obj]);
				}
			}

			if (toDelete.Count > 0)
			{
				Debug.Log(string.Format("Removing {0} blips of destroyed objects", toDelete.Count));
				toDelete.ForEach(obj => RemoveObjectFromScreen(obj));
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
		InitBlipRotation(blip);

		UpdateBlipPosition(enemy, blip);

		_enemyBlips.Add(enemy, blip);
		Debug.Log("Added enemy to radar");
	}

	public void RemoveObjectFromScreen(GameObject obj)
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

	protected abstract void InitBlipRotation(GameObject blip);

	protected void UpdateBlipPosition(GameObject obj, GameObject blip)
	{
		var detectorRadius = radarZone.radius;
		var detectorPosition = radarZone.transform.position;
		var objPosition = obj.transform.position;

		Vector3 dist = objPosition - detectorPosition;

		float detectorRotation = radarZone.transform.rotation.eulerAngles.y;
		Vector3 rotatedDist = Quaternion.Euler(0f, -detectorRotation, 0f) * dist;

		float blipX = _screenRadius * rotatedDist.x / detectorRadius;
		float blipZ = _screenRadius * rotatedDist.z / detectorRadius;

		PlaceBlip(blip.gameObject, new Vector3(blipX, 0f, blipZ));
	}

	protected abstract void PlaceBlip(GameObject blip, Vector3 pos);
}
