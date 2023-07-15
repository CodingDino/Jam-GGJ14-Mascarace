using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RankChecker : MonoBehaviour {

	[SerializeField]
	private PlayerStats[] m_players;

	[SerializeField]
	private DropShadowText[] m_rankText;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		// Find first player
		int firstScore = 0;
		for (int i = 0; i < m_players.Length; ++i)
		{
			if ((int)m_players[i].currentDistance >= firstScore)
			{
				firstScore = (int)m_players[i].currentDistance;
				m_rankText[i].UpdateText("1st");
				m_players[i].currentRank = 1;
			}
		}

		// Find second player
		int secondScore = 0;
		for (int i = 0; i < m_players.Length; ++i)
		{
			if ((int)m_players[i].currentDistance < firstScore && (int)m_players[i].currentDistance >= secondScore)
			{
				secondScore = (int)m_players[i].currentDistance;
				m_rankText[i].UpdateText("2nd");
				m_players[i].currentRank = 2;
			}
		}

		// Find third player
		int thirdScore = 0;
		for (int i = 0; i < m_players.Length; ++i)
		{
			if ((int)m_players[i].currentDistance < secondScore && (int)m_players[i].currentDistance >= thirdScore)
			{
				thirdScore = (int)m_players[i].currentDistance;
				m_rankText[i].UpdateText("3rd");
				m_players[i].currentRank = 3;
			}
		}
		
		// Find fourth player
		for (int i = 0; i < m_players.Length; ++i)
		{
			if (m_players[i].currentDistance < thirdScore)
			{
				m_rankText[i].UpdateText("4th");
				m_players[i].currentRank = 4;
			}
		}

	}


}
