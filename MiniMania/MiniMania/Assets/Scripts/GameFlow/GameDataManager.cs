using UnityEngine;
using System.Collections;


public class GameDataManager
    {


	private static GameDataManager instance = null;

	public static GameDataManager Instance
	{
		get
		{
			if (instance == null)
			{
				instance = new GameDataManager();
			}
			return instance;
		}
	}


	// PlayerData Constructor:
	private GameDataManager()
	{

		// Initialize high score with the score stored in PlayerPrefs. 

	}


	// Accessors:

	// Balloon Score

	private int p1_balloonscore = 0;

	public int P1_BalloonScore
	{
		get
		{
			return this.p1_balloonscore;
		}
		set
		{
			p1_balloonscore = value;

			playerOneTotalScore += p1_balloonscore;

		}
	}

	private int p2_balloonscore = 0;

	public int P2_BalloonScore
	{
		get
		{
			return this.p2_balloonscore;
		}
		set
		{
			p2_balloonscore = value;

			playerTwoTotalScore += p2_balloonscore;

		}
	}

	// FINAL SCORES

	private int playeronetotalScore = 0;

	public int playerOneTotalScore
	{
		get
		{
			return this.playeronetotalScore;
		}
		set
		{
			playeronetotalScore = value;

		}
	}

	private int playertwototalScore = 0;

	public int playerTwoTotalScore
	{
		get
		{
			return this.playertwototalScore;
		}
		set
		{
			playertwototalScore = value;

		}
	}

	// ParaDrop Distance

	private float P1PlayerOneParaDistance = 0;

	public float PlayerOneParaDistance
	{
		get
		{
			return this.P1PlayerOneParaDistance;
		}
		set
		{
			P1PlayerOneParaDistance = value;

		}
	}



	private float P2PlayerTwoParaDistance = 0;

	public float PlayerTwoParaDistance
	{
		get
		{
			return this.P2PlayerTwoParaDistance;
		}
		set
		{
			P2PlayerTwoParaDistance = value;

		}
	}

	// Bang Game Scoring

	private float P1PlayerBangTime = 0;

	public float PlayerOneBangTime
	{
		get
		{
			return this.P1PlayerBangTime;
		}
		set
		{
			P1PlayerBangTime = value;

		}
	}

	private float P2PlayerBangTime = 0;

	public float PlayerTwoBangTime
	{
		get
		{
			return this.P2PlayerBangTime;
		}
		set
		{
			P2PlayerBangTime = value;

		}
	}

	// Vert Scoring Time

	private float P1PlayerVertPlatTime = 0;

	public float PlayerOneVertPlatTime
	{
		get
		{
			return this.P1PlayerVertPlatTime;
		}
		set
		{
			P1PlayerVertPlatTime = value;

		}
	}

	private float P2PlayerVertPlatTime = 0;

	public float PlayerTwoVertPlatTime
	{
		get
		{
			return this.P2PlayerVertPlatTime;
		}
		set
		{
			P2PlayerVertPlatTime = value;

		}
	}





}



/*
    static public int playerOneTotalScore;
	static public int playerTwoTotalScore;
	// Use this for initialization
	void Start () 
	{
		playerOneTotalScore = 0;
		playerTwoTotalScore = 0;
	}

	// Update is called once per frame
	void Update () {

	}
<<<<<<< HEAD

   
=======
    */


