// ************************************************************************ 
// File Name:   ObstacleStats.cs 
// Purpose:    	Contains stats and calculations for obstacles.
// Project:		Framework
// Author:      Sarah Herzog  
// Copyright: 	2014 Bounder Games
// ************************************************************************


// ************************************************************************ 
// Imports 
// ************************************************************************ 
using UnityEngine;
using System.Collections;

// ************************************************************************ 
// Enum: ObstacleType
// ************************************************************************
public enum ObstacleType {
	EGO, HAPPY, SAD, SHY, JUMP
}


// ************************************************************************ 
// Enum: ObstacleState
// ************************************************************************
public enum ObstacleState {
	FRIENDLY, DEFEATED, DEFEATER, HOSTILE
}


// ************************************************************************ 
// Class: ObstacleStats
// ************************************************************************

// ************************************************************************ 
// Attributes
// ************************************************************************
[RequireComponent(typeof(Collider2D))]

public class ObstacleStats : MonoBehaviour {


	// ********************************************************************
	// Serialized Data Members 
	// ********************************************************************
	[SerializeField] 
	private ObstacleType m_obstacleType;
	[SerializeField] 
	private PlayerStats m_player;
	[SerializeField] 
	private Entity m_entity;
	[SerializeField] 
	private float m_speed;
	[SerializeField] 
	private JumpingCollision m_jumpCollision;

	[SerializeField]
	private float m_timeToDecay = 5.0f;
	private float m_decayStartTime = 0;

	
	// ********************************************************************
	// Private Data Members 
	// ********************************************************************
	private ObstacleState m_state = ObstacleState.HOSTILE;

	
	// ********************************************************************
	// Properties 
	// ********************************************************************
	public ObstacleState state {
		get { return m_state; }
		set { m_state = value; }
	}
	public PlayerStats player {
		get { return m_player; }
		set { m_player = value; }
	}
	public float speed {
		get { return m_speed; }
		set { m_speed = value; }
	}


	// ********************************************************************
	// Function:	Start()
	// Purpose:		Run when new instance of the object is created.
	// ********************************************************************
	void Start () {
		if (m_obstacleType == ObstacleType.JUMP)
			m_state = ObstacleState.FRIENDLY;
	}


	// ********************************************************************
	// Function:	Update()
	// Purpose:		Called once per frame.
	// ********************************************************************
	void Update () {

		// Move the obstacle
		m_entity.MoveX (-1,m_speed);

		// Turn hostile or friendly when encountering player.
		if (m_obstacleType != ObstacleType.JUMP && m_state != ObstacleState.DEFEATED &&  m_state != ObstacleState.DEFEATER)
		{
			if (m_player != null && (int)m_player.currentMask == (int)m_obstacleType)
				m_state = ObstacleState.FRIENDLY;
			else
				m_state = ObstacleState.HOSTILE;
		}

		if ((m_state ==  ObstacleState.DEFEATED ||  m_state == ObstacleState.DEFEATER) && Time.time > m_decayStartTime + m_timeToDecay)
		{
			GameObject.Destroy(gameObject);
		}

	}


	// ********************************************************************
	// Function:	OnTriggerEnter2D()
	// Purpose:		Called when another object enters this trigger
	// ********************************************************************
	void OnTriggerEnter2D (Collider2D otherCollider) {

		if (otherCollider.gameObject != m_player.gameObject)
			return;

		Debug.Log ("Player hit Obstacle: "+m_obstacleType);

		if (m_state == ObstacleState.FRIENDLY)
		{
			// TODO: Trigger animation
			m_state = ObstacleState.DEFEATED;
			m_player.WasHit(false);
		}
		else
		{
			// TODO: Trigger animation
			m_state = ObstacleState.DEFEATER;
			m_player.WasHit(true);
		}

		m_decayStartTime = Time.time;
	}


}
