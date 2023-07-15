using UnityEngine;
using System.Collections;

public class Tutorial : MonoBehaviour {

	[SerializeField]
	private float m_fadeInStart = 0;
	[SerializeField]
	private float m_fadeOutStart = 0;
	[SerializeField]
	private FadeSprite[] m_spritesToFade;
	[SerializeField]
	private FadeText[] m_textToFade;

	private float m_timerStart = 0;

	// Use this for initialization
	void Start () {
		m_timerStart = Time.time;
	}
	
	// Update is called once per frame
	void Update () {

		if (Time.time > m_fadeOutStart + m_timerStart)
		{
			for (int i = 0; i < m_spritesToFade.Length; ++i)
			{
				m_spritesToFade[i].FadeOut();
			}
			for (int i = 0; i < m_textToFade.Length; ++i)
			{
				m_textToFade[i].FadeOut();
			}
		}
		else if (Time.time > m_fadeInStart + m_timerStart)
		{
			for (int i = 0; i < m_spritesToFade.Length; ++i)
			{
				m_spritesToFade[i].FadeIn();
			}
			for (int i = 0; i < m_textToFade.Length; ++i)
			{
				m_textToFade[i].FadeIn();
			}
		}

	}
}
