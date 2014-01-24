﻿// ************************************************************************ 
// File Name:   FadeSprite.cs 
// Purpose:    	Fades sprite in or out.
// Project:		Framework
// Author:      Sarah Herzog  
// Copyright: 	2013 Bounder Games
// ************************************************************************ 


// ************************************************************************ 
// Imports 
// ************************************************************************ 
using UnityEngine;
using System.Collections;
using System.Collections.Generic;


// ************************************************************************ 
// Attributes 
// ************************************************************************ 

// ************************************************************************ 
// Class: FadeSprite
// ************************************************************************ 
public class FadeSprite : MonoBehaviour {
	
	
	// ********************************************************************
	// Private Data Members 
	// ********************************************************************
	[SerializeField]
	private SpriteRenderer m_sprite = null;
	[SerializeField]
	private bool m_startsVisible = false;
	[SerializeField]
	private bool m_fadeOnAwake = false;
	[SerializeField]
	private bool m_continuous = false;
	[SerializeField]
	private float m_fadeSpeed = 1.0f;
	[SerializeField]
	private float m_minAlpha = 0;
	[SerializeField]
	private float m_maxAlpha = 1.0f;

	private bool m_fadingIn = false;
	private bool m_fadingOut = false;
	
	
	// ********************************************************************
	// Properties 
	// ********************************************************************
	public bool isVisible {
		get { 
			if (m_sprite.color.a == m_maxAlpha)
				return true;
			else return false;
		}
	}
	public bool isHidden {
		get { 
			if (m_sprite.color.a == m_minAlpha)
				return true;
			else return false;
		}
	}
	public float fadeSpeed {
		get { return m_fadeSpeed; }
		set { m_fadeSpeed = value; }
	}
	public float minAlpha {
		get { return m_minAlpha; }
		set { m_minAlpha = value; }
	}
	public float maxAlpha {
		get { return m_maxAlpha; }
		set { m_maxAlpha = value; }
	}
	public bool continuous {
		get { return m_continuous; }
		set { m_continuous = value; }
	}
	
	 
	// ********************************************************************
	// Function:	Start()
	// Purpose:		Run when new instance of the object is created.
	// ********************************************************************
	void Start () {
		if (m_sprite == null) return;

		if (m_startsVisible)
		{
			Color spriteColor = m_sprite.color;
			spriteColor.a = m_maxAlpha;
			m_sprite.color = spriteColor;
			if (m_fadeOnAwake)
				m_fadingOut = true;
		}
		else
		{
			Color spriteColor = m_sprite.color;
			spriteColor.a = m_minAlpha;
			m_sprite.color = spriteColor;
			if (m_fadeOnAwake)
				m_fadingIn = true;
		}
	}
	
	
	// ********************************************************************
	// Function:	Update()
	// Purpose:		Called once per frame.
	// ********************************************************************
	void Update () {
		if (m_sprite == null) return;
		
		Color spriteColor = m_sprite.color;

		if (m_fadingIn)
		{
			spriteColor.a += m_fadeSpeed * Time.deltaTime;

			if (spriteColor.a >= m_maxAlpha)
			{
				spriteColor.a = m_maxAlpha;
				m_fadingIn = false;
				if (m_continuous)
					m_fadingOut = true;
			}
		}

		if (m_fadingOut)
		{
			spriteColor.a -= m_fadeSpeed * Time.deltaTime;
			
			if (spriteColor.a <= m_minAlpha)
			{
				spriteColor.a = m_minAlpha;
				m_fadingOut = false;
				if (m_continuous)
					m_fadingIn = true;
			}
		}

		m_sprite.color = spriteColor;

	}


	// ********************************************************************
	// Function:	FadeIn()
	// Purpose:		Tells the sprite to fade in
	// ********************************************************************
	public void FadeIn()
	{
		m_fadingIn = true;
		m_fadingOut = false;
	}
	
	
	// ********************************************************************
	// Function:	FadeOut()
	// Purpose:		Tells the sprite to fade out
	// ********************************************************************
	public void FadeOut()
	{
		m_fadingIn = false;
		m_fadingOut = true;
	}
	
	
}