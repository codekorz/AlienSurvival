using UnityEngine;
using UnityEngine.UI;

public class PlayerAttackTrigger : MonoBehaviour {
    private Animator m_PlayerAnimator;
	private Text m_textScore;
	private int m_Score;
    void Start()
    {
        m_PlayerAnimator = transform.root.GetComponent<Animator>(); //GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>();
		m_textScore = GameObject.Find("Score").GetComponent<Text>();
		m_Score = 0;
    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "AlienBlue" || collider.tag == "AlienGreen")
        {
            if (m_PlayerAnimator.GetCurrentAnimatorStateInfo(0).IsName("Punch"))
            {
                Destroy(collider.gameObject);
				m_Score++;
				m_textScore.text = "Score: "+ m_Score.ToString ();
            }
        }
    }

}
