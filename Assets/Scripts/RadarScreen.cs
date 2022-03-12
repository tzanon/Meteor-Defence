using System.Collections.Generic;
using UnityEngine;

public class RadarScreen : MonoBehaviour
{
	private Dictionary<GameObject, GameObject> _enemyBlips;

	public GameObject blipPrefab;
	public float updateRate = 1.0f;
	private float _updateCooldown;

	private float radarRadius;

	private void Awake()
	{
		_enemyBlips = new Dictionary<GameObject, GameObject>();

		radarRadius = transform.localScale.x / 2;
	}

	// Start is called before the first frame update
	void Start()
	{
		_updateCooldown = 0f;
	}

	// Update is called once per frame
	void Update()
	{
		
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
				//UpdateBlipPosition(go, _meteorBlips[go]);
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

		Vector3 radarOrigin = new Vector3(0f, 0.6f, 0f);
		Quaternion blipRot = Quaternion.Euler(90f, 0f, 0f);

		blip.transform.localPosition = radarOrigin;
		blip.transform.localRotation = blipRot;

		_enemyBlips.Add(enemy, blip);
	}

	public void RemoveObject(GameObject obj)
	{
		if (_enemyBlips.ContainsKey(obj))
		{
			_enemyBlips.Remove(obj);
			return;
		}

		// check other dictionaries if necessary (e.g. friendly, unidentified)
	}

	private void UpdateBlipPosition(GameObject obj, GameObject blip)
	{
		
	}
}
