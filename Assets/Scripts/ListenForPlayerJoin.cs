using UnityEngine;
using System.Collections;

public class ListenForPlayerJoin : MonoBehaviour {
	
	private MultiplayerManager m_multiplayerManager;

	[SerializeField]
	private int m_playerID;

	[SerializeField]
	private Animator m_animator;

	private bool m_isActive = false;

	// Use this for initialization
	void Start () {
		m_multiplayerManager = FindObjectOfType<MultiplayerManager>();

		if (m_multiplayerManager.GetPlayerActive(m_playerID-1))
		{
			m_isActive = true;
			m_animator.SetTrigger("AlreadyIn");
		}
	}
	
	// Update is called once per frame
	void Update () {
		
		if (m_playerID != 1 && m_isActive 
		    && Input.GetButtonDown(m_playerID+"-Button-1") )
		{
			m_isActive = false;
			m_multiplayerManager.SetPlayerActive(m_playerID-1,false);
			m_animator.SetTrigger("Leave");
		}
		else if (Input.GetButtonDown(m_playerID+"-Button-0") 
		    || Input.GetButtonDown(m_playerID+"-Button-1") 
		    || Input.GetButtonDown(m_playerID+"-Button-2") 
		    || Input.GetButtonDown(m_playerID+"-Button-3"))
		{
			m_isActive = true;
			m_multiplayerManager.SetPlayerActive(m_playerID-1,true);
			m_animator.SetTrigger("StampIn");
		}

	}
}
