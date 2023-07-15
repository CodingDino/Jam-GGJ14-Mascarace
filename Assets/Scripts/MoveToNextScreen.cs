using UnityEngine;
using System.Collections;

public class MoveToNextScreen : MonoBehaviour {

	[SerializeField]
	public string m_nextLevelName;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		Application.LoadLevel(m_nextLevelName);
	}
}
