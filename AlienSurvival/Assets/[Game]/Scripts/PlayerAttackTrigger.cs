using UnityEngine;

public class PlayerAttackTrigger : MonoBehaviour {
    private Animator m_PlayerAnimator;

    void Start()
    {
        m_PlayerAnimator = transform.root.GetComponent<Animator>(); //GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>();

    }

    void OnTriggerEnter(Collider collider)
    {
		if (collider.tag == "Enemy" && m_PlayerAnimator.GetCurrentAnimatorStateInfo (0).IsName ("Punch")) {
			Destroy (collider.gameObject);
		}
    }

}
