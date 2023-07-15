// ************************************************************************ 
// File Name:   ObstacleSpawner.cs 
// Purpose:    	Spawns in obstacles.
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
// Class: ObstacleSpawner
// ************************************************************************
public class ObstacleSpawner : MonoBehaviour {
	
	
	// ********************************************************************
	// Serialized Data Members 
	// ********************************************************************
	[SerializeField]
	private LevelDescription m_levelDesc = null;
	[SerializeField]
	private GameObject[] m_obstaclePrefabs = null;
	[SerializeField]
	private GameObject m_stripe = null;
	[SerializeField] 
	private PlayerStats m_player;
	[SerializeField] 
	private int m_spawnModifier = 0;
	public int spawnModifier
	{
		get { return m_spawnModifier; }
		set {m_spawnModifier = value; }
	}


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
	
	}

	
	// ********************************************************************
	// Function:	SpawnObstacle()
	// Purpose:		Creates an obstacle and determines how fast it is
	// ********************************************************************
	public void SpawnObstacle (ObstacleOrder _obstacleOrder, float _currentSongTime) {

		// Calculate speed
		float speed = m_player.playerSpeed * m_levelDesc.speedUpRatio;
		if (speed == 0f) return;

		// Calculate position based on speed
		float xPos = m_player.transform.position.x + speed*(_obstacleOrder.time-_currentSongTime);

		// Spawn object
		ObstacleType typeToSpawn = _obstacleOrder.type;
		if (typeToSpawn != ObstacleType.JUMP)
		{
			typeToSpawn = (ObstacleType)(((int)typeToSpawn + m_spawnModifier)%m_obstaclePrefabs.Length);
			if (typeToSpawn == ObstacleType.JUMP)
			{
				typeToSpawn = (ObstacleType)(((int)typeToSpawn + m_spawnModifier)%m_obstaclePrefabs.Length);
			}
		}
		GameObject tospawn = m_obstaclePrefabs[(int)typeToSpawn];
		GameObject spawned = (GameObject)Instantiate(tospawn);

		// Set it to this position
		spawned.transform.position = new Vector3(xPos, transform.position.y, transform.position.z);
		spawned.transform.parent = m_stripe.transform;

		// Set the obstacles speed
		spawned.GetComponent<ObstacleStats>().speed = speed;
		spawned.GetComponent<ObstacleStats>().player = m_player;
	}
}
