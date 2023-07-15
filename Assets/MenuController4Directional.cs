using UnityEngine;
using System.Collections;

public class MenuController4Directional : MonoBehaviour {

	[SerializeField]
	private MenuInputController m_inputController;

	[SerializeField]
	private ButtonController4Direction m_currentSelectedButton;

	[SerializeField]
	private ButtonController4Direction m_defaultSelectedButton;
	
	
	private float m_lastInputTime = 0f;

	[SerializeField]
	private float m_inputDelay = 0.1f;

	// Use this for initialization
	void Start () {
		if(m_defaultSelectedButton)
		{
			m_currentSelectedButton = m_defaultSelectedButton;
			m_currentSelectedButton.Active = true;
		}
	}
	
	// Update is called once per frame
	void Update () {

		if(m_inputController.buttonDown && m_currentSelectedButton.GetComponent<ButtonController4Direction>().Active)
		{
			m_currentSelectedButton.GetComponent<SceneLoader>().loadScene();
		}

		if(m_inputController.axisDown && Time.time >= m_lastInputTime + m_inputDelay)
		{
			if(m_currentSelectedButton.neighbourDown != null)
			{	
				m_lastInputTime = Time.time;
				m_currentSelectedButton.Active = false;
				m_currentSelectedButton = m_currentSelectedButton.neighbourDown;
				m_currentSelectedButton.Active = true;

			}
		}

		else if(m_inputController.axisUp && Time.time >= m_lastInputTime + m_inputDelay)
		{	
			if(m_currentSelectedButton.neighbourUp != null)
			{	
				m_lastInputTime = Time.time;
				m_currentSelectedButton.Active = false;
				m_currentSelectedButton = m_currentSelectedButton.neighbourUp;
				m_currentSelectedButton.Active = true;			
		
			}
		}

		else if(m_inputController.axisRight && Time.time >= m_lastInputTime + m_inputDelay)
		{	
			if(m_currentSelectedButton.neighbourRight != null)
			{	
				m_lastInputTime = Time.time;
				m_currentSelectedButton.Active = false;
				m_currentSelectedButton = m_currentSelectedButton.neighbourRight;
				m_currentSelectedButton.Active = true;			
		
			}
		}

		else if(m_inputController.axisLeft && Time.time >= m_lastInputTime + m_inputDelay)
		{	
			if(m_currentSelectedButton.neighbourLeft != null)
			{	
				m_lastInputTime = Time.time;
				m_currentSelectedButton.Active = false;
				m_currentSelectedButton = m_currentSelectedButton.neighbourLeft;
				m_currentSelectedButton.Active = true;			

			}
		}

	}
}
