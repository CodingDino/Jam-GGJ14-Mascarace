using UnityEngine;
using System.Collections;

public class ComboReadoutUpdater : MonoBehaviour {

	[SerializeField]
	private TextMesh m_text;
	[SerializeField]
	private TextMesh m_dropShadow;
	[SerializeField]
	private PlayerStats m_player;
	[SerializeField]
	private Animator m_animation;

	private int readoutAmmount;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (m_player.useCombo)
		{
			m_animation.SetTrigger("Unhide");

			if (readoutAmmount < m_player.combo)
			{
				m_animation.SetTrigger("GrowShrink");
			}
			if (readoutAmmount > m_player.combo)
			{
				m_animation.SetTrigger("Shake");
			}

			m_text.text = m_player.combo.ToString();
			m_dropShadow.text = m_player.combo.ToString();
			readoutAmmount = m_player.combo;
		}
		else
		{
			m_text.text = "";
			m_dropShadow.text = "";
		}
	}
}
