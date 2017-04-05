using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReplayGame : MonoBehaviour {

	private TextRandomizer newScene;
	void Start () 
	{	

		newScene = GameObject.Find("Main Menu2").GetComponent<TextRandomizer>();

		//newScene.originalGamesAdded = true;
		SceneManager.LoadScene("Transition");
	}
	
	public void TransitionToScene (string sceneName)
	{
		Application.LoadLevel(sceneName);
	}


}
