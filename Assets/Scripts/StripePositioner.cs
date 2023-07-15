using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
public class StripePositioner : MonoBehaviour {

	[SerializeField]
	private float spriteID;

	[SerializeField]
	private float offsetX;

	[SerializeField]
	private float offsetY;

	[SerializeField]
	private Camera mainCam;

	[SerializeField]
	private float stripeDistance;

	// Use this for initialization
	void Start () {
	
		Vector2 newPos = new Vector2(offsetX, mainCam.orthographicSize - offsetY - spriteID * (24.8f + stripeDistance));
		transform.position = newPos;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
