using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;


public class RandomLevel : MonoBehaviour {

	public float randomNumber;

	// Use this for initialization
	void Start () 
	{
		randomNumber = Random.Range((int)2.0f, (int)3.0f);	

	}
	
	// Update is called once per frame
	void Update ()
	{
		Debug.Log(randomNumber);
	}

	/*public void TransitionToScene (string sceneName)
	{
		Application.LoadLevel(sceneName);
	}*/

	public void chosenLevel()
	{
		
		if(randomNumber == 2)
		{
			SceneManager.LoadScene("Parachute Drop");
		}
		if(randomNumber == 3)
		{
			SceneManager.LoadScene("Bang Game");
		}
	} 


}
