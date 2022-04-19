using UnityEngine;

public class PhysicalRadarScreen : RadarScreen
{
	private const float blipHeight = 0.6f;
	protected readonly Quaternion _blipRot = Quaternion.Euler(90f, 0f, 0f);

	protected override void InitBlipRotation(GameObject blip)
	{
		blip.transform.localRotation = _blipRot;
	}

	protected override void UpdateBlipPosition(GameObject obj, GameObject blip)
	{
		var detectorRadius = radarZone.radius;
		var detectorPosition = radarZone.transform.position;
		var objPosition = obj.transform.position;

		Vector3 dist = objPosition - detectorPosition;

		float detectorRotation = radarZone.transform.rotation.eulerAngles.y;
		Vector3 rotatedDist = Quaternion.Euler(0f, -detectorRotation, 0f) * dist;

		float blipX = _screenRadius * rotatedDist.x / detectorRadius;
		float blipZ = _screenRadius * rotatedDist.z / detectorRadius;

		blip.transform.localPosition = new Vector3(blipX, blipHeight, blipZ);
	}
}
