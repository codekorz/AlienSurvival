using UnityEngine;
using System.Collections;

public class AlienController : MonoBehaviour {

    private RangeController m_range;
    //private NavMeshHit m_navhit;
    private NavMeshAgent m_agent;
    private Animator m_animator;
    private Rigidbody m_rigidbody;
    private Vector3 m_moveDirection = Vector3.zero;
    public float m_speed = 6f;
    public float m_gravity = 9.8f;
    public Transform m_target;
    //private NavMeshAgent[] m_waypoints;

    // Use this for initialization
    void Start () {
        m_animator = GetComponent<Animator>();
        //m_rigidbody = GetComponent<Rigidbody>();
        m_range = transform.FindChild("Sensor").GetComponent<RangeController>();
        //m_target = GameObject.Find("Player").GetComponent<Transform>();
    }
	
	// Update is called once per frame
	void Update () {

        if (m_range.getRange())
        {
            Debug.Log("HE RECIBIDO UN PERSONAJEEE EN MI RANGOOO");
  
            //transform.Translate(new Vector3(0, 20, 0));
            m_agent = GetComponent<NavMeshAgent>();
            m_agent.destination = m_target.position;
        }
        //Debug.Log("Position:" + target.transform.position);
    }

}
