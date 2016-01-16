using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class LoadScene : MonoBehaviour {
	static LoadScene instance;
	void Awake()
	{
		if (instance)
		{
			Destroy(gameObject);
			return;
		}
		instance = this;    
		//gameObject.AddComponent<GUITexture>.enabled = false;
		//guiTexture.texture = texture;
//		transform.position = new Vector3(0.0f, 0.0, 0.0f);
		DontDestroyOnLoad(this); 
	}
	void Start()
	{
		LoadScene.Load ("GameScene");
	}
	public static void Load(string name)
	{
		if (NoInstance()) return;
		//instance.guiTexture.enabled = true;
		SceneManager.LoadScene(name);
		//instance.guiTexture.enabled = false;
	}
	public static void Load(int index)
	{
		if (NoInstance()) return;
		instance.GetComponent<GUITexture>().enabled = true;
		SceneManager.LoadScene(index);
		instance.GetComponent<GUITexture>().enabled = false;
	}
	static bool NoInstance()
	{
		if (!instance)
			Debug.LogError("Loading Screen is not existing in scene.");
		return instance;
	}

}
