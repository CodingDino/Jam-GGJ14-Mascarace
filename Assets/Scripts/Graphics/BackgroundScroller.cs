using UnityEngine;
using System.Collections;

public class BackgroundScroller : MonoBehaviour {

	[SerializeField]
	private PlayerStats m_playerStats;

	[SerializeField]
	private BackgroundSwitcher m_backgroundSwitcher;

	[SerializeField]
	private GameObject m_backgroundQuad;

	[SerializeField]
	private Texture[] m_backgroundTextures = new Texture[4];

	[SerializeField]
	private float m_backgroundRatio = 1f;

	private float m_offset = 0f;

	private Texture m_currentBackgroundTexture;

	public Texture currentBackgroundTexture
	{
		get { return m_currentBackgroundTexture;}
		set { m_currentBackgroundTexture	 = value;}
	}

	public GameObject backgorundQuad
	{
		get { return m_backgroundQuad;}
		set { m_backgroundQuad  = value;}	
	}

	public Texture[] backgroundTextures
	{
		get { return m_backgroundTextures;}
		set { m_backgroundTextures = value; }
	}

	// Use this for initialization
	void Start () {

		//m_backgroundQuad.renderer.material.mainTexture = m_backgroundTextures[(int)m_playerStats.currentMask];
		Debug.Log("Current mask: " + m_playerStats.currentMask);
	}

	// Update is called once per frame
	void Update () {
		if(m_currentBackgroundTexture != m_backgroundTextures[(int)m_playerStats.currentMask])
		{
			m_backgroundSwitcher.changeBackground(m_playerStats.currentMask);
		}

		m_offset += Time.deltaTime * m_playerStats.playerSpeed * m_backgroundRatio;
		m_backgroundQuad.renderer.material.mainTextureOffset = new Vector2(m_offset,0f);
	}
	
}
