using UnityEngine;
using System.Collections;

public class QuadScroller : MonoBehaviour {

	[SerializeField]
	private PlayerStats m_playerStat;

	[SerializeField]
	private float m_backgroundRatio;

	private float m_offset = 0.0f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		m_offset += Time.deltaTime * m_playerStat.playerSpeed * m_backgroundRatio;
		renderer.material.mainTextureOffset = new Vector2(m_offset,0f);
	}
}
