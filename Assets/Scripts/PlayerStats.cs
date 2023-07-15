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

	private float m_currentDistance = 0f;
	public float currentDistance
	{
		get{ return m_currentDistance; }
		set{ m_currentDistance = value; }
	}
	private int m_combo = 0;
	public int combo
	{
		get{ return m_combo; }
		set{ m_combo = value; }
	}
	private int m_maxCombo = 0;
	public int maxCombo
	{
		get{ return m_maxCombo; }
		set{ m_maxCombo = value; }
	}
	private int m_numFails = 0;
	public int numFails
	{
		get{ return m_numFails; }
		set{ m_numFails = value; }
	}
	private float m_topSpeed = 0;
	public float topSpeed
	{
		get{ return m_topSpeed; }
		set{ m_topSpeed = value; }
	}
	[SerializeField]
	private bool m_useCombo = true;
	public bool useCombo
	{
		get{ return m_useCombo; }
		set{ m_useCombo = value; }
	}
	[SerializeField]
	private float m_comboToSpeed = 1f;
	[SerializeField]
	private float m_percentSpeedLostOnHit = 0.5f;

	private float m_flashStartTime = 0;
	[SerializeField]
	private float m_flashDuration = 1.0f;
	[SerializeField]
	private FadeSprite m_fadeSprite = null;
	[SerializeField]
	private Animator m_hitEffectAnimator = null;

	private int m_currentRank = 0;
	public int currentRank {
		get { return m_currentRank; }
		set { m_currentRank = value; }
	}

	public MaskType currentMask
	{
		get {return m_currentMask;}
		set {m_currentMask = value;}
	}

	// Use this for initialization
	void Start () {
	
		m_speed = m_startingSpeed;
		m_topSpeed= m_speed;
		m_currentMask = m_startingMask;
	}
	
	// Update is called once per frame
	void Update () {
	
		// Update current distance
		m_currentDistance += Time.deltaTime*m_speed;

		// Update speed based on combo
//		m_speed = m_baseSpeed;
//		if (m_useCombo)
//		{
//			m_speed += m_combo * m_comboToSpeed;
//		}

		if (m_fadeSprite.continuous == true && Time.time >= m_flashStartTime + m_flashDuration)
		{
			m_fadeSprite.continuous = false;
			m_fadeSprite.FadeIn();
		}
	}

	public void WasHit(bool wasBad)
	{
		if (wasBad)
		{
			++m_numFails;
			if (m_useCombo)
			{
				m_combo = 0;
				m_speed -= m_speed * m_percentSpeedLostOnHit;
				m_speed = Mathf.Max(m_speed,m_startingSpeed);
			}
			m_flashStartTime = Time.time;
			m_fadeSprite.continuous = true;
			m_fadeSprite.FadeOut();
			m_hitEffectAnimator.SetTrigger("BadHit");
		}
		else
		{
			if (m_useCombo)
			{
				++m_combo;
				if (m_combo > m_maxCombo) m_maxCombo = m_combo;
				m_speed += m_comboToSpeed;
				if (m_speed > m_topSpeed) m_topSpeed = m_speed;
			}
			m_hitEffectAnimator.SetTrigger("GoodHit");
		}
	}

}
