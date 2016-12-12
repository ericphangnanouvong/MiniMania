using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {


	public Transform playerOneTransform = null;
	public Transform playerTwoTransform = null;
	public Transform ground = null;

	public Rigidbody2D playerOneRb = null;
	public Rigidbody2D playerTwoRb = null;

	public float distanceToGroundPlayerOne;
	public float distanceToGroundPlayerTwo;

	[SerializeField] KeyCode playerOneInputButton = 0;
	[SerializeField] KeyCode playerTwoInputButton = 0;
	[SerializeField] KeyCode startGameButton = 0;

	public float officialDistanceToGroundP1;
	public float officialDistanceToGroundP2;

	private bool p1ButtonPressed = false;
	private bool p2ButtonPressed = false;

	public Text p1Text = null;
	public Text p2Text = null;
	public Text winnerText = null;


	// Use this for initialization
	void Start () 
	{
		Time.timeScale = 0;
	}
	
	// Update is called once per frame
	void Update () 
	{	
		startGame();
		determineDistanceConstantly();
		winCondition();


		// Distance to ground debugger	
		//Debug.Log(distanceToGroundPlayerOne);
		//Debug.Log(distanceToGroundPlayerTwo);
	}

	void FixedUpdate()
	{	
		
		PlayerInput();

		// Testing if player bools are triggering correctly
		//deathDebugger();
		Debug.Log("Player One Died " + PlayerCollision.playerOneDied);
		Debug.Log("Player Two Died " + PlayerCollision.playerTwoDied);
	}

	void PlayerInput ()
	{
		if(Input.GetKeyDown(playerOneInputButton) && p1ButtonPressed == false)
		{	
			Time.timeScale = 1;
			p1ButtonPressed = true;
			officialDistanceToGroundP1 = -(ground.transform.position.y - playerOneTransform.transform.position.y) + 0.9654810555f;
			this.p1Text.text = "Distance: " + officialDistanceToGroundP1.ToString();
			playerOneRb.GetComponent<Rigidbody2D>().drag = 1.5f;
		}
		if(Input.GetKeyDown(playerTwoInputButton) && p2ButtonPressed == false)
		{	


			p2ButtonPressed = true;
			officialDistanceToGroundP2 = -(ground.transform.position.y - playerTwoTransform.transform.position.y) + 0.889643505f;
			this.p2Text.text = "Distance: " + officialDistanceToGroundP2.ToString();
			playerTwoRb.GetComponent<Rigidbody2D>().drag = 1.5f;
		}

		
	}

	void startGame()
	{	
		if(Input.GetKeyDown(startGameButton))
		{
			Time.timeScale = 1;
		}
	}
		
	void deathDebugger()
	{
		if(PlayerCollision.playerOneDied == true)
		{
			Debug.Log("P1 Died");
		}
		if(PlayerCollision.playerTwoDied == true)
		{
			Debug.Log("P2 Died");
		}
	} 

	void determineDistanceConstantly()
	{
		if(p1ButtonPressed == false)
		{
			distanceToGroundPlayerOne = (ground.transform.position.y - playerOneTransform.transform.position.y) + 0.9654810555f;
		}
		if(p2ButtonPressed == false)
		{
			distanceToGroundPlayerTwo = (ground.transform.position.y - playerTwoTransform.transform.position.y) + 0.889643505f;
		}
	}

	void winCondition()
	{
		if(p1ButtonPressed == true && p2ButtonPressed == true)
		{
			if(officialDistanceToGroundP1 < officialDistanceToGroundP2)
			{
				this.winnerText.text = "Player One Wins!!!!";
			}
			else 
			{
				this.winnerText.text = "Player Two Wins!!!";
			}
		}

		else if(p1ButtonPressed == true && PlayerCollision.playerTwoDied == true)
		{
			this.winnerText.text = "Player One Wins!!!!";
		}
		else if(PlayerCollision.playerOneDied == true && p2ButtonPressed == true)
		{
			this.winnerText.text = "Player Two Wins!!!!";
		}

		else if(PlayerCollision.playerOneDied == true && PlayerCollision.playerTwoDied == true)
		{
			this.winnerText.text = "You Suck At This!!!!!!";	
		}	 

	}


}
