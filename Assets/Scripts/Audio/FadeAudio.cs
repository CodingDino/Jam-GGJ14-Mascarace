﻿// ************************************************************************ 
// File Name:   FadeAudio.cs 
// Purpose:    	Fades an audio source in or out.
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
// Class: FadeAudio
// ************************************************************************ 
public class FadeAudio : MonoBehaviour {
	
	
	// ********************************************************************
	// Private Data Members 
	// ********************************************************************
	[SerializeField]
	private AudioSource m_audioSource = null;
	[SerializeField]
	private bool m_startsAudible = false;
	[SerializeField]
	private bool m_fadeOnAwake = false;
	[SerializeField]
	private float m_fadeSpeed = 1.0f;
	[SerializeField]
	private float m_minVolume = 0;
	[SerializeField]
	private float m_maxVolume = 1.0f;
	
	private bool m_fadingIn = false;
	private bool m_fadingOut = false;
	
	
	// ********************************************************************
	// Properties 
	// ********************************************************************
	public bool isAudible {
		get { 
			if (m_audioSource != null && m_audioSource.volume == m_maxVolume)
				return true;
			else return false;
		}
	}
	public bool isInaudible {
		get { 
			if (m_audioSource != null && m_audioSource.volume == m_minVolume)
				return true;
			else return false;
		}
	}
	public float fadeSpeed {
		get { return m_fadeSpeed; }
		set { m_fadeSpeed = value; }
	}
	public float minVolume {
		get { return m_minVolume; }
		set { m_minVolume = value; }
	}
	public float maxVolume {
		get { return m_maxVolume; }
		set { m_maxVolume = value; }
	}
	
	 
	// ********************************************************************
	// Function:	Start()
	// Purpose:		Run when new instance of the object is created.
	// ********************************************************************
	void Start () {
		if (m_audioSource == null) return;
		
		if (m_startsAudible)
		{
			m_audioSource.volume = m_maxVolume;
			if (m_fadeOnAwake)
				m_fadingOut = true;
		}
		else
		{
			m_audioSource.volume = m_minVolume;
			if (m_fadeOnAwake)
				m_fadingIn = true;
		}
	}
	
	
	// ********************************************************************
	// Function:	Update()
	// Purpose:		Called once per frame.
	// ********************************************************************
	void Update () {
		if (m_audioSource == null) return;
		
		if (m_fadingIn)
		{
			m_audioSource.volume += m_fadeSpeed * Time.deltaTime;
			
			if (m_audioSource.volume >= m_maxVolume)
			{
				m_audioSource.volume = m_maxVolume;
				m_fadingIn = false;
			}
		}
		
		if (m_fadingOut)
		{
			m_audioSource.volume -= m_fadeSpeed * Time.deltaTime;
			
			if (m_audioSource.volume <= m_minVolume)
			{
				m_audioSource.volume = m_minVolume;
				m_fadingOut = false;
			}
		}
		
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