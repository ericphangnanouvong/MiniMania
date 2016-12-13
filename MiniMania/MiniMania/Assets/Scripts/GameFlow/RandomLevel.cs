using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;


public class RandomLevel : MonoBehaviour {

	public int randomNumber;

	// Use this for initialization
	void Start() 
	{
		randomNumber = Random.Range((int)1.0f, (int)5.0f);	


	}
	
	// Update is called once per frame
	void Update ()
	{
		
	}

	public void randomLevelGenerator()
	{
		SceneManager.LoadScene(randomNumber);
	}


}
