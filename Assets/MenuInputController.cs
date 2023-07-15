using UnityEngine;
using System.Collections;

public class MenuInputController : MonoBehaviour {

	private bool m_isPressingRight = false;

	public bool axisRight
	{
		get{return m_isPressingRight;}
	}

	private bool m_isPressingLeft = false;

	public bool axisLeft
	{
		get{return m_isPressingLeft;}
	}

	private bool m_isPressingUp = false;

	public bool axisUp
	{
		get{return m_isPressingUp;}
		set{m_isPressingUp = value;}
	}

	private bool m_isPressingDown = false;

	public bool axisDown
	{
		get{return m_isPressingDown;}
		set{m_isPressingDown = value;}
	}


	private bool m_isPressingButton = false;

	public bool buttonDown
	{
		get{return m_isPressingButton;}
		set{m_isPressingButton = value;}
	}

	private bool m_anyButtonDown = false;

	public bool anyButtonDown
	{
		get{return m_anyButtonDown;}
	}

	void Update () {


		if(Input.GetButtonDown("1-Button-0"))
		{
			m_isPressingButton = true;
			m_anyButtonDown = true;
			Debug.Log("anybutton+mainbutton");
		}

		else if(Input.GetButtonDown("1-Button-1") || Input.GetButtonDown("1-Button-2") || Input.GetButtonDown("1-Button-3"))
		{
			Debug.Log ("anybutton");
			m_anyButtonDown = true;
		}

		else if(Input.GetAxis("1-Horizontal") > 0)
		{
			m_isPressingRight = true;
		}

		else if(Input.GetAxis("1-Horizontal") < 0)
		{
			m_isPressingLeft = true;
		}

		else if (Input.GetButtonUp("1-Button-0"))
		{
			m_isPressingButton = false;
		}
		else if(Input.GetAxis("1-Vertical") > 0)
		{
			m_isPressingDown = true;
			m_isPressingUp = false;
		}	

		else if(Input.GetAxis ("1-Vertical") < 0)
		{
			m_isPressingUp = true;
			m_isPressingDown = false;
		}
		else
		{
			m_isPressingUp = false;
			m_isPressingDown = false;
			m_isPressingLeft = false;
			m_isPressingRight = false;
			//m_anyButtonDown = false;
			m_isPressingButton = false;
		}
	}
}
