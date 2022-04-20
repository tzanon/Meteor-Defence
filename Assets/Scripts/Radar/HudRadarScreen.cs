using UnityEngine;

public class HudRadarScreen : RadarScreen
{
	private RectTransform _rectTransform;

	protected override void Awake()
	{
		base.Awake();
		_rectTransform = GetComponent<RectTransform>();
		_screenRadius = _rectTransform.rect.width / 2;
	}

	protected override void InitBlipRotation(GameObject blip) { }

	protected override void PlaceBlip(GameObject blip, Vector3 pos)
	{
		var blipRectTransform = blip.GetComponent<RectTransform>();
		blipRectTransform.anchoredPosition = new Vector2(pos.x, pos.z);
	}

}
