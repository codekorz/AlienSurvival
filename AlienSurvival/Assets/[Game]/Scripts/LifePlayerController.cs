using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class LifePlayerController : MonoBehaviour {
    private AsyncOperation async;
    public int vidasIniciales = 3;
    public int vidasActuales = -1;
    public int puntuacion = 0;
    public RawImage[] heart;
    public RawImage gameOver;
	// Use this for initialization
	void Start () {
        Time.timeScale = 1;
        vidasActuales = vidasIniciales;
        puntuacion = 0;
        heart = GameObject.Find("Lifes").GetComponentsInChildren<RawImage>();
        gameOver = GameObject.Find("GameOver").GetComponent<RawImage>();
        gameOver.enabled = false;
        
        // corazones = Texture2D.get        
    }
	
	void Update () {

		checkLifes ();
	}

	public void perderVida()
	{
		if (vidasActuales > 0)
		{
			heart[vidasActuales - 1].enabled = false;
			vidasActuales--;
		}
		checkLifes ();
	}


	public void ganarVida()
	{
		if (vidasActuales < 3)
		{
			vidasActuales++;
			heart[vidasActuales - 1].enabled = true;

		}
	}

	private void checkLifes()
	{
		if (vidasActuales == 0)
		{
			Time.timeScale = 0;
			gameOver.enabled = true;
			//async = SceneManager.LoadSceneAsync("GameScene");
			//async.allowSceneActivation = false;
			if (Input.anyKey /*|| async.progress >= 0.9*/)
			{
				//async.allowSceneActivation = true;
				SceneManager.LoadScene("GameScene");
			}
		}
	}

}
