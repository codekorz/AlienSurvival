using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class StartScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		SceneManager.LoadScene("GameScene");
		if(SceneManager.GetSceneByName("GameScene").isLoaded)
			SceneManager.UnloadScene ("StartScene");
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
