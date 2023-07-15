

using UnityEngine;
using System.Collections;

public class DistanceReadout : MonoBehaviour {
	
	[SerializeField]
	private TextMesh m_text;
	[SerializeField]
	private TextMesh m_dropShadow;
	[SerializeField]
	private PlayerStats m_player;
	[SerializeField]
	private float m_distanceScale = 1;
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		string distance = ((int)(m_player.currentDistance * m_distanceScale)).ToString();

		string text = "Traveled "+distance+" m";
		//string text = distance+" m";

		m_text.text = text;
		m_dropShadow.text = text;

	}
}
