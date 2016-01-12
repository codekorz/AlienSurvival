using UnityEngine;
using System.Collections;


public class CameraController : MonoBehaviour
{
	public GameObject target;
    public float rotateSpeed = 2f;
	private Vector3 offset;
	void Start()
	{
		offset = target.transform.position - transform.position;
	}
	void LateUpdate()
	{
        float horizontal = Input.GetAxis("Mouse X") * rotateSpeed;
		target.transform.Rotate(0, horizontal, 0);

        float desiredAngle = target.transform.eulerAngles.y;
        Quaternion rotation = Quaternion.Euler(0, desiredAngle, 0);
        transform.position = target.transform.position - (rotation * offset);
        Vector3 targetPosition = new Vector3(target.transform.position.x, transform.position.y-10, target.transform.position.z);
        transform.LookAt(targetPosition);
    }

}