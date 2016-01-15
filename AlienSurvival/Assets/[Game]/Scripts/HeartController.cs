using UnityEngine;
using System.Collections;

public class HeartController : MonoBehaviour {

    private GameObject heart;
    float x = 0;
    private LifePlayerController m_life;
	// Use this for initialization
	void Start () {
        heart = transform.parent.gameObject;
        m_life = GameObject.FindGameObjectWithTag("Player").GetComponent<LifePlayerController>();

    }

    // Update is called once per frame
    void Update () {
        //transform.Translate(0,x,0);
        //x = x + 1;
	}

    void OnTriggerEnter(Collider collider) {
    
        if (collider.tag == "Player")
        {
            m_life.ganarVida();
            Destroy(heart);
        }

        
    }
}
