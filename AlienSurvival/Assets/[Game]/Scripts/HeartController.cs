using UnityEngine;
using System.Collections;

public class HeartController : MonoBehaviour {
    public float m_rotateSpeed = 40f;
    private GameObject heart;
    private LifePlayerController m_life;
	// Use this for initialization
	void Start () {
        heart = transform.parent.gameObject;
        m_life = GameObject.FindGameObjectWithTag("Player").GetComponent<LifePlayerController>();
    }

    // Update is called once per frame
    void Update () {
        transform.Rotate(0, 0, m_rotateSpeed * Time.deltaTime);
	}

    void OnTriggerEnter(Collider collider) {
    
        if (collider.tag == "Player")
        {
            m_life.ganarVida();
            Destroy(heart);
        }

        
    }
}
