using UnityEngine;

public class PhysicalRadarScreen : RadarScreen
{
	private const float blipHeight = 0.6f;
	protected readonly Quaternion _blipRot = Quaternion.Euler(90f, 0f, 0f);

	protected override void Awake()
	{
		base.Awake();
		_screenRadius = transform.localScale.x / 2;
	}

	protected override void InitBlipRotation(GameObject blip)
	{
		blip.transform.localRotation = _blipRot;
	}

	protected override void PlaceBlip(GameObject blip, Vector3 pos)
	{
		blip.transform.localPosition = new Vector3(pos.x, blipHeight, pos.z);
	}

}
