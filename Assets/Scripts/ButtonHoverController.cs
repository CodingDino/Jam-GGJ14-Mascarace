using UnityEngine;
using System.Collections;

public class ButtonHoverController : MonoBehaviour {

	[SerializeField]
	private SceneLoader m_sceneLoader;

	[SerializeField]
	private ButtonHoverController m_neighbourUp;

	[SerializeField]
	private ButtonHoverController m_neighrbourDown;

	[SerializeField]
	private bool m_isActive = false;

	[SerializeField]
	private SpriteRenderer m_spriteRenderer;

	[SerializeField]
	private Sprite m_normalStateSprite;

	[SerializeField]
	private Sprite m_hoverStateSprite;

	public bool Active
	{
		get{return m_isActive;}
		set{m_isActive = value;}
	}

	public SceneLoader sceneLoader
	{
		get{return m_sceneLoader;}
	}

	public ButtonHoverController neighbourUp
	{
		get{return m_neighbourUp;}
		set{m_neighbourUp = value;}
	}

	public ButtonHoverController neighbourDown
	{
		get{return m_neighrbourDown;}
		set{m_neighrbourDown = value;}
	}

	void OnMouseEnter()
	{
		m_spriteRenderer.sprite = m_hoverStateSprite;
	}

	void OnMouseExit()
	{
		m_spriteRenderer.sprite = m_normalStateSprite;
	}

	void Update()
	{
		if(m_isActive)
		{
			m_spriteRenderer.sprite = m_hoverStateSprite;
		}
		else
		{
			m_spriteRenderer.sprite = m_normalStateSprite;
		}
	}



}
