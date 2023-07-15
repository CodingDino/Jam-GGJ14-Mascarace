using UnityEngine;
using System.Collections;

public class TurnOnComboAndOffset : MonoBehaviour {

	[SerializeField]
	private ObstacleSpawner[] m_spawners = new ObstacleSpawner[4];
	[SerializeField]
	private PlayerStats[] m_players = new PlayerStats[4];
	[SerializeField]
	private float m_turnOnTime = 0;
	private float m_startTime = 0;

	// Use this for initialization
	void Start () {
		m_startTime = Time.time;

		// Turn off combo
		for (int i = 0; i < m_players.Length; ++i)
		{
			m_players[i].useCombo = false;
		}

		// Turn off offset
		for (int i = 0; i < m_spawners.Length; ++i)
		{
			m_spawners[i].spawnModifier = 0;
		}
	}
	
	// Update is called once per frame
	void Update () {

		if (Time.time > m_turnOnTime + m_startTime)
		{
			// Turn on combo
			for (int i = 0; i < m_players.Length; ++i)
			{
				m_players[i].useCombo = true;
			}

			// Turn on offset
			for (int i = 0; i < m_spawners.Length; ++i)
			{
				m_spawners[i].spawnModifier = i;
			}
		}
	}
}
