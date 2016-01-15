using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class AlienAttackTrigger : MonoBehaviour {
    private Animator m_animator;
    private LifePlayerController m_life;
    void Start()
    {
        m_animator = transform.root.GetComponent<Animator>();
    }
	void OnTriggerEnter(Collider collider)
	{
        m_life.perderVida();
        if (collider.tag == "Player" && m_animator.GetCurrentAnimatorStateInfo(0).IsName("Attack"))
            SceneManager.LoadScene("GameScene");
	}

}
