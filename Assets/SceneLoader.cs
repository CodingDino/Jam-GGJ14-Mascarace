using UnityEngine;
using System.Collections;

public class SceneLoader : MonoBehaviour {

	[SerializeField]
	private string m_sceneToLoad;	

	[SerializeField]
	private FadeSprite m_fadeSprite;

	private bool m_startedFading = false;

	public void loadScene()
	{
			m_fadeSprite.FadeIn();
			m_startedFading = true;
	}

	void Update()
	{
		if(m_startedFading)
		{
			if(m_fadeSprite.isVisible)
			{
				m_startedFading = false;
				Application.LoadLevel(m_sceneToLoad);
			}
		}
	}
}
