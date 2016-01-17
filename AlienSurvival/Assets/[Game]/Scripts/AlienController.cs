using UnityEngine;
using System.Collections;
//using System;
enum Status {Patrol, Persecution};

public class AlienController : MonoBehaviour {
   
	private Status m_status;

	private int m_maxWaypoint;
	private int m_minWaypoint;
	private int m_waypointSearched;

	private RangeController m_range;
    private NavMeshAgent m_agent;
    private Animator m_animator;
	private Transform m_waypoints;
    private Transform m_target;


    void Start () {
        m_animator = GetComponent<Animator>();
        m_range = transform.FindChild("Sensor").GetComponent<RangeController>();
		m_agent = GetComponent<NavMeshAgent>();
        m_target = GameObject.FindGameObjectWithTag("Player").transform;
		//Para movimiento random
		m_waypoints = GameObject.Find ("Waypoints").transform;
		m_minWaypoint = 0;
		m_maxWaypoint = m_waypoints.childCount;
		m_waypointSearched = Random.Range (m_minWaypoint, m_maxWaypoint);
		m_agent.destination = m_waypoints.GetChild(m_waypointSearched).position;
		m_agent.speed = 10f;

    }

	void FixedUpdate () {
		//m_animator.SetFloat ("speed", m_agent.speed);
		if (m_range.getRange ()) 
		{  
			if (m_status != Status.Persecution)
			{
				m_status = Status.Persecution;
				m_animator.SetFloat ("speed", 40.0f);
				// Ajusta velocidad de movimiento y de la animación
				
				if (transform.tag == "AlienBlue") 
					m_agent.speed = 40f;
				else if (transform.tag == "AlienGreen")
					m_agent.speed = 30f;
			}

			if (!m_animator.GetCurrentAnimatorStateInfo (0).IsName ("Attack"))
				m_agent.destination = m_target.position;
			transform.LookAt (m_target);

			if (m_agent.remainingDistance > 0 && m_agent.remainingDistance <= 11) {
				if (!m_animator.GetCurrentAnimatorStateInfo (0).IsName ("Attack"))
					m_animator.SetTrigger ("attack");
			}
		} 
		else 
		{
			if (m_status != Status.Patrol) {
				m_status = Status.Patrol;
				m_agent.speed = 10.0f;
				m_animator.SetFloat ("speed", 0.0f);

			}
			if (m_agent.remainingDistance < 20) {
				m_waypointSearched = Random.Range (m_minWaypoint, m_maxWaypoint);
			}
			m_agent.destination = m_waypoints.GetChild (m_waypointSearched).transform.position;
			transform.LookAt (m_agent.nextPosition);
		}
    }


}
