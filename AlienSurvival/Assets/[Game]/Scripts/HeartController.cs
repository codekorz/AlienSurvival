using UnityEngine;
using System.Collections;

public class HeartController : MonoBehaviour {

    public float m_rotateSpeed = 40f;
    private GameObject heart;
    private LifePlayerController m_life;
    //private float x;
    //private float y = 3;
    //private float z;
    private Transform m_waypoints;
    private int m_maxWaypoint;
    private int m_minWaypoint;
    private int m_waypointSearched;
    private LivesSpawn m_livesSpawn;
    // Use this for initialization
    void Start () {
        Random.seed = (int)System.DateTime.Now.Ticks;
        //heart = transform.gameObject;
        m_life = GameObject.FindGameObjectWithTag("Player").GetComponent<LifePlayerController>();
        m_livesSpawn = GameObject.Find("Scripts").GetComponent<LivesSpawn>();
        m_waypoints = GameObject.Find("Waypoints").transform;
        m_minWaypoint = 0;
        m_maxWaypoint = m_waypoints.childCount-1;
        m_waypointSearched = Random.Range(m_minWaypoint, m_maxWaypoint);
        transform.position = m_waypoints.GetChild(m_waypointSearched).position;

    }

    // Update is called once per frame
    void Update () {
        transform.Rotate(0, 0, m_rotateSpeed * Time.deltaTime);
	}

    void OnTriggerEnter(Collider collider) {
    
        if (collider.tag == "Player")
        {
            m_life.ganarVida();
            Vector3 newpos = m_waypoints.GetChild(Random.Range(m_minWaypoint, m_maxWaypoint)).position;
            newpos.y = 4;
            transform.position = newpos;
            m_livesSpawn.subtractLife();
            //transform.position = new Vector3(-134,y,73);
            //Destroy(heart);
        }


    }
}
