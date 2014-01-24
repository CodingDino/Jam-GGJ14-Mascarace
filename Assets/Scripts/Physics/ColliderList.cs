// ************************************************************************ 
// File Name:   ColliderList.cs 
// Purpose:    	Tracks collisions and maintains a list.
// Project:		Framework
// Author:      Sarah Herzog  
// Copyright: 	2014 Bounder Games
// ************************************************************************


// ************************************************************************ 
// Imports 
// ************************************************************************ 
using UnityEngine;
using System.Collections;
using System.Collections.Generic;


// ************************************************************************ 
// Attributes 
// ************************************************************************ 
[RequireComponent(typeof(Collider2D))]


// ************************************************************************ 
// Class: ColliderList
// ************************************************************************ 
public class ColliderList : MonoBehaviour {


	// ********************************************************************
	// Serialized Data Members 
	// ********************************************************************
	[SerializeField]
	private float m_timeout = 0.1f;


	// ********************************************************************
	// Private Data Members 
	// ********************************************************************
	private List<Collider2D> m_colliders = new List<Collider2D>();
	private bool m_collidedThisFrame = false;
	private float m_lastCollisionTime = 0;
	private bool m_isColliding = false;


	// ********************************************************************
	// Properties
	// ********************************************************************
	public List<Collider2D> colliders {
		get { return m_colliders; }
	}
	public bool isColliding {
		//get { return m_isColliding; }
		get { if (m_colliders.Count > 0) return true; else return false; }
	}

	
	// ********************************************************************
	// Function:	Start()
	// Purpose:		Run when new instance of the object is created.
	// ********************************************************************
	void Start () {
		
	}
	
	
	// ********************************************************************
	// Function:	LateUpdate()
	// Purpose:		Called once per frame, after other functions.
	// ********************************************************************
	void LateUpdate () {
		if (m_collidedThisFrame)
			m_isColliding = true;
		else if (Time.time > m_lastCollisionTime + m_timeout)
			m_isColliding = false;

		m_collidedThisFrame = false;
	}

	
	// ********************************************************************
	// Function:	OnCollisionEnter2D()
	// Purpose:		Called when this collider encounters another.
	// ********************************************************************
	void OnCollisionEnter2D(Collision2D collision) {
		if (!m_colliders.Contains(collision.collider))
			m_colliders.Add (collision.collider);
	}
	
	
	// ********************************************************************
	// Function:	OnTriggerEnter2D()
	// Purpose:		Called when this collider encounters another.
	// ********************************************************************
	void OnTriggerEnter2D(Collider2D otherCollider) {
		if (!m_colliders.Contains(otherCollider))
			m_colliders.Add (otherCollider);
	}
	
	
	// ********************************************************************
	// Function:	OnCollisionExit2D()
	// Purpose:		Called a collider stops colliding with this one.
	// ********************************************************************
	void OnCollisionExit2D(Collision2D collision) {
		if (m_colliders.Contains(collision.collider))
			m_colliders.Remove(collision.collider);
	}
	
	
	// ********************************************************************
	// Function:	OnTriggerExit2D()
	// Purpose:		Called a collider stops colliding with this one.
	// ********************************************************************
	void OnTriggerExit2D(Collider2D otherCollider) {
		if (m_colliders.Contains(otherCollider))
			m_colliders.Remove(otherCollider);
	}
	
	
	// ********************************************************************
	// Function:	OnCollisionStay2D()
	// Purpose:		Called a collider is colliding with this one.
	// ********************************************************************
	void OnCollisionStay2D(Collision2D collision) {
		if (!m_colliders.Contains(collision.collider))
			m_colliders.Add (collision.collider);

		m_collidedThisFrame = true;
		m_lastCollisionTime = Time.time;
	}
	
	
	// ********************************************************************
	// Function:	OnTriggerStay2D()
	// Purpose:		Called a collider is colliding with this one.
	// ********************************************************************
	void OnTriggerStay2D(Collider2D otherCollider) {
		if (!m_colliders.Contains(otherCollider))
			m_colliders.Add (otherCollider);

		m_collidedThisFrame = true;
		m_lastCollisionTime = Time.time;
	}
}
