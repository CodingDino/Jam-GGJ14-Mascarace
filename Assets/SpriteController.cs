using UnityEngine;
using System.Collections;

public class SpriteController : MonoBehaviour {

	[SerializeField]
	private ObstacleStats m_obstacle;

	[SerializeField]
	private SpriteRenderer m_spriteRenderer;


	[SerializeField]
	private Sprite[] m_sprites = new Sprite[2];

	/* m_sprites[0] == friendly
	 * m_sprites[1] == hostile */

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
		if((m_obstacle.state == ObstacleState.HOSTILE || m_obstacle.state == ObstacleState.DEFEATER) && m_spriteRenderer.sprite != m_sprites[1])
		{
			m_spriteRenderer.sprite = m_sprites[1];
		}
		else if ((m_obstacle.state == ObstacleState.FRIENDLY || m_obstacle.state == ObstacleState.DEFEATED) && m_spriteRenderer.sprite != m_sprites[0])
		{
			m_spriteRenderer.sprite = m_sprites[0];
		}
	}
}
