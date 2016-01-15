using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class AlienAttackTrigger : MonoBehaviour {
    private Animator m_animator;
    private LifePlayerController m_life;

    void Start()
    {
        m_animator = transform.root.GetComponent<Animator>();
        m_life = GameObject.FindGameObjectWithTag("Player").GetComponent<LifePlayerController>();
    }
	void OnTriggerEnter(Collider collider)
	{

        if (collider.tag == "Player" && m_animator.GetCurrentAnimatorStateInfo(0).IsName("Attack"))
        {
            m_life.perderVida();
        }
    }

}
