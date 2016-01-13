using UnityEngine;
using System.Collections;

public class RangeController : MonoBehaviour {

    // Use this for initialization

    private bool m_inrange;


    public bool getRange()
    {
        return m_inrange;
    }

    void Start () {
        m_inrange = false;
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter(Collider collider) {

        if (collider.gameObject.name == "MainCharacter")
        {
            Debug.Log("Ha entrado el personaje");
            m_inrange = false;
        }
    }

    void OnTriggerStay(Collider collider)
    {
        if (collider.gameObject.name == "MainCharacter")
        {
            Debug.Log("Está el personaje en el rango del Alien");
            m_inrange = true;
        }
    }

    void OnTriggerExit(Collider collider)
    {
        if (collider.gameObject.name == "MainCharacter")
        {
            Debug.Log("Ha salido el personaje");
            m_inrange = false;
        }
    }

}
