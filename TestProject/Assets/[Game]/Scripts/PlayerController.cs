using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
	public float m_speed = 6f;
	public float m_gravity = -98f;

	private Animator m_animator;
	private CharacterController m_charController;
	private Vector3 m_moveDirection = Vector3.zero;
	// Use this for initialization
	void Start () {
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
        
		m_animator.SetBool("punch", false);
		if (!m_animator.GetCurrentAnimatorStateInfo (0).IsName ("Punch")) {
			m_animator.SetBool ("punch", Input.GetKey (KeyCode.Space));
		}
        m_animator.SetBool("walking", (v != 0));
        m_animator.SetFloat("walkDirection", v);
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
		m_moveDirection.y -= m_gravity * Time.deltaTime;
		m_charController.Move (m_moveDirection * Time.deltaTime);
    }
}