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
	
    void OnTriggerEnter(Collider collider) {

        if (collider.tag == "Player")
        {
            m_inrange = true;
        }
    }

    void OnTriggerStay(Collider collider)
    {
        if (collider.tag == "Player")
        {
            m_inrange = true;
        }
    }

    void OnTriggerExit(Collider collider)
    {
        if (collider.tag == "Player")
        {
            m_inrange = false;
        }
    }

}
