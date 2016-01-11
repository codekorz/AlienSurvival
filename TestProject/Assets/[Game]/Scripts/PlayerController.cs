using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
	public float m_defaultSpeed = 20f;
	public float m_runSpeed = 40f;
	public float m_gravity = -9.8f;
	private Animator m_animator;
	private CharacterController m_charController;
	private Vector3 m_moveDirection = Vector3.zero;
	private float m_speed;
	// Use this for initialization
	void Start () {
		m_speed = m_defaultSpeed;
	   	m_animator = GetComponent<Animator>();
		m_charController = GetComponent<CharacterController> ();
	}

	void FixedUpdate () {
        transform.Rotate(0, Input.GetAxisRaw("Horizontal") * 60 * Time.deltaTime, 0);
        float horizontal = Input.GetAxisRaw ("Horizontal");
		float vertical = Input.GetAxisRaw ("Vertical");

		Animation(horizontal, vertical);
		Move (horizontal, vertical);
	}

	void Animation(float h, float v)
	{
		m_animator.SetBool("walking", (v != 0));
		m_animator.SetFloat("walkDirection", v);
		m_animator.SetBool("punch", false);
		if (!m_animator.GetCurrentAnimatorStateInfo (0).IsName ("Punch")) {
			m_animator.SetBool ("punch", Input.GetKey (KeyCode.Space));
		}
		if (Input.GetKeyDown (KeyCode.LeftShift) && v > 0) {
			if (!m_animator.GetCurrentAnimatorStateInfo (0).IsName ("Run") && !m_animator.IsInTransition(0)) {
				//m_animator.Play ("Run");
				m_animator.SetBool ("running", true);
				m_speed = m_runSpeed;
			}
		}
		if (Input.GetKeyUp (KeyCode.LeftShift)) {
			m_animator.SetBool ("running", false);
			//m_animator.Play("Idle");
			m_speed = m_defaultSpeed;
		}
	}

	void Move(float h, float v) {
        if (m_charController.isGrounded) {
            if(h != 0 && v != 0)
            {
                m_moveDirection = new Vector3(h, 0, v);
            }
            else { m_moveDirection = new Vector3(0, 0, v); }
            m_moveDirection = transform.TransformDirection(m_moveDirection);
            m_moveDirection *= m_speed;
        }
		m_moveDirection.y += m_gravity * Time.deltaTime;
		m_charController.Move (m_moveDirection * Time.deltaTime);
    }
}