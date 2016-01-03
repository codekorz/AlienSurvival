using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
	public float m_speed = 6f;
	public float m_gravity = -98f;

	private Animator m_anim;
	private CharacterController m_charController;
	private bool m_walking = false;
	private Vector3 m_moveDirection = Vector3.zero;
	// Use this for initialization
	void Start () {
	   	m_anim = GetComponent<Animator>();
		m_charController = GetComponent<CharacterController> ();
	}

	void FixedUpdate () {
		float horizontal = Input.GetAxis ("Horizontal");
		float vertical = Input.GetAxis ("Vertical");
		//m_moveDirection = new Vector3 (Input.GetAxisRaw("Horizontal"), 0, Input.GetAxis("Vertical"));
		//transform.rotation = Quaternion.LookRotation (m_moveDirection);

		Animation(horizontal, vertical);
		Move (horizontal, vertical);
	}

	void Animation(float h, float v)
	{
		m_anim.SetBool("punch", false);
		if (!m_anim.GetCurrentAnimatorStateInfo (0).IsName ("Punch")) {
			m_anim.SetBool ("punch", Input.GetKey (KeyCode.Space));
		}
		m_walking = ((h != 0 || v != 0));
		m_anim.SetBool ("walking", m_walking);
	}

	void Move(float h, float v) {
		if (m_charController.isGrounded) {
			m_moveDirection = new Vector3 (h, 0, v);
			m_moveDirection = transform.TransformDirection (m_moveDirection) * m_speed * Time.deltaTime;
		}
		m_moveDirection.y -= m_gravity * Time.deltaTime;
		m_charController.Move (m_moveDirection);
	}
}