using UnityEngine;
using System.Collections;

public enum MaskType
{
	Ego,
	Happy,
	Sad,
	Shy
}
public class PlayerStats : MonoBehaviour {
	
	private float m_speed;

	[SerializeField]
	private float m_startingSpeed;

	public float playerSpeed
	{
		get{ return m_speed; }
		set{ m_speed = value; }
	}

	[SerializeField]
	private MaskType m_startingMask;

	private MaskType m_currentMask;

	public MaskType currentMask
	{
		get {return m_currentMask;}
		set {currentMask = value;}
	}


	// Use this for initialization
	void Start () {
	
		m_speed = m_startingSpeed;
		m_currentMask = m_startingMask;
	}
	
	// Update is called once per frame
	void Update () {
	
	}



}
