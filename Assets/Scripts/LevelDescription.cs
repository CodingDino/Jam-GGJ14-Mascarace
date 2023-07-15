// ************************************************************************ 
// File Name:   LevelDescription.cs 
// Purpose:    	Contains a level definition and orders obstacle spawns 
//				based on this.
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
// Class: ObstacleOrder
// ************************************************************************
[System.Serializable]
public class ObstacleOrder {
	public ObstacleType type;
	public float beat;
	public float time;
}


// ************************************************************************ 
// Class: LevelDescription
// ************************************************************************
public class LevelDescription : MonoBehaviour {
	
	// ********************************************************************
	// Serialized Data Members 
	// ********************************************************************
	[SerializeField]
	private AudioSource m_song;
	[SerializeField]
	private float m_totalBeats;
	[SerializeField]
	private float m_beatsPerMinute;
	[SerializeField]
	private float m_preloadingTime = 10f;
	[SerializeField]
	private float m_timeOffset = 0f;
	[SerializeField]
	private float m_speedUpRatio = 0.5f;
	[SerializeField]
	private ObstacleOrder[] m_obstacleOrders = null;
	[SerializeField]
	private ObstacleSpawner[] m_obstacleSpawners = null;
	[SerializeField]
	private PlayerStats[] m_players = null;

	[SerializeField]
	private FadeSprite m_blackScreen = null;



	// ********************************************************************
	// Private Data Members 
	// ********************************************************************
	private float m_songLength;
	private int m_currentOrderIndex = 0;
	private float m_currentSongTime = 0f;
	private bool m_isDone = false;
	private bool m_isStarted = false;
	private bool m_songIsDone = false;
	private MultiplayerManager m_multiplayerManager;

	
	// ********************************************************************
	// Properties 
	// ********************************************************************
	public float speedUpRatio {
		get { return m_speedUpRatio; }
		set { m_speedUpRatio = value; }
	}


	// ********************************************************************
	// Function:	Start()
	// Purpose:		Run when new instance of the object is created.
	// ********************************************************************
	void Start () {
		// Calculate song length
		m_songLength = 60.0f * m_totalBeats/m_beatsPerMinute;

		// Calculate time for each order based on beat
		for (int i = 0; i < m_obstacleOrders.Length; ++i)
		{
			m_obstacleOrders[i].time = (m_songLength / (m_totalBeats) ) * m_obstacleOrders[i].beat;
		}
		
		m_multiplayerManager = FindObjectOfType<MultiplayerManager>();
	}
	
	
	// ********************************************************************
	// Function:	Update()
	// Purpose:		Called once per frame.
	// ********************************************************************
	void Update () {
		if (!m_isStarted)
		{
			StartLevel();
			return;
		}

		// Calculate current song time
		m_currentSongTime = m_song.time + m_timeOffset;

		// Give the order if it's time.
		if (   !m_isDone 
		    && m_obstacleOrders[m_currentOrderIndex].time-m_preloadingTime <= m_currentSongTime)
		{
			// Send order to spawners
			for (int i = 0; i < m_obstacleSpawners.Length; ++i)
			{
				m_obstacleSpawners[i].SpawnObstacle(m_obstacleOrders[m_currentOrderIndex], m_currentSongTime);
			}

			// Move to next order
			++m_currentOrderIndex;
			if (m_currentOrderIndex >= m_obstacleOrders.Length)
				m_isDone = true;
		}

		if (!m_songIsDone)
		{
			if (!m_song.isPlaying)
			{
				Debug.Log ("Song stopped playing.");
				m_songIsDone = true;

				for (int i = 0; i < m_players.Length; ++i)
				{
					m_multiplayerManager.SetPlayerScore(i,(int)m_players[i].currentDistance);
					m_multiplayerManager.SetPlayerRank(i,(int)m_players[i].currentRank);
					m_multiplayerManager.SetPlayerMaxCombo(i,(int)m_players[i].maxCombo);
					m_multiplayerManager.SetPlayerTopSpeed(i,(float)m_players[i].topSpeed);
					m_multiplayerManager.SetPlayerNumFails(i,(int)m_players[i].numFails);
				}

				// TODO: Load end screen
				m_blackScreen.FadeIn();

			}
		}

		if (m_songIsDone)
		{
			
			if (m_blackScreen.isVisible)
			{
				Application.LoadLevel("Results");
			}
		}
	}


	// ********************************************************************
	// Function:	StartLevel()
	// Purpose:		Starts the music and level.
	// ********************************************************************
	void StartLevel () {

		m_song.Play();


		m_isStarted = true;
	}
}
