using UnityEngine;
using System.Collections;

public class AlienController : MonoBehaviour {
   
	private RangeController m_range;
    private NavMeshAgent m_agent;
    private Animator m_animator;

    public Transform m_target;

    void Start () {
        m_animator = GetComponent<Animator>();
        m_range = transform.FindChild("Sensor").GetComponent<RangeController>();
		m_agent = GetComponent<NavMeshAgent>();
    }

	void FixedUpdate () {
		m_animator.SetFloat ("speed", m_agent.speed);
		if (m_range.getRange ()) {  	
			if(!m_animator.GetCurrentAnimatorStateInfo(0).IsName("Attack"))
				m_agent.destination = m_target.position;
			transform.LookAt (m_target);
			if (m_agent.remainingDistance > 0 && m_agent.remainingDistance <= 14){
                if (!m_animator.GetCurrentAnimatorStateInfo(0).IsName("Attack"))
                    m_animator.SetTrigger("attack");
			}
        }
    }


}
