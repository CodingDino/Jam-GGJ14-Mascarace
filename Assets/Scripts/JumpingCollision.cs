using UnityEngine;
using System.Collections;

public class JumpingCollision : MonoBehaviour {
	
	[SerializeField] 
	private ObstacleStats m_obstacle;

	// ********************************************************************
	// Function:	OnTriggerEnter2D()
	// Purpose:		Called when another object enters this trigger
	// ********************************************************************
	void OnTriggerEnter2D (Collider2D otherCollider) {

		Debug.Log ("Player failed Obstacle: JUMP.");

		m_obstacle.state = ObstacleState.HOSTILE;
	}

}
