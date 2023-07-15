using UnityEngine;
using System.Collections;

public class MainMenuController : MonoBehaviour {

	[SerializeField]
	private ButtonHoverController[] buttons; 

	[SerializeField]
	private MenuInputController m_inputController;

	[SerializeField]
	private ButtonHoverController m_currentSelectedButton;

	[SerializeField]
	private ButtonHoverController m_defaultSelectedButton;
	
	
	private float m_lastInputTime = 0f;
	[SerializeField]
	private float m_inputDelay = 1f;

	// Use this for initialization
	void Start () {
		m_currentSelectedButton = m_defaultSelectedButton;
		m_currentSelectedButton.Active = true;
	}
	
	// Update is called once per frame
	void Update () {

		if(m_inputController.buttonDown)
		{
			m_currentSelectedButton.sceneLoader.loadScene();
		}

		if(m_inputController.axisDown && Time.time >= m_lastInputTime + m_inputDelay)
		{
			if(m_currentSelectedButton.neighbourDown != null)
			{
				m_currentSelectedButton.Active = false;
				m_currentSelectedButton = m_currentSelectedButton.neighbourDown;
				m_currentSelectedButton.Active = true;
				m_lastInputTime = Time.time;
			}
		}

		else if(m_inputController.axisUp && Time.time >= m_lastInputTime + m_inputDelay)
		{	
			if(m_currentSelectedButton.neighbourUp != null)
			{
				m_currentSelectedButton.Active = false;
				m_currentSelectedButton = m_currentSelectedButton.neighbourUp;
				m_currentSelectedButton.Active = true;			
				m_lastInputTime = Time.time;
			}

		}
	}
}
