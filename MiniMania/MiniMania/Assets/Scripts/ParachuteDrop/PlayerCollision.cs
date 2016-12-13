using UnityEngine;
using System.Collections;

public class PlayerCollision : MonoBehaviour {

	[SerializeField] private float velocityDeathLimit = 4.0f;
	static public bool playerOneDied = false;
	static public bool playerTwoDied = false;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter2D(Collision2D collision)
	{
		if(collision.gameObject.CompareTag("Ground"))
		{
			if(collision.relativeVelocity.magnitude > this.velocityDeathLimit)
			{	
				playersDied();
				DestroyObject();

			}
		}


	} 

	void DestroyObject()
	{
		Destroy(this.gameObject, 0.01f);
	}

	void playersDied()
	{
		if(this.gameObject.tag == "Player One")
		{
			playerOneDied = true;
		}

		else
		{
			playerTwoDied = true;
		}
	}


}
