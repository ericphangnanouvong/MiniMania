using UnityEngine;
using System.Collections;

public class PlayerCollision : MonoBehaviour {

	[SerializeField] private float velocityDeathLimit;
	public float currentVelociity;
	static public bool playerOneDied = false;
	static public bool playerTwoDied = false;


	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		/*if(this.transform.position.y < 18 && this.transform.position.y > 17)
		{	
			currentVelociity =	GameObject.FindGameObjectWithTag("Player One").GetComponent<Rigidbody2D>().velocity.y;
			Debug.Log(currentVelociity);
		}*/
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
        //Destroy(this.gameObject, 0.01f);
       
            
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
