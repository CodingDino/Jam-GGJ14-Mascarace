// ************************************************************************ 
// File Name:   InputPlayer.cs 
// Purpose:    	Reads input from player controllers and pass on.
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
// Class: InputPlayer
// ************************************************************************
public class InputPlayer : MonoBehaviour {
	
	// ********************************************************************
	// Serialized Data Members 
	// ********************************************************************
	[SerializeField] 
	private int m_playerIndex = 1;
	[SerializeField]
	private string[] m_maskButtons = new string[4];
	[SerializeField]
	private string m_jumpAxis = null;

	[SerializeField]
	private PlayerStats m_playerStats = null;
	[SerializeField]
	private Entity m_playerEntity = null;
	[SerializeField]
	private float m_jumpSpeed = 20f;
	[SerializeField]
	private ColliderList m_colliderList = null;
	
	// ********************************************************************
	// Private Data Members 
	// ********************************************************************
	private float m_lastJumpAxis = 0f;
	

	// ********************************************************************
	// Function:	Start()
	// Purpose:		Run when new instance of the object is created.
	// ********************************************************************
	void Start () {
		
	}
	
	
	// ********************************************************************
	// Function:	Update()
	// Purpose:		Called once per frame.
	// ********************************************************************
	void Update () {

		// Signal mask changes
		for (int i = 0; i < m_maskButtons.Length; ++i)
		{
			if (Input.GetButtonDown(m_playerIndex+"-"+m_maskButtons[i]) && m_colliderList.isColliding)
			{
				Debug.Log("Button "+m_playerIndex+"-"+m_maskButtons[i]+" pressed: "+(MaskType)i);
				m_playerStats.currentMask = (MaskType) i;
			}
		}

		// Signal jump
		if (Input.GetAxis(m_playerIndex+"-"+m_jumpAxis) < 0 && m_lastJumpAxis == 0f && m_colliderList.isColliding)
		{
			Debug.Log("Button "+m_playerIndex+"-"+m_jumpAxis+" pressed: Jump.");
			m_playerEntity.MoveY (1,m_jumpSpeed);
		}
		m_lastJumpAxis = Input.GetAxis(m_playerIndex+"-"+m_jumpAxis);
	}



}
