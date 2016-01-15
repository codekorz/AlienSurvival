using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LifePlayerController : MonoBehaviour {


    public int vidasIniciales = 3;
    public int vidasActuales = 0;
    public int puntuacion = 0;
    public RawImage[] heart;
    
	// Use this for initialization
	void Start () {
        vidasActuales = vidasIniciales;
        puntuacion = 0;
        heart = GameObject.Find("Lifes").GetComponentsInChildren<RawImage>();
       // corazones = Texture2D.get        
	}
	
	// Update is called once per frame
	void Update () {
       /* if (Input.GetKeyDown(KeyCode.P))
        {
            heart[vidasActuales - 1].enabled = false;
            vidasActuales--;
        }*/
    }

    public void perderVida()
    {
        if (vidasActuales > 0)
        {
            heart[vidasActuales - 1].enabled = false;
            vidasActuales--;
        }
    }
}
