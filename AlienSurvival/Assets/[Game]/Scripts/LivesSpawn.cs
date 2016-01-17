using UnityEngine;
using System.Collections;

public class LivesSpawn : MonoBehaviour {

    public int m_multiplierHeart;
    private int m_actualNumberHearts;
    private LifePlayerController m_playerLife;
    public GameObject m_heartPrefab;
	// Use this for initialization
	void Start () {
        m_playerLife = GameObject.FindGameObjectWithTag("Player").GetComponent<LifePlayerController>();
        m_actualNumberHearts = 0;
	}
	
	// Update is called once per frame
	void Update () {
        int lostLives = m_playerLife.vidasIniciales - m_playerLife.vidasActuales;
	    if(m_actualNumberHearts < (lostLives*m_multiplierHeart))
        {
            Instantiate(m_heartPrefab, Vector3.zero, Quaternion.identity);
            m_actualNumberHearts++;
        }
	}

    public void subtractLife()
    {
        m_actualNumberHearts--;
    }
}