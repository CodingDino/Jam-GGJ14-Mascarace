using UnityEngine;
using System.Collections;

public class MultiplayerManager : MonoBehaviour {

	[SerializeField]
	private bool[] m_activePlayers = new bool[4];
	public void SetPlayerActive(int num, bool active) { m_activePlayers[num] = active; }
	public bool GetPlayerActive(int num) {return m_activePlayers[num]; }
	public int GetNumPlayers() 
	{
		int count = 0;
		for (int i = 0; i < m_activePlayers.Length; ++i)
		{
			if (m_activePlayers[i]) ++count;
		}
		return count;
	}
	
	[SerializeField]
	private int[] m_playerScores = new int[4];
	public void SetPlayerScore(int num, int score) { m_playerScores[num] = score; }
	public int GetPlayerScore(int num) {return m_playerScores[num]; }
	
	[SerializeField]
	private int[] m_playerRank = new int[4];
	public void SetPlayerRank(int num, int rank) { m_playerRank[num] = rank; }
	public int GetPlayerRank(int num) {return m_playerRank[num]; }
	
	[SerializeField]
	private int[] m_playerMaxCombo = new int[4];
	public void SetPlayerMaxCombo(int num, int combo) { m_playerMaxCombo[num] = combo; }
	public int GetPlayerMaxCombo(int num) {return m_playerMaxCombo[num]; }
	
	[SerializeField]
	private float[] m_playerTopSpeed = new float[4];
	public void SetPlayerTopSpeed(int num, float speed) { m_playerTopSpeed[num] = speed; }
	public float GetPlayerTopSpeed(int num) {return m_playerTopSpeed[num]; }
	
	[SerializeField]
	private int[] m_playerNumFails = new int[4];
	public void SetPlayerNumFails(int num, int fail) { m_playerNumFails[num] = fail; }
	public int GetPlayerNumFails(int num) {return m_playerNumFails[num]; }
	
	void Awake()
	{
		DontDestroyOnLoad(gameObject);
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
