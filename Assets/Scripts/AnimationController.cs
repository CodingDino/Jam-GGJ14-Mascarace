using UnityEngine;
using System.Collections;

public class AnimationController : MonoBehaviour {

	[SerializeField]
	private PlayerStats m_player;

	[SerializeField]
	private Animator m_animator;

	[SerializeField]
	private ColliderList m_playerGroundCollider;
	[SerializeField]
	private string m_jumpBool;


	void Start () {

	}

	void Update () {

		/*Activate mask */
		var values = System.Enum.GetValues(typeof(MaskType));

		foreach(var val in values)
		{ 
			string boolToActivate = "is" + val.ToString() + "Running";

			if(val.ToString() == m_player.currentMask.ToString())
			{
				m_animator.SetBool(boolToActivate, true);
			}
			else
			{
				m_animator.SetBool(boolToActivate, false);
			}

			if (m_playerGroundCollider.isColliding)
			{
				m_animator.SetBool(m_jumpBool, false);
			}
			else
			{
				m_animator.SetBool(m_jumpBool, true);
			}


		}
	}
}
