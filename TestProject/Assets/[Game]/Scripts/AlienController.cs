using UnityEngine;
using System.Collections;

public class AlienController : MonoBehaviour {


    private Animator m_animator;
    private Rigidbody m_rigidbody;
    private Vector3 m_moveDirection = Vector3.zero;
    public float m_speed = 6f;
    public float m_gravity = 9.8f;

    // Use this for initialization
    void Start () {
        m_animator = GetComponent<Animator>();
        m_rigidbody = GetComponent<Rigidbody>();
    }
	
	// Update is called once per frame
	void Update () {
        transform.Rotate(0, Input.GetAxisRaw("Horizontal") * 60 * Time.deltaTime, 0);
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Move(horizontal, vertical);
    }

    void Move(float h, float v)
    {
        m_moveDirection = new Vector3(h, 0, v);
        if (m_moveDirection != Vector3.zero)
        {
            m_moveDirection = transform.TransformDirection(m_moveDirection);
            m_moveDirection *= m_speed;
          //  m_moveDirection.y -= m_gravity * Time.deltaTime;
            m_rigidbody.AddForce(m_moveDirection * Time.deltaTime);
            Debug.Log("H" + h + "-V:" + v);
        }
    }
}
