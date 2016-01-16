using UnityEngine;
using System.Collections;


public class CameraController : MonoBehaviour
{
	public GameObject target;
	public float m_yMin = -10f;
	public float m_yMax = 15f;
    public float m_rotateSpeed = 50f;
	private float m_desiredAngle_x;
	private float m_desiredAngle_y;
	private Vector3 offset;
	void Start()
	{
		m_desiredAngle_x = transform.eulerAngles.y;
		m_desiredAngle_y = transform.eulerAngles.x;
		offset = target.transform.position - transform.position;
	}
	void LateUpdate()
	{
		m_desiredAngle_x += Input.GetAxis("Mouse X") * m_rotateSpeed * Time.deltaTime;
		m_desiredAngle_y -= Input.GetAxis ("Mouse Y") * m_rotateSpeed * Time.deltaTime;
        m_desiredAngle_x += Input.GetAxis("Horizontal") * m_rotateSpeed * Time.deltaTime;
		m_desiredAngle_y = Mathf.Clamp (m_desiredAngle_y, m_yMin, m_yMax);
		Quaternion rotation = Quaternion.Euler(m_desiredAngle_y, m_desiredAngle_x, 0);
        transform.position = target.transform.position - (rotation * offset);
		transform.rotation = rotation;
		Vector3 targetPosition = new Vector3(target.transform.position.x, transform.position.y-10, target.transform.position.z);
        transform.LookAt(targetPosition);
    }

}