using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class AlienAttackTrigger : MonoBehaviour {
    private Animator m_animator;
    void Start()
    {
        m_animator = transform.parent.parent.GetComponent<Animator>();
    }
	void OnTriggerEnter(Collider collider)
	{
        if (collider.tag == "Player" && m_animator.GetCurrentAnimatorStateInfo(0).IsName("Attack"))
            SceneManager.LoadScene("GameScene");
	}

}
