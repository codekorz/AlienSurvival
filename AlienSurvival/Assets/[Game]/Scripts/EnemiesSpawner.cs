using UnityEngine;
using System.Collections;

public class EnemiesSpawner : MonoBehaviour {
    public int m_numberAlienBlue;
    public int m_numberAlienGreen;
    private int m_actualNumberOfBlue;
    private int m_actualNumberOfGreen;
    private Transform m_waypoints;
    public GameObject m_AlienBluePrefab;
    public GameObject m_AlienGreenPrefab;
	// Use this for initialization
	void Start () {
        m_waypoints = GameObject.FindGameObjectWithTag("Waypoints").transform;
        m_actualNumberOfBlue = 0;
        m_actualNumberOfGreen = 0;
	}
	
	// Update is called once per frame
	void Update () {
        Transform waypoint;
	    if(m_actualNumberOfGreen < m_numberAlienGreen)
        {
            waypoint = m_waypoints.GetChild(Random.Range(0, m_waypoints.childCount-1));
            Instantiate(m_AlienGreenPrefab, waypoint.position, Quaternion.identity);
            m_actualNumberOfGreen++;
        }
        if(m_actualNumberOfBlue < m_numberAlienBlue)
        {
            waypoint = m_waypoints.GetChild(Random.Range(0, m_waypoints.childCount));
            Instantiate(m_AlienBluePrefab, waypoint.position, Quaternion.identity);
            m_actualNumberOfBlue++;
        }
	}
}
