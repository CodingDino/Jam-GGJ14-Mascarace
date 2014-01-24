using UnityEngine;
using System.Collections;

public class PlayerStats : MonoBehaviour {
	
	private float m_speed;

	[SerializeField]
	private float m_startingSpeed;

	public float playerSpeed
	{
		get{ return m_speed; }
		set{ m_speed = value; }
	}

	private enum MaskType
	{
		Ego,
		Happy,
		Sad,
		Shy
	}

	[SerializeField]
	private MaskType m_startingMask;

	private MaskType m_currentMask;

	// Use this for initialization
	void Start () {
	
		m_speed = m_startingSpeed;
		m_currentMask = m_startingMask;
	}
	
	// Update is called once per frame
	void Update () {
	
	}



}
