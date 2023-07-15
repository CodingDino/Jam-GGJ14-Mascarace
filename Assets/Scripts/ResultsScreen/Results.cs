using UnityEngine;
using System.Collections;

public class Results : MonoBehaviour {

	[SerializeField]
	private MultiplayerManager m_multiplayerManager = null;

	[SerializeField]
	private int m_playerID = 0;

	[SerializeField]
	private DropShadowText m_playerRank;
	[SerializeField]
	private DropShadowText m_playerScore;
	[SerializeField]
	private DropShadowText m_playerCombo;
	[SerializeField]
	private DropShadowText m_playerFail;
	[SerializeField]
	private DropShadowText m_playerTopSpeed;


	// Use this for initialization
	void Start () {
		m_multiplayerManager = FindObjectOfType<MultiplayerManager>();
		if (!m_multiplayerManager.GetPlayerActive(m_playerID))
		{
			gameObject.SetActive(false);
		}
	}
	
	// Update is called once per frame
	void Update () {

		if (m_multiplayerManager.GetPlayerRank(m_playerID) == 1)
		{
			m_playerRank.UpdateText("1st");
		}
		if (m_multiplayerManager.GetPlayerRank(m_playerID) == 2)
		{
			m_playerRank.UpdateText("2nd");
		}
		if (m_multiplayerManager.GetPlayerRank(m_playerID) == 3)
		{
			m_playerRank.UpdateText("3rd");
		}
		if (m_multiplayerManager.GetPlayerRank(m_playerID) == 4)
		{
			m_playerRank.UpdateText("4th");
		}

		m_playerScore.UpdateText(m_multiplayerManager.GetPlayerScore(m_playerID).ToString());
		m_playerCombo.UpdateText(m_multiplayerManager.GetPlayerMaxCombo(m_playerID).ToString());
		m_playerFail.UpdateText(m_multiplayerManager.GetPlayerNumFails(m_playerID).ToString());
		m_playerTopSpeed.UpdateText(m_multiplayerManager.GetPlayerTopSpeed(m_playerID).ToString());
	}
}
