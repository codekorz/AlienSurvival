using UnityEngine;
using System.Collections;

public class AlienController : MonoBehaviour {
   
	private RangeController m_range;
    private NavMeshAgent m_agent;
    private Animator m_animator;
	private bool m_attack;

    public Transform m_target;

    void Start () {
		m_attack = false;
        m_animator = GetComponent<Animator>();
        m_range = transform.FindChild("Sensor").GetComponent<RangeController>();
		m_agent = GetComponent<NavMeshAgent>();
    }

	void FixedUpdate () {
		m_animator.SetFloat ("speed", m_agent.speed);
		if (m_range.getRange ()) {  	
			if(!m_attack)
				m_agent.destination = m_target.position;
			transform.LookAt (m_target);
			if (m_agent.remainingDistance < 5 && !m_animator.GetCurrentAnimatorStateInfo (0).IsName ("Attack")){
				m_attack = true;
			}else{
				m_attack = false;
			}
			m_animator.SetBool ("attack", m_attack);
        }
    }


}
