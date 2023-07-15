using UnityEngine;
using System.Collections;

public class ButtonController4Direction : MonoBehaviour {

	[SerializeField]
	private SceneLoader m_sceneLoader;

	[SerializeField]
	private ButtonController4Direction m_neighbourUp;

	[SerializeField]
	private ButtonController4Direction m_neighrbourDown;

	[SerializeField]
	private ButtonController4Direction m_neighbourLeft;

	[SerializeField]
	private ButtonController4Direction m_neighbourRight;

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

	public ButtonController4Direction neighbourUp
	{
		get{return m_neighbourUp;}
	}

	public ButtonController4Direction neighbourDown
	{
		get{return m_neighrbourDown;}
	}

	public ButtonController4Direction neighbourLeft
	{
		get{return m_neighbourLeft;}
	}

	public ButtonController4Direction neighbourRight
	{
		get {return m_neighbourRight;}
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
