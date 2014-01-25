using UnityEngine;
using System.Collections;

public class AnimationSpeedController : MonoBehaviour {


	[SerializeField]
	private PlayerStats m_playerStat;

	[SerializeField] 
	private float m_animationRatio = 1;

	private Animator m_animator;

	// Use this for initialization
	void Start () {
	
		m_animator = GetComponent<Animator>();
		m_animator.speed = m_playerStat.playerSpeed * m_animationRatio;

	}
	
	// Update is called once per frame
	void Update () {
	
		m_animator.speed = m_playerStat.playerSpeed * m_animationRatio;
	}
}
