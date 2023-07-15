using UnityEngine;
using System.Collections;

public class MaskSelecter : MonoBehaviour {

	[SerializeField]
	private Animator[] m_maskUIAnimators = null;
	
	[SerializeField]
	private SpriteRenderer[] m_maskUISprites = null;

	[SerializeField]
	private PlayerStats m_player = null;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		for (int i = 0; i < m_maskUIAnimators.Length; ++i)
		{
			if ((int)m_player.currentMask == i)
			{
				m_maskUIAnimators[i].SetBool("isGrowing",true);
				m_maskUIAnimators[i].SetBool("isShrinking",false);
				m_maskUIAnimators[i].renderer.sortingOrder = 0;
			}
			else
			{
				m_maskUIAnimators[i].SetBool("isGrowing",false);
				m_maskUIAnimators[i].SetBool("isShrinking",true);
				m_maskUIAnimators[i].renderer.sortingOrder = -5;
			}
		}

	}
}
