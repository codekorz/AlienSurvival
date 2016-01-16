using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class StartScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		SceneManager.LoadScene("GameScene");
	}
	void Update () {
		if (SceneManager.GetSceneByName ("GameScene").isLoaded && SceneManager.GetSceneByName("StartScene").isLoaded) {
			SceneManager.UnloadScene ("StartScene");
			Destroy (gameObject);
		}
	}
}
