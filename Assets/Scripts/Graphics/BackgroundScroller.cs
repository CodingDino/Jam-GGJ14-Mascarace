using UnityEngine;
using System.Collections;

public class BackgroundScroller : MonoBehaviour {

	[SerializeField]
	private PlayerStats m_playerStats;

	[SerializeField]
	private Sprite[] m_backgrounds = new Sprite[4];

	private Sprite m_currentBackground;

	private SpriteRenderer m_spriteRenderer;

	// Use this for initialization
	void Start () {

		m_spriteRenderer = GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update () {

		if(m_currentBackground != m_backgrounds[(int)m_playerStats.currentMask])
		{	
			/* Transition goes here */ 
			m_currentBackground = m_backgrounds[(int)m_playerStats.currentMask];
			m_spriteRenderer.sprite = m_currentBackground;
		}

		Vector2 currPos = gameObject.transform.position;
		currPos.x = Time.time * m_playerStats.playerSpeed;

		gameObject.transform.position = currPos;



	}

}
