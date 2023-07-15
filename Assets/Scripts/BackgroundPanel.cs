// ************************************************************************ 
// File Name:   BackgroundPanel.cs 
// Purpose:    	Scrolls panels based on player
// Project:		MasqueRace
// Author:      Sarah Herzog  
// Copyright: 	2014 Tiny Tales Games
// ************************************************************************


// ************************************************************************ 
// Imports 
// ************************************************************************ 
using UnityEngine;
using System.Collections;


// ************************************************************************ 
// Class: BackgroundPanel
// ************************************************************************
public class BackgroundPanel : MonoBehaviour {

	
	// ********************************************************************
	// Serialized Data Members 
	// ********************************************************************
	[SerializeField]
	private PlayerStats m_player = null;
	[SerializeField]
	private Transform m_startingPositionTransform = null;
	[SerializeField]
	private Transform m_endingPositionTransform = null;
	[SerializeField]
	private float m_backgroundRatio = 1f;
	[SerializeField]
	private float m_backgroundOffsetFactor = 1f;
	[SerializeField]
	private Entity m_entity = null;


	// ********************************************************************
	// Private Data Members 
	// ********************************************************************
	private Vector3 m_startingPosition;
	private Vector3 m_endingPosition;
	private float m_offset;


	// ********************************************************************
	// Function:	Start()
	// Purpose:		Run when new instance of the object is created.
	// ********************************************************************
	void Start () {
		m_startingPosition = m_startingPositionTransform.position;
		m_endingPosition = m_endingPositionTransform.position;
		m_offset = m_startingPosition.x - m_endingPosition.x;
	}
	
	
	// ********************************************************************
	// Function:	Update()
	// Purpose:		Called once per frame.
	// ********************************************************************
	void LateUpdate () {
		float scrollSpeed = m_player.playerSpeed * m_backgroundRatio;

		m_entity.MoveX (-1,scrollSpeed);

		if (transform.position.x <= m_endingPosition.x)
		{
			transform.position = transform.position + new Vector3(m_offset,0f,0f);
		}
	}
}
