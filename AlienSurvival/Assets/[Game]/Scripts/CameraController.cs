using UnityEngine;
using System.Collections;


public class CameraController : MonoBehaviour
{
	public GameObject target;
	public float m_yMin = -10f;
	public float m_yMax = 15f;
	public float m_xMin = -10f;
	public float m_xMax = 15f;
    public float rotateSpeed = 30f;
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
		m_desiredAngle_x += Input.GetAxis("Mouse X") * rotateSpeed * Time.deltaTime;
		m_desiredAngle_y -= Input.GetAxis ("Mouse Y") * rotateSpeed * Time.deltaTime;
		target.transform.Rotate(0, Input.GetAxis ("Mouse X")*1.5f, 0);
		m_desiredAngle_y = Mathf.Clamp (m_desiredAngle_y, m_yMin, m_yMax);
		//m_desiredAngle_x = Mathf.Clamp (m_desiredAngle_x, m_xMin, m_xMax);
		Quaternion rotation = Quaternion.Euler(m_desiredAngle_y, m_desiredAngle_x, 0);
        transform.position = target.transform.position - (rotation * offset);
		transform.rotation = rotation;
		Vector3 targetPosition = new Vector3(target.transform.position.x, transform.position.y-10, target.transform.position.z);
        transform.LookAt(targetPosition);
    }

}