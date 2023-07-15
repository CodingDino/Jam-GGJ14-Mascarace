using UnityEngine;
using System.Collections;

public class LaneManager : MonoBehaviour {

	[SerializeField]
	private GameObject[] m_lanes = new GameObject[4];
	public void SetLaneActive(int num, bool active) { m_lanes[num].SetActive(active); }
	public bool GetLaneActive(int num) {return m_lanes[num].activeSelf; }

	[SerializeField]
	private MultiplayerManager m_multiplayerManager;

	// Use this for initialization
	void Start () {
		m_multiplayerManager = FindObjectOfType<MultiplayerManager>();
	}
	
	// Update is called once per frame
	void Update () {
		for (int i = 0; i < m_lanes.Length; ++i)
		{
			SetLaneActive(i,m_multiplayerManager.GetPlayerActive(i));
		}
	}
}
