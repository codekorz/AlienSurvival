using UnityEngine;
using System.Collections;

public class AlienAttackTrigger : MonoBehaviour {
	void OnTriggerEnter(Collider collider)
	{
		Debug.Log ("Collision");
		if(collider.tag == "Player")
			Destroy(collider.gameObject);
	}

}
