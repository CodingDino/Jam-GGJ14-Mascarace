using UnityEngine;
using System.Collections;

public class CreditsController : MonoBehaviour {

	[SerializeField]
	private MenuInputController m_inputController;

	[SerializeField]
	private SceneLoader m_sceneLoader;

	// Use this for initialization
	void Start () {	
	}
	
	// Update is called once per frame
	void Update () {
	
		if(m_inputController.anyButtonDown)
		{
			m_sceneLoader.loadScene();
		}
	}
}
