using UnityEngine;
using System.Collections;

public class DropShadowText : MonoBehaviour {
	
	[SerializeField]
	private TextMesh m_text;
	[SerializeField]
	private TextMesh m_dropShadow;

	public void UpdateText (string text) {
		m_text.text = text;
		m_dropShadow.text = text;
	}
}
