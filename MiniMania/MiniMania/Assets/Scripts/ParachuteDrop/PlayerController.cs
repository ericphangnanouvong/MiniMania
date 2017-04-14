using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour {

	public Transform playerOneTransform = null;
	public Transform playerTwoTransform = null;
	public Transform ground = null;

	public Rigidbody2D playerOneRb = null;
	public Rigidbody2D playerTwoRb = null;
	public Rigidbody2D cameraParentObject = null;
	public GameObject parachuteP1;
	public GameObject parachuteP2;

	public float distanceToGroundPlayerOne;
	public float distanceToGroundPlayerTwo;

	//[SerializeField] KeyCode playerOneInputButton = 0;
	//[SerializeField] KeyCode playerTwoInputButton = 0;
	//[SerializeField] KeyCode startGameButton = 0;

	public string fireP1;
	public string fireP2;
	public string startGameButton;
	public float officialDistanceToGroundP1;
	public float officialDistanceToGroundP2;

	private bool p1ButtonPressed = false;
	private bool p2ButtonPressed = false;

	public Text p1Text = null;
	public Text p2Text = null;
	public Text winnerText = null;

	public float p1EndStatsTime;
	public float p2EndStatsTime;

	public Camera camera;
	private bool gameStarted = false;
	public Text timerText = null;
	private float timer = 3;





	// Use this for initialization
	void Start () 
	{
		//Time.timeScale = 0;
		//playerOneRb = this.gameObject.GetComponent<Rigidbody2D>();
	}

	// Update is called once per frame
	void Update () 
	{	
		
			timer -= Time.deltaTime;

			if (timer <= 0)
			{
				timerText.text = "";
				gameStarted = true;
				playerOneRb.gravityScale = 1;
				playerTwoRb.gravityScale = 1;
			cameraParentObject.GetComponent<Rigidbody2D>().gravityScale = 1;
				//camera.GetComponent<Rigidbody2D>().gravityScale = 1;
			}

			else
				timerText.text = "  " + timer.ToString("0");
			//startGame();
			//JoyStickStartGame();
			determineDistanceConstantly();

		winCondition();


		// Distance to ground debugger	
		//Debug.Log(distanceToGroundPlayerOne);
		//Debug.Log(distanceToGroundPlayerTwo);
	}

	void FixedUpdate()
	{	

		//PlayerInput();
		if(gameStarted)
		JoyStickInput();


		// Testing if player bools are triggering correctly
		//deathDebugger();
		//Debug.Log("Player One Died " + PlayerCollision.playerOneDied);
		//Debug.Log("Player Two Died " + PlayerCollision.playerTwoDied);
	}

	/* void PlayerInput ()
	{
		if(Input.GetKeyDown(playerOneInputButton) && p1ButtonPressed == false)
		{	
			//SpriteRenderer parachuteP1 = gameObject.GetComponent<SpriteRenderer>();


			p1ButtonPressed = true;
			officialDistanceToGroundP1 = -(ground.transform.position.y - playerOneTransform.transform.position.y) + 0.9654810555f;
			this.p1Text.text = "Distance: " + officialDistanceToGroundP1.ToString();
			parachuteP1.GetComponent<SpriteRenderer>().enabled = true;
			playerOneRb.GetComponent<Rigidbody2D>().drag = 1.5f;

		}
		if(Input.GetKeyDown(playerTwoInputButton) && p2ButtonPressed == false)
		{	

			p2ButtonPressed = true;
			officialDistanceToGroundP2 = -(ground.transform.position.y - playerTwoTransform.transform.position.y) + 0.889643505f;
			this.p2Text.text = "Distance: " + officialDistanceToGroundP2.ToString();
			parachuteP2.GetComponent<SpriteRenderer>().enabled = true;
			playerTwoRb.GetComponent<Rigidbody2D>().drag = 1.5f;
		}

		if(p1ButtonPressed == true && p2ButtonPressed == true)
		{
			cameraParentObject.GetComponent<Rigidbody2D>().drag = 1.5f;
		}

		
	} */

	/*void startGame()
	{	
		if(Input.GetKeyDown(startGameButton))
		{
			Time.timeScale = 1;
		}
	}*/



	void JoyStickInput()
	{

		if(Input.GetButtonDown(fireP1) && p1ButtonPressed == false)
		{	
			//SpriteRenderer parachuteP1 = gameObject.GetComponent<SpriteRenderer>();


			p1ButtonPressed = true;
			officialDistanceToGroundP1 = -(ground.transform.position.y - playerOneTransform.transform.position.y) + 0.9654810555f;
			this.p1Text.text = "Distance: " + officialDistanceToGroundP1.ToString("00.00");
			parachuteP1.GetComponent<SpriteRenderer>().enabled = true;
			playerOneRb.GetComponent<Rigidbody2D>().drag = 1.5f;

		}
		if(Input.GetButtonDown(fireP2) && p2ButtonPressed == false)
		{	

			p2ButtonPressed = true;
			officialDistanceToGroundP2 = -(ground.transform.position.y - playerTwoTransform.transform.position.y) + 0.889643505f;
			this.p2Text.text = "Distance: " + officialDistanceToGroundP2.ToString("00.00");
			parachuteP2.GetComponent<SpriteRenderer>().enabled = true;
			playerTwoRb.GetComponent<Rigidbody2D>().drag = 1.5f;
		}

		if(p1ButtonPressed == true && p2ButtonPressed == true)
		{
			cameraParentObject.GetComponent<Rigidbody2D>().drag = 1.5f;
		}
	}

	void JoyStickStartGame()
	{
		if(Input.GetButtonDown(startGameButton))
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
				GameDataManager.Instance.playerOneTotalScore++;
				GameDataManager.Instance.PlayerOneParaDistance = officialDistanceToGroundP1;
				GameDataManager.Instance.PlayerTwoParaDistance = officialDistanceToGroundP2;

				GameObject.Find("Player Two").GetComponent<SpriteRenderer>().enabled = false;
				camera.GetComponent<Rigidbody2D>().gravityScale=0;
				StartCoroutine("ChangeLevel");
			}
			else 
			{
				this.winnerText.text = "Player Two Wins!!!";
				GameDataManager.Instance.playerTwoTotalScore++;
				GameDataManager.Instance.PlayerOneParaDistance = officialDistanceToGroundP1;
				GameDataManager.Instance.PlayerTwoParaDistance = officialDistanceToGroundP2;
				camera.GetComponent<Rigidbody2D>().gravityScale=0;
				GameObject.Find("Player One").GetComponent<SpriteRenderer>().enabled = false;
				StartCoroutine("ChangeLevel");
			}
		}

		else if(p1ButtonPressed == true && PlayerCollision.playerTwoDied == true)
		{
			this.winnerText.text = "Player One Wins!!!!";
			GameDataManager.Instance.playerOneTotalScore++;
			GameDataManager.Instance.PlayerOneParaDistance = officialDistanceToGroundP1;
			GameDataManager.Instance.PlayerTwoParaDistance = officialDistanceToGroundP2;
			camera.GetComponent<Rigidbody2D>().gravityScale=0;
			StartCoroutine("ChangeLevel");
		}
		else if(PlayerCollision.playerOneDied == true && p2ButtonPressed == true)
		{
			this.winnerText.text = "Player Two Wins!!!!";
			GameDataManager.Instance.playerTwoTotalScore++;
			GameDataManager.Instance.PlayerOneParaDistance = officialDistanceToGroundP1;
			GameDataManager.Instance.PlayerTwoParaDistance = officialDistanceToGroundP2;
			camera.GetComponent<Rigidbody2D>().gravityScale=0;
			StartCoroutine("ChangeLevel");
		}

		else if(PlayerCollision.playerOneDied == true && PlayerCollision.playerTwoDied == true)
		{
			this.winnerText.text = "You Suck At This!!!!!!";
			GameDataManager.Instance.PlayerOneParaDistance = 0;
			GameDataManager.Instance.PlayerTwoParaDistance = 0;
			StartCoroutine("ChangeLevel");
			camera.GetComponent<Rigidbody2D>().gravityScale=0;
		}


	}

	public IEnumerator ChangeLevel()
	{
		yield return new WaitForSeconds(3);
		SceneManager.LoadScene("Transition");
	}

}
