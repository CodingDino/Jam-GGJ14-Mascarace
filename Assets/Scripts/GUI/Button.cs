// ************************************************************************ 
// File Name:   Button.cs 
// Purpose:     Mouse-over, rollover, click effects 
// Project:		Framework
// Author:      Sarah Herzog  
// Copyright: 	2013 Bounder Games
// ************************************************************************ 


// ************************************************************************ 
// Imports 
// ************************************************************************
using UnityEngine;
using System.Collections;


// ************************************************************************ 
// Class: Button 
// ************************************************************************ 
public class Button : MonoBehaviour 
{
	
	
	// ********************************************************************
	// Exposed Data Members 
	// ********************************************************************
	[SerializeField]
	private bool m_enabled = true;
	
	// Textures and display
	[SerializeField]
	private SpriteRenderer m_spriteRenderer;
	[SerializeField]
	private Sprite m_spriteNormal;
	[SerializeField]
	private Sprite m_spriteHover;
	[SerializeField]
	private Sprite m_spriteClicked;
	[SerializeField]
	private Sprite m_spriteDisabled;
	
	// Effects
	[SerializeField]
	private float m_offsetClick = 0;
	[SerializeField]
	private float m_enlargeHover = 1.0f;
	[SerializeField]
	private float m_enlargeClick = 1.0f;
	
	// Text
	[SerializeField]
	private TextMesh m_textMesh;
	[SerializeField]
	private string m_text;
	[SerializeField]
	private Color m_fontColorNormal;
	[SerializeField]
	private Color m_fontColorHover;
	[SerializeField]
	private Color m_fontColorClicked;
	[SerializeField]
	private Color m_fontColorDisabled;
	
	
	// ********************************************************************
	// Private Data Members 
	// ********************************************************************
	private enum ButtonState 
	{ 
		NORMAL, HOVER, CLICKED, DISABLED 
	};
	private ButtonState m_state;
	private bool m_hoveredThisFrame = false;
	private bool m_hoveredLastFrame = false;
	private bool m_clickedThisFrame = false;
	private bool m_clickedLastFrame = false;
	private float m_yNormal;
	private float m_yClicked;
	
	
	// ********************************************************************
	// Properties 
	// ********************************************************************
	public bool buttonEnabled
	{
		get { return m_enabled; }
	}
	
	
	// ********************************************************************
	// Function:	Start()
	// Purpose:     Run when new instance of the object is created.
	// ********************************************************************
	void Start () 
	{
		// Set up y coordintes
		m_yNormal = m_spriteRenderer.transform.position.y;
		m_yClicked = m_yNormal + m_offsetClick;
		
		// Set up enabled/disabled
		if (m_enabled) 
			EnableButton();
		else 
			DisableButton();
	}
	
	
	// ********************************************************************
	// Function:	Update()
	// Purpose:		Called once per frame.
	// ********************************************************************
	void Update () 
	{
		
	}
	
	
	// ********************************************************************
	// Function:	LateUpdate()
	// Purpose:		Called once per frame, after other functions.
	// ********************************************************************
	void LateUpdate () 
	{
		if (!m_enabled) return;
		
		// Hover Enter
		if (m_hoveredThisFrame 
		    && !m_hoveredLastFrame)
		{
			OnHoverEnter();
			if (!m_clickedThisFrame) 
				SetState(ButtonState.HOVER);
			if (m_clickedThisFrame) 
				SetState(ButtonState.CLICKED);
		}
		
		// Hover Stay
		else if (m_hoveredThisFrame 
		         && m_hoveredLastFrame)
		{
			OnHoverStay();
			if (!m_clickedThisFrame) 
				SetState(ButtonState.HOVER);
		}
		
		// Hover Exit
		else if (!m_hoveredThisFrame 
		         && m_hoveredLastFrame)
		{
			OnHoverExit();
			SetState(ButtonState.NORMAL);
		}
		
		// Click start
		if (m_clickedThisFrame 
		    && !m_clickedLastFrame)
		{
			SetState(ButtonState.CLICKED);
		}
		
		// Click release
		if (!m_clickedThisFrame 
		    && m_clickedLastFrame)
		{
			if (m_hoveredThisFrame)
			{
				OnClick();
				SetState(ButtonState.HOVER);
			}
			else
				SetState(ButtonState.NORMAL);
			
		}
		
		// Reset hover and click test
		m_hoveredLastFrame = m_hoveredThisFrame;
		m_hoveredThisFrame = false;
		m_clickedLastFrame = m_clickedThisFrame;
		m_clickedThisFrame = false;
	}
	
	
	// ********************************************************************
	// Function:	OnMouseOver()
	// Purpose:		Called every frame while the mouse is over the Collider 
	// ********************************************************************
	void OnMouseOver()
	{
		if (!m_enabled) return;
		
		m_hoveredThisFrame = true;
		if (Input.GetMouseButton(0))
			m_clickedThisFrame = true;
	}
	
	
	// ********************************************************************
	// Function:	DisableButton()
	// Purpose:		Disables the button
	// ********************************************************************
	public void DisableButton()
	{
		SetState (ButtonState.DISABLED);
	}
	
	
	// ********************************************************************
	// Function:	EnableButton()
	// Purpose:		Enables the button
	// ********************************************************************
	public void EnableButton()
	{
		SetState (ButtonState.NORMAL);
	}
	
	
	// ********************************************************************
	// Function:	SetState()
	// Purpose:		Sets the button to the supplied state and performs
	//				any necessary actions
	// ********************************************************************
	private void SetState(ButtonState _state)
	{
		// If the state is already the current state, don't do anything
		if (m_state == _state) return;
		
		// Check for disabling or re-enabling
		if (_state == ButtonState.DISABLED)
		{
			m_enabled = false;
			m_hoveredThisFrame = false;
			m_hoveredLastFrame = false;
			m_clickedLastFrame = false;
			m_clickedThisFrame = false;
		}
		else if (m_state == ButtonState.DISABLED)
			m_enabled = true;
		
		// Check for click offset adjustments
		if (_state == ButtonState.CLICKED)
		{
			// Record current normal position and recalculate clicked position
			m_yNormal = m_spriteRenderer.transform.position.y;
			m_yClicked = m_yNormal + m_offsetClick;
			// Set to new position
			m_spriteRenderer.transform.position = 
				new Vector3 (m_spriteRenderer.transform.position.x,
				             m_yClicked,
				             m_spriteRenderer.transform.position.z);
		}
		else if (m_state == ButtonState.CLICKED)
		{
			// Record current normal position and recalculate clicked position
			m_yClicked = m_spriteRenderer.transform.position.y;
			m_yNormal = m_yClicked - m_offsetClick;
			// Set to new position
			m_spriteRenderer.transform.position = 
				new Vector3 (m_spriteRenderer.transform.position.x,
				             m_yNormal,
				             m_spriteRenderer.transform.position.z);
		}
		
		// Check for click enlarge adjustments
		if (_state == ButtonState.CLICKED)
		{
			m_spriteRenderer.transform.localScale = 
				new Vector3 (m_spriteRenderer.transform.localScale.x * m_enlargeClick,
				             m_spriteRenderer.transform.localScale.y * m_enlargeClick,
				             m_spriteRenderer.transform.localScale.z);
		}
		else if (m_state == ButtonState.CLICKED)
		{
			m_spriteRenderer.transform.localScale = 
				new Vector3 (m_spriteRenderer.transform.localScale.x / m_enlargeClick,
				             m_spriteRenderer.transform.localScale.y / m_enlargeClick,
				             m_spriteRenderer.transform.localScale.z);
		}
		
		// Check for hover enlarge adjustments
		if (_state == ButtonState.HOVER)
		{
			m_spriteRenderer.transform.localScale = 
				new Vector3 (m_spriteRenderer.transform.localScale.x * m_enlargeHover,
				             m_spriteRenderer.transform.localScale.y * m_enlargeHover,
				             m_spriteRenderer.transform.localScale.z);
		}
		else if (m_state == ButtonState.HOVER)
		{
			m_spriteRenderer.transform.localScale = 
				new Vector3 (m_spriteRenderer.transform.localScale.x / m_enlargeHover,
				             m_spriteRenderer.transform.localScale.y / m_enlargeHover,
				             m_spriteRenderer.transform.localScale.z);
		}
		
		// Set up sprites and fonts
		switch (_state)
		{
		case ButtonState.NORMAL:
			m_spriteRenderer.sprite = m_spriteNormal;
			m_textMesh.color = m_fontColorNormal;
			break;
		case ButtonState.HOVER:
			m_spriteRenderer.sprite = m_spriteHover;
			m_textMesh.color = m_fontColorHover;
			break;
		case ButtonState.CLICKED:
			m_spriteRenderer.sprite = m_spriteClicked;
			m_textMesh.color = m_fontColorClicked;
			break;
		case ButtonState.DISABLED:
			m_spriteRenderer.sprite = m_spriteDisabled;
			m_textMesh.color = m_fontColorDisabled;
			break;
		}
		
		// Record the new state
		m_state = _state;
	}
	
	
	// ********************************************************************
	// Function:	OnHoverEnter()
	// Purpose:		Called when the button is first hovered over
	// ********************************************************************
	protected virtual void OnHoverEnter()
	{
		if (!m_enabled) return;
	}
	
	
	// ********************************************************************
	// Function:	OnHoverExit()
	// Purpose:		Called when the button is no longer hovered over
	// ********************************************************************
	protected virtual void OnHoverExit()
	{
		if (!m_enabled) return;
	}
	
	
	// ********************************************************************
	// Function:	OnHoverStay()
	// Purpose:		Called every frame the button is hovered over
	// ********************************************************************
	protected virtual void OnHoverStay()
	{
		if (!m_enabled) return;
	}
	
	
	// ********************************************************************
	// Function:	OnClick()
	// Purpose:		Called when the button is clicked
	// ********************************************************************
	protected virtual void OnClick()
	{
		if (!m_enabled) return;
	}
}
