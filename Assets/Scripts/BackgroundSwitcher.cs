using UnityEngine;
using System.Collections;

public class BackgroundSwitcher : MonoBehaviour {
	
	[SerializeField]
	private SpriteRenderer m_spriteRenderer;

	[SerializeField]
	private FadeSprite m_whiteSprite;
	
	[SerializeField]
	private PlayerStats m_playerStats;
	
	[SerializeField]
	private Sprite[] m_backgroundSprites = new Sprite[4];

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(m_spriteRenderer.sprite != m_backgroundSprites[(int)m_playerStats.currentMask])
		{
			changeBackground(m_playerStats.currentMask);
		}
	}

	public void changeBackground(MaskType targetMask)
	{	
		if (m_whiteSprite.isHidden) m_whiteSprite.FadeIn(); /* Start fading in */

		if(m_whiteSprite.isVisible) /* If whiteSprite is visible */
		{	
			m_spriteRenderer.sprite = m_backgroundSprites[(int)m_playerStats.currentMask];
			m_whiteSprite.FadeOut(); /*Start fading out*/
		}

	}
}
