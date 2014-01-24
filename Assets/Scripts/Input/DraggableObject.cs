// ************************************************************************ 
// File Name:   DraggableObject.cs 
// Purpose:    	Object can be click+dragged or touch+dragged around the screen
// Project:		
// Author:      Sarah Herzog  
// Copyright: 	2014 Bounder Games
// ************************************************************************ 


// ************************************************************************ 
// Imports 
// ************************************************************************ 
using UnityEngine;
using System.Collections;

// ************************************************************************ 
// Attributes 
// ************************************************************************ 


// ************************************************************************ 
// Class: DraggableObject
// ************************************************************************ 
public class DraggableObject : MonoBehaviour {


	// ********************************************************************
	// Serialized Data Members 
	// ********************************************************************
	[SerializeField]
	private bool m_allowDragging = true;
	[SerializeField]
	private bool m_clampToScreen = false; // TODO


	// ********************************************************************
	// Private Data Members 
	// ********************************************************************
	private bool m_isDragging = false;
	private bool m_draggedThisFrame = false;
	private Vector3 m_colliderScreenStartingPoint = Vector3.zero;
	private Vector3 m_worldSpaceMouseColliderOffset = Vector3.zero;


	// ********************************************************************
	// Function:	LateUpdate()
	// Purpose:		Called once per frame, after other functions.
	// ********************************************************************
	void LateUpdate () 
	{
		if (!m_draggedThisFrame)
			m_isDragging = false;
		m_draggedThisFrame = false;
	}


	// ********************************************************************
	// Function:	OnMouseDown()
	// Purpose:		Called when the user presses the mouse button over this 
	//				collider. 
	// ********************************************************************
	void OnMouseDown()
	{
		m_colliderScreenStartingPoint = 
			Camera.main.WorldToScreenPoint(gameObject.transform.position);

		m_worldSpaceMouseColliderOffset = gameObject.transform.position - 
			Camera.main.ScreenToWorldPoint(
				new Vector3(Input.mousePosition.x, 
			            	Input.mousePosition.y, 
			            	m_colliderScreenStartingPoint.z));
	}

	
	// ********************************************************************
	// Function:	OnMouseDrag()
	// Purpose:		Called when the user clicks on the collider and holds 
	//				down the mouse button.
	// ********************************************************************
	void OnMouseDrag()
	{
		if (!m_allowDragging)
			return;

		m_draggedThisFrame = true;
		m_isDragging = true;

		Vector3 currentScreenPoint = new Vector3(Input.mousePosition.x, 
		                                         Input.mousePosition.y, 
		                                         m_colliderScreenStartingPoint.z);

		Vector3 currentPosition = 
			  Camera.main.ScreenToWorldPoint(currentScreenPoint)
			+ m_worldSpaceMouseColliderOffset;

		transform.position = currentPosition;
	}


}
